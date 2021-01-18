using AIO.BackendServer.Constants;
using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Extensions;
using AIO.BackendServer.Helpers;
using AIO.BackendServer.Services;
using AIO.ViewModels.Systems;
using AIO.ViewModels.Systems.DichVu;
using AIO.ViewModels.Systems.HoaDon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    public class HoaDonController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly string tieuDe = "hóa đơn";
        private InfoUser infoUser = new InfoUser();
        private ISequenceService _sequenceService { get; set; }
        private IConfiguration _configuration { get; }

        public HoaDonController(ApplicationDbContext context, IConfiguration configuration, ISequenceService sequenceService)
        {
            _context = context;
            _configuration = configuration;
            _sequenceService = sequenceService;
        }

        [HttpPost]
        [Route("them")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> Post([FromBody] HoaDonRequest request)
        {
            var max_id = _context.HoaDons.Any() ? _context.HoaDons.OrderByDescending(a => a.ID_HoaDon).FirstOrDefaultAsync().Result.ID_HoaDon : 1;
            var userID = User.GetUserId();
            // thêm thông tin loại phòng
            var hoadon = new HoaDon()
            {

                GioiTinh = request.GioiTinh,
                HoTen = request.HoTen,
                Email = request.Email,
                DaPhanHoi = false,
                DaThanhToan = false,
                ID_HinhThucThanhToan = request.ID_HinhThucThanhToan,
                KyHieuNgonNgu = request.KyHieuNgonNgu,
                MoTa = request.MoTa,
                SoTienThanhToan = request.SoTienThanhToan,
                ThoiGianDen = request.ThoiGianDen,
                ID_KhachSan = infoUser.ID_KhachSan,
                CreateBy = infoUser.TenDangNhap,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                ModifyBy = "",
                Delete = false
            };
            hoadon.ID_HoaDon = await _sequenceService.GetKnowledgeBaseNewId();
            hoadon.MaHoaDon = infoUser.KyHieuKhachSan.Trim() + "-IN" + DateTime.Now.Year + "-" + max_id;
            hoadon.Link = _configuration["UrlWebView"] + "/chi-tiet-hoa-don?id=" + hoadon.ID_HoaDon + "&khach-san=" + infoUser.ID_KhachSan;
            _context.HoaDons.Add(hoadon);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return Ok(hoadon);
            }

            else
            {
                return BadRequest(new ApiBadRequestResponse($"Tạo mới {tieuDe} thất bại."));
            }
        }

        [HttpGet("danh-sach")]
        //cliam
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.HoaDons.Where(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.Delete == DeleteStatus.ChuaXoa).
                Select(a => new DanhSachHoaDonVM
                {
                    ID_HinhThucThanhToan = a.ID_HinhThucThanhToan,
                    ID_HoaDon = a.ID_HoaDon,
                    GioiTinh = a.GioiTinh,
                    HoTen = a.HoTen,
                    Email = a.Email,
                    SoTienThanhToan = a.SoTienThanhToan,
                    ThoiGianDen = a.ThoiGianDen,
                    DaThanhToan = a.DaThanhToan,
                    DaPhanHoi = a.DaPhanHoi,
                    MaHoaDon = a.MaHoaDon
                }).AsQueryable().ToListAsync();
            return Ok(result);
        }

        [Route("sua")]
        [HttpPut]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        [ApiValidationFilter]
        public async Task<IActionResult> Put([FromBody] HoaDonRequest request)
        {
            var hoadon = _context.HoaDons.Where(a => a.ID_HoaDon == request.ID_HoaDon && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (hoadon == null)
            {
                return NotFound(new ApiNotFoundResponse($"{tieuDe} với id: {request.ID_HoaDon}  không tồn tại"));
            }

            hoadon.GioiTinh = request.GioiTinh;
            hoadon.HoTen = request.HoTen;
            hoadon.Email = request.Email;
            hoadon.DaPhanHoi = false;
            hoadon.DaThanhToan = false;
            hoadon.ID_HinhThucThanhToan = request.ID_HinhThucThanhToan;
            hoadon.KyHieuNgonNgu = request.KyHieuNgonNgu;
            hoadon.MoTa = request.MoTa;
            hoadon.SoTienThanhToan = request.SoTienThanhToan;
            hoadon.ThoiGianDen = request.ThoiGianDen;

            _context.HoaDons.Update(hoadon);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest(new ApiBadRequestResponse("Cập nhật không thành công"));
        }

        [HttpDelete]
        [Route("xoa")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var hoadon = _context.HoaDons.Where(a => a.ID_HoaDon == id && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (hoadon == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id} không tồn tại"));
            }
            hoadon.Delete = true;
            _context.HoaDons.Update(hoadon);
            var result = await _context.SaveChangesAsync();

            return BadRequest(new ApiBadRequestResponse($"Xóa {tieuDe} không thành công"));
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnObject = new HoaDonVM();
            var hoadon = await _context.HoaDons.FirstOrDefaultAsync(a => a.ID_HoaDon == id && a.ID_KhachSan == infoUser.ID_KhachSan);
            if (hoadon == null)
            {
                returnObject = new HoaDonVM
                {
                    ID_HinhThucThanhToan = 0,
                    ID_HoaDon = 0,
                    KyHieuNgonNgu = "",
                    DaPhanHoi = false,
                    DaThanhToan = false,
                    Email = "",
                    GioiTinh = "",
                    HoTen = "",
                    Link = _configuration["UrlWebView"],
                    MaHoaDon = "",
                    MoTa = "",
                    SoTienThanhToan = 0,
                    ThoiGianDen = DateTime.Now
                };
                return Ok(returnObject);
            }

            returnObject = new HoaDonVM
            {
                ID_HinhThucThanhToan = hoadon.ID_HinhThucThanhToan,
                ID_HoaDon = hoadon.ID_HoaDon,
                KyHieuNgonNgu = hoadon.KyHieuNgonNgu,
                DaPhanHoi = hoadon.DaPhanHoi,
                DaThanhToan = hoadon.DaThanhToan,
                Email = hoadon.Email,
                GioiTinh = hoadon.GioiTinh,
                HoTen = hoadon.HoTen,
                Link = hoadon.Link,
                MaHoaDon = hoadon.MaHoaDon,
                MoTa = hoadon.MoTa,
                SoTienThanhToan = hoadon.SoTienThanhToan,
                ThoiGianDen = hoadon.ThoiGianDen,
            };

            return Ok(returnObject);
        }
    }
}