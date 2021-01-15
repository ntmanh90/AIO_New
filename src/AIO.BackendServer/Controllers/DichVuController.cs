using System;
using System.Linq;
using System.Threading.Tasks;
using AIO.BackendServer.Authorization;
using AIO.BackendServer.Constants;
using AIO.BackendServer.Data;
using AIO.BackendServer.Helpers;
using Microsoft.AspNetCore.Mvc;
using AIO.BackendServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using AIO.ViewModels;
using Microsoft.AspNetCore.Mvc.Filters;
using AIO.ViewModels.LoaiGiuong;
using AIO.ViewModels.NgonNgu;
using System.Collections.Generic;
using AIO.ViewModels.Systems;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.Systems.Common;
using AIO.ViewModels.Systems.LoaiPhong;
using AIO.ViewModels.Systems.DichVu;

namespace AIO.BackendServer.Controllers
{
    public class DichVuController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly string tieuDe = "dịch vụ";
        InfoUser infoUser = new InfoUser();

        public DichVuController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("them")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> PostLoaiGiuong([FromBody] DichVuRequest request)
        {
            var max_id = _context.DichVus.Any() ? _context.DichVus.Max(a => a.ID_DichVu) : 0;
            // thêm thông tin loại phòng
            var dichVu = new DichVu()
            {
                TenDichvu = request.TenDichvu,
                MaDichVu = infoUser.KyHieuKhachSan.Trim() + IdGenerator.NextId_DichVu(max_id),
                AnhDaiDien = request.AnhDaiDien,
                GiaTheoDemLuuTru = request.GiaTheoDemLuuTru,
                GiaTheoDichVu = request.GiaTheoDichVu,
                GiaTinhTheo = request.GiaTinhTheo,
                GiaTheoNguoiLon = request.GiaTheoNguoiLon,
                GiaTheoTreEm = request.GiaTheoTreEm,
                TrangThai = request.TrangThai,
                ID_KhachSan = infoUser.ID_KhachSan,

                CreateBy = infoUser.TenDangNhap,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                ModifyBy = "",
                Delete = false

            };
            _context.DichVus.Add(dichVu);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                //thêm ngôn ngữ 
                foreach (var item in request.NN_DichVuRequests)
                {
                    var nn_dichvu = new NN_DichVu
                    {
                        ID_DichVu = dichVu.ID_DichVu,
                        Id_NgonNgu = item.ID_NgonNgu,
                        TenTheoNgonNgu = item.TenTheoNgonNgu,
                        NoiDungTheoNgonNgu = item.NoiDungTheoNgonNgu,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.NN_DichVus.Add(nn_dichvu);
                    _context.SaveChanges();
                }
                
                return Ok(dichVu);
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
            var result = await _context.DichVus.Where(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.Delete == DeleteStatus.ChuaXoa).AsQueryable().ToListAsync();
            return Ok(result);
        }

        [Route("sua")]
        [HttpPut]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        [ApiValidationFilter]
        public async Task<IActionResult> PutLoaiPhong([FromBody] DichVuRequest request)
        {
            var dichvu =  _context.DichVus.Where(a=>a.ID_DichVu == request.ID_DichVu && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (dichvu == null)
            {
                return NotFound(new ApiNotFoundResponse($"{tieuDe} với id: {request.ID_DichVu}  không tồn tại"));
            }

            dichvu.TenDichvu = request.TenDichvu;
            dichvu.AnhDaiDien = request.AnhDaiDien;
            dichvu.GiaTheoDemLuuTru = request.GiaTheoDemLuuTru;
            dichvu.GiaTheoDichVu = request.GiaTheoDichVu;
            dichvu.GiaTinhTheo = request.GiaTinhTheo;
            dichvu.GiaTheoNguoiLon = request.GiaTheoNguoiLon;
            dichvu.GiaTheoTreEm = request.GiaTheoTreEm;
            dichvu.TrangThai = request.TrangThai;


            _context.DichVus.Update(dichvu);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                _context.NN_DichVus.RemoveRange(_context.NN_DichVus.Where(a => a.ID_DichVu == dichvu.ID_DichVu).ToList());
                _context.SaveChanges();
                //thêm ngôn ngữ 
                foreach (var item in request.NN_DichVuRequests)
                {
                    var nn_dichvu = new NN_DichVu
                    {
                        ID_DichVu = dichvu.ID_DichVu,
                        Id_NgonNgu = item.ID_NgonNgu,
                        TenTheoNgonNgu = item.TenTheoNgonNgu,
                        NoiDungTheoNgonNgu = item.NoiDungTheoNgonNgu,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.NN_DichVus.Add(nn_dichvu);
                    _context.SaveChanges();
                }

                return Ok(dichvu);
            }
            return BadRequest(new ApiBadRequestResponse("Cập nhật không thành công"));
        }

        [HttpDelete]
        [Route("xoa")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var dichvu =  _context.DichVus.Where(a=>a.ID_DichVu == id && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (dichvu == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id} không tồn tại"));
            }
            dichvu.Delete = true;
            _context.DichVus.Update(dichvu);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                //Ngôn ngữ loại phòng
                _context.NN_DichVus.Where(a => a.ID_DichVu == dichvu.ID_DichVu).ToList().ForEach(a => a.Delete = true);
                _context.SaveChanges();

                return Ok(new { kq = true });
            }
            return BadRequest(new ApiBadRequestResponse($"Xóa {tieuDe} không thành công"));
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnObject = new DichVuVM();
            var dichvu =  _context.DichVus.Where(a=>a.ID_DichVu == id && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (dichvu == null)
            {
                returnObject = new DichVuVM
                {
                    ID_DichVu = 0,
                    TenDichvu ="",
                    AnhDaiDien = "",
                    GiaTheoDemLuuTru = 0,
                    GiaTheoDichVu = 0,
                    GiaTinhTheo = 0,
                    GiaTheoNguoiLon = 0,
                    GiaTheoTreEm = 0,
                    TrangThai = true,
                    TheoDichVu = LoaiGiaDichVuConst.TheoDichVu,
                    TheoDemLuuTru = LoaiGiaDichVuConst.TheoDemLuuTru,
                    TheoSoNguoi = LoaiGiaDichVuConst.TheoSoNguoi,
                    NN_DichVuVMs = new List<NN_DichVuVM>()
                };
                foreach (var item in _context.NgonNgus.ToList())
                {
                    NN_DichVuVM nN_Object = new NN_DichVuVM
                    {
                        ID_NgonNgu = item.ID_NgonNgu,
                        TenNgonNgu = _context.NgonNgus.FirstOrDefault(b => b.ID_NgonNgu == item.ID_NgonNgu).TieuDe,
                        TenTheoNgonNgu = "",
                        NoiDungTheoNgonNgu =""
                    };
                    returnObject.NN_DichVuVMs.Add(nN_Object);
                }

                return Ok(returnObject);
            }
            returnObject = new DichVuVM
            {
                ID_DichVu = dichvu.ID_DichVu,
                TenDichvu = dichvu.TenDichvu,
                AnhDaiDien = dichvu.AnhDaiDien,
                GiaTheoDemLuuTru = dichvu.GiaTheoDemLuuTru,
                GiaTheoDichVu = dichvu.GiaTheoDichVu,
                GiaTinhTheo = dichvu.GiaTinhTheo,
                GiaTheoNguoiLon = dichvu.GiaTheoNguoiLon,
                GiaTheoTreEm = dichvu.GiaTheoTreEm,
                TrangThai = dichvu.TrangThai,
                TheoDichVu = LoaiGiaDichVuConst.TheoDichVu,
                TheoDemLuuTru = LoaiGiaDichVuConst.TheoDemLuuTru,
                TheoSoNguoi = LoaiGiaDichVuConst.TheoSoNguoi,

                NN_DichVuVMs = _context.NN_DichVus.Where(a => a.ID_DichVu == dichvu.ID_DichVu)
                .Select(a => new NN_DichVuVM
                {
                    ID_NgonNgu = a.Id_NgonNgu,
                    TenTheoNgonNgu = a.TenTheoNgonNgu,
                    NoiDungTheoNgonNgu = a.NoiDungTheoNgonNgu,
                    TenNgonNgu = _context.NgonNgus.FirstOrDefault(b => b.ID_NgonNgu == a.Id_NgonNgu).TieuDe
                }).ToList(),
            };

            return Ok(returnObject);
        }

    }
}
