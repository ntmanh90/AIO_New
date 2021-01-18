using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Helpers;
using AIO.ViewModels.Systems;
using AIO.ViewModels.Systems.CaiDatBanPhong;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    public class CaiDatBanPhongController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private InfoUser infoUser = new InfoUser();

        public CaiDatBanPhongController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Cài đặt Giá phòng nhiều ngày
        [HttpPost]
        [Route("cai-dat-gia-ban-nhieu-ngay")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> CaiDatGiaBanNhieuNgay([FromBody] CaiDatGiaPhongRequest request)
        {
            // loại phòng phải thuộc khách sạn
            if (_context.LoaiPhongs.Any(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.ID_LoaiPhong == request.ID_LoaiPhong) == false)
            {
                return BadRequest("Phòng không tồn tại trong hệ thống");
            }

            for (var ngaycaidat = request.NgayBatDau; ngaycaidat < request.NgayKetThuc; ngaycaidat = ngaycaidat.AddDays(1))
            {
                var chitietcaidatphong = await _context.CaiDatBanPhongs.FirstOrDefaultAsync(a => a.NgayCaiDat.Date == ngaycaidat.Date && a.ID_LoaiPhong == request.ID_LoaiPhong);

                if (chitietcaidatphong == null)
                {
                    chitietcaidatphong = new CaiDatBanPhong
                    {
                        ID_LoaiPhong = request.ID_LoaiPhong,
                        GiaBan = request.GiaBan,
                        NgayCaiDat = ngaycaidat,
                        SoLuong = 0,
                        TrangThai = true,
                    };
                    _context.CaiDatBanPhongs.Add(chitietcaidatphong);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    chitietcaidatphong.GiaBan = request.GiaBan;
                    _context.CaiDatBanPhongs.Update(chitietcaidatphong);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok();
        }

        //Cài đăt số lượng phòng nhiều ngày
        [HttpPost]
        [Route("cai-dat-so-luong-nhieu-ngay")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> CaiDatSoLuongNhieuNgay([FromBody] CaiDatSoLuongRequest request)
        {
            // loại phòng phải thuộc khách sạn
            if (_context.LoaiPhongs.Any(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.ID_LoaiPhong == request.ID_LoaiPhong) == false)
            {
                return BadRequest("Phòng không tồn tại trong hệ thống");
            }

            for (var ngaycaidat = request.NgayBatDau; ngaycaidat < request.NgayKetThuc; ngaycaidat = ngaycaidat.AddDays(1))
            {
                var chitietcaidatphong = await _context.CaiDatBanPhongs.FirstOrDefaultAsync(a => a.NgayCaiDat.Date == ngaycaidat.Date && a.ID_LoaiPhong == request.ID_LoaiPhong);

                if (chitietcaidatphong == null)
                {
                    chitietcaidatphong = new CaiDatBanPhong
                    {
                        ID_LoaiPhong = request.ID_LoaiPhong,
                        GiaBan = 0,
                        NgayCaiDat = ngaycaidat,
                        SoLuong = request.SoLuong,
                        TrangThai = true,
                    };
                    _context.CaiDatBanPhongs.Add(chitietcaidatphong);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    chitietcaidatphong.SoLuong = request.SoLuong;
                    _context.CaiDatBanPhongs.Update(chitietcaidatphong);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok();
        }

        //Đóng mở phòng nhiều ngày
        [HttpPost]
        [Route("cai-dat-trang-thai-nhieu-ngay")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> CaiDatTrangThaiNhieuNgay([FromBody] CaiDatTrangThaiPhongRequest request)
        {
            // loại phòng phải thuộc khách sạn
            if (_context.LoaiPhongs.Any(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.ID_LoaiPhong == request.ID_LoaiPhong) == false)
            {
                return BadRequest("Phòng không tồn tại trong hệ thống");
            }
            for (var ngaycaidat = request.NgayBatDau; ngaycaidat < request.NgayKetThuc; ngaycaidat = ngaycaidat.AddDays(1))
            {
                var chitietcaidatphong = await _context.CaiDatBanPhongs.FirstOrDefaultAsync(a => a.NgayCaiDat.Date == ngaycaidat.Date && a.ID_LoaiPhong == request.ID_LoaiPhong);

                if (chitietcaidatphong == null)
                {
                    chitietcaidatphong = new CaiDatBanPhong
                    {
                        ID_LoaiPhong = request.ID_LoaiPhong,
                        GiaBan = 0,
                        NgayCaiDat = ngaycaidat,
                        SoLuong = 0,
                        TrangThai = request.TrangThai,
                    };
                    _context.CaiDatBanPhongs.Add(chitietcaidatphong);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    chitietcaidatphong.TrangThai = request.TrangThai;
                    _context.CaiDatBanPhongs.Update(chitietcaidatphong);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok();
        }

        //Cập nhật giá phòng một ngày
        [HttpPost]
        [Route("cap-nhat-gia-phong-mot-ngay")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> CapNhatGiaPhongMotNgay([FromBody] CapNhatGiaBanPhongRequest request)
        {
            // loại phòng phải thuộc khách sạn
            if (_context.LoaiPhongs.Any(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.ID_LoaiPhong == request.ID_LoaiPhong) == false)
            {
                return BadRequest("Phòng không tồn tại trong hệ thống");
            }
            var chitietcaidatphong = await _context.CaiDatBanPhongs.Where(a => a.ID_LoaiPhong == request.ID_LoaiPhong && a.NgayCaiDat.Date == request.NgayCaiDat.Date && a.ID_CaiDatBanPhong == request.ID_CaiDatBanPhong).FirstOrDefaultAsync();
            if (chitietcaidatphong == null)
            {
                return BadRequest("Phòng không tồn tại trong hệ thống");
            }

            chitietcaidatphong.GiaBan = request.GiaBan;
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Cập nhật số lượng phòng một ngày
        [HttpPost]
        [Route("cap-nhat-so-luong-mot-ngay")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> CapNhatSoLuongMotNgay([FromBody] CapNhatSoLuongPhongRequest request)
        {
            // loại phòng phải thuộc khách sạn
            if (_context.LoaiPhongs.Any(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.ID_LoaiPhong == request.ID_LoaiPhong) == false)
            {
                return BadRequest("Phòng không tồn tại trong hệ thống");
            }
            var chitietcaidatphong = await _context.CaiDatBanPhongs.Where(a => a.ID_LoaiPhong == request.ID_LoaiPhong && a.NgayCaiDat.Date == request.NgayCaiDat.Date && a.ID_CaiDatBanPhong == request.ID_CaiDatBanPhong).FirstOrDefaultAsync();
            if (chitietcaidatphong == null)
            {
                return BadRequest("Phòng không tồn tại trong hệ thống");
            }

            chitietcaidatphong.SoLuong = request.SoLuong;
            _context.CaiDatBanPhongs.Update(chitietcaidatphong);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Cập nhật đóng, mở phòng 1 ngày
        [HttpPost]
        [Route("cap-nhat-trang-thai-mot-ngay")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> CapNhatTrangThaiMotNgay([FromBody] CapNhatTrangThaiPhongRequest request)
        {
            // loại phòng phải thuộc khách sạn
            if (_context.LoaiPhongs.Any(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.ID_LoaiPhong == request.ID_LoaiPhong) == false)
            {
                return BadRequest("Phòng không tồn tại trong hệ thống");
            }
            var chitietcaidatphong = await _context.CaiDatBanPhongs.Where(a => a.ID_LoaiPhong == request.ID_LoaiPhong && a.NgayCaiDat.Date == request.NgayCaiDat.Date && a.ID_CaiDatBanPhong == request.ID_CaiDatBanPhong).FirstOrDefaultAsync();
            if (chitietcaidatphong == null)
            {
                return BadRequest("Phòng không tồn tại trong hệ thống");
            }

            chitietcaidatphong.TrangThai = request.TrangThai;
            _context.CaiDatBanPhongs.Update(chitietcaidatphong);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Danh sách
        [HttpGet]
        [Route("danh-sach")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> DanhSach([FromQuery] DateTime TuNgay, int KhoangNgay)
        {
            if (KhoangNgay > 60 || KhoangNgay < 0)
            {
                return BadRequest("Không được tìm quá 60 ngày");
            }
            var denNgay = TuNgay.AddDays(KhoangNgay);
            List<DanhSachBanPhongVM> danhSachBanPhongVMs = new List<DanhSachBanPhongVM>();
            //Lấy loaiphong
            var loaiPhongs = await _context.LoaiPhongs.Where(a => a.ID_KhachSan == infoUser.ID_KhachSan).OrderBy(a => a.Index).AsQueryable().ToListAsync();
            foreach (var loaiphong in loaiPhongs)
            {

                var khuyenMaiLoaiPhongVMs = await _context.LoaiPhong_KhuyenMaiDatPhongs.Where(a => a.Id_LoaiPhong == loaiphong.ID_LoaiPhong).Select(a => new KhuyenMaiCuaLoaiPhongVM
                {
                    ID_LoaiPhong = a.Id_LoaiPhong,
                    TenKhuyenMaiDatPhong = _context.KhuyenMaiDatPhongs.FirstOrDefault(a => a.ID_KhuyenMaiDatPhong == a.ID_KhuyenMaiDatPhong).TenKhuyenMaiDatPhong,
                    PhanTramGiamGia = _context.KhuyenMaiDatPhongs.FirstOrDefault(a => a.ID_KhuyenMaiDatPhong == a.ID_KhuyenMaiDatPhong).PhanTramGiamGia
                }
                ).ToListAsync();

                var CaiDatBanPhongVMs = await _context.CaiDatBanPhongs.Where(a => a.ID_LoaiPhong == loaiphong.ID_LoaiPhong && a.NgayCaiDat.Date >= TuNgay.Date && a.NgayCaiDat.Date <= denNgay.Date)
                    .Select(a => new CaiDatBanPhongVM
                    {
                        ID_LoaiPhong = a.ID_LoaiPhong,
                        ID_CaiDatBanPhong = a.ID_CaiDatBanPhong,
                        GiaBan = a.GiaBan,
                        NgayCaiDat = a.NgayCaiDat,
                        SoLuong = a.SoLuong,
                        TrangThai = a.TrangThai,
                    }).ToListAsync();
            
                foreach(var item in CaiDatBanPhongVMs)
                {
                    item.GiaKhuyenMaiDatPhongVMs = khuyenMaiLoaiPhongVMs.Select(b => new GiaKhuyenMaiDatPhongVM
                    {
                        Price = b.PhanTramGiamGia * 0.01 * item.GiaBan
                    }).ToList();
                }    

                DanhSachBanPhongVM danhSachBanPhongVM = new DanhSachBanPhongVM
                {
                    ID_LoaiPhong = loaiphong.ID_LoaiPhong,
                    Ten_LoaiPhong = loaiphong.TenLoaiPhong,
                    KhuyenMaiCuaLoaiPhongVMs = khuyenMaiLoaiPhongVMs,
                    CaiDatBanPhongVMs = CaiDatBanPhongVMs
                };
                danhSachBanPhongVMs.Add(danhSachBanPhongVM);
            }

            return Ok(danhSachBanPhongVMs);
        }

    }
}