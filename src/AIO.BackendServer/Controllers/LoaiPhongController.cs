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

namespace AIO.BackendServer.Controllers
{
    public class LoaiPhongController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly string tieuDe = "loại giường";
        InfoUser infoUser = new InfoUser();

        public LoaiPhongController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("them")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> PostLoaiGiuong([FromBody] LoaiPhongRequest request)
        {
            var max_id_loaiphong = _context.LoaiPhongs.Any() ? _context.LoaiPhongs.Max(a => a.ID_LoaiPhong) : 0;
            // thêm thông tin loại phòng
            var loaiPhong = new LoaiPhong()
            {
                AnhDaiDien = request.AnhDaiDien,
                CreateBy = infoUser.TenDangNhap,
                CreateDate = DateTime.Now,
                KichThuoc = request.KichThuoc,
                TenLoaiPhong = request.TenLoaiPhong,
                ModifyBy = "",
                ModifyDate = DateTime.Now,
                Delete = false,
                TrangThai = request.TrangThai,
                MaLoaiPhong = infoUser.KyHieuKhachSan.Trim() + IdGenerator.NextId_LoaiPhong(max_id_loaiphong),
                ID_KhachSan = infoUser.ID_KhachSan,
                ID_HuongNhin = request.ID_HuongNhin,
                NguoiLon = request.NguoiLon,
                TreEm = request.TreEm,
                Index = request.Index

            };
            _context.LoaiPhongs.Add(loaiPhong);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                //thêm ngôn ngữ cho tiêu đề
                foreach (var item in request.NN_LoaiPhongRequests)
                {
                    var nn_loaiphong = new NN_LoaiPhong
                    {
                        ID_LoaiPhong = loaiPhong.ID_LoaiPhong,
                        Id_NgonNgu = item.ID_NgonNgu,
                        TenLoaiPhongTheoNgonNgu = item.TenLoaiPhongTheoNgonNgu,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.NN_LoaiPhongs.Add(nn_loaiphong);
                    _context.SaveChanges();
                }
                //thêm tiện ích
                foreach (var item in request.LoaiPhong_TienIch_Requests)
                {
                    var loaiphong_tienich = new LoaiPhong_TienIch
                    {
                        ID_LoaiPhong = loaiPhong.ID_LoaiPhong,
                        Id_TienIch = item.ID_TienIch,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.LoaiPhong_TienIchs.Add(loaiphong_tienich);
                    _context.SaveChanges();
                }
                //Thêm loại giường
                foreach (var item in request.LoaiPhong_LoaiGiuong_Requests)
                {
                    var loaiphong_loaigiuong = new LoaiPhong_LoaiGiuong
                    {
                        ID_LoaiPhong = loaiPhong.ID_LoaiPhong,
                        Id_LoaiGiuong = item.ID_LoaiGiuong,

                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.LoaiPhong_LoaiGiuongs.Add(loaiphong_loaigiuong);
                    _context.SaveChanges();
                }

                //thêm gallery

                foreach (var item in request.loaiPhong_Gallery_Requests)
                {
                    var loaiphong_gallery = new LoaiPhong_Gallery
                    {
                        ID_LoaiPhong = loaiPhong.ID_LoaiPhong,
                        Url_Gallery = item.Url_Gallery,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.LoaiPhong_Gallerys.Add(loaiphong_gallery);
                    _context.SaveChanges();
                }
                return Ok(loaiPhong);
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
            var result = await _context.LoaiPhongs.Where(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.Delete == DeleteStatus.ChuaXoa).OrderBy(a=>a.Index).AsQueryable().ToListAsync();
            return Ok(result);
        }

        [Route("sua")]
        [HttpPut]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        [ApiValidationFilter]
        public async Task<IActionResult> PutLoaiPhong([FromBody] LoaiPhongRequest request)
        {
            var loaiPhong =  _context.LoaiPhongs.Where(a=>a.ID_LoaiPhong == request.ID_LoaiPhong && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (loaiPhong == null)
            {
                return NotFound(new ApiNotFoundResponse($"{tieuDe} với id: {request.ID_LoaiPhong}  không tồn tại"));
            }
            loaiPhong.TenLoaiPhong = request.TenLoaiPhong;
            loaiPhong.AnhDaiDien = request.AnhDaiDien;
            loaiPhong.KichThuoc = request.KichThuoc;
            loaiPhong.TrangThai = request.TrangThai;
            loaiPhong.ModifyDate = DateTime.Now;
            loaiPhong.ModifyBy = infoUser.TenDangNhap;
            loaiPhong.ID_HuongNhin = request.ID_HuongNhin;
            loaiPhong.NguoiLon = request.NguoiLon;
            loaiPhong.TreEm = request.TreEm;
            loaiPhong.Index = request.Index;
            
            _context.LoaiPhongs.Update(loaiPhong);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                _context.NN_LoaiPhongs.RemoveRange(_context.NN_LoaiPhongs.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong).ToList());
                _context.SaveChanges();
                //thêm ngôn ngữ cho tiêu đề
                foreach (var item in request.NN_LoaiPhongRequests)
                {
                    var nn_loaiphong = new NN_LoaiPhong
                    {
                        ID_LoaiPhong = loaiPhong.ID_LoaiPhong,
                        Id_NgonNgu = item.ID_NgonNgu,
                        TenLoaiPhongTheoNgonNgu = item.TenLoaiPhongTheoNgonNgu,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false,

                    };
                    _context.NN_LoaiPhongs.Add(nn_loaiphong);
                    _context.SaveChanges();
                }
                //thêm tiện ích
                _context.LoaiPhong_TienIchs.RemoveRange(_context.LoaiPhong_TienIchs.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong).ToList());
                _context.SaveChanges();
                foreach (var item in request.LoaiPhong_TienIch_Requests)
                {
                    var loaiphong_tienich = new LoaiPhong_TienIch
                    {
                        ID_LoaiPhong = loaiPhong.ID_LoaiPhong,
                        Id_TienIch = item.ID_TienIch,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.LoaiPhong_TienIchs.Add(loaiphong_tienich);
                    _context.SaveChanges();
                }
                //Thêm loại giường
                _context.LoaiPhong_LoaiGiuongs.RemoveRange(_context.LoaiPhong_LoaiGiuongs.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong).ToList());
                _context.SaveChanges();
                foreach (var item in request.LoaiPhong_LoaiGiuong_Requests)
                {
                    var loaiphong_loaigiuong = new LoaiPhong_LoaiGiuong
                    {
                        ID_LoaiPhong = loaiPhong.ID_LoaiPhong,
                        Id_LoaiGiuong = item.ID_LoaiGiuong,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.LoaiPhong_LoaiGiuongs.Add(loaiphong_loaigiuong);
                    _context.SaveChanges();
                }

                //thêm gallery
                _context.LoaiPhong_Gallerys.RemoveRange(_context.LoaiPhong_Gallerys.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong).ToList());
                _context.SaveChanges();
                foreach (var item in request.loaiPhong_Gallery_Requests)
                {
                    var loaiphong_gallery = new LoaiPhong_Gallery
                    {
                        ID_LoaiPhong = loaiPhong.ID_LoaiPhong,
                        Url_Gallery = item.Url_Gallery,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.LoaiPhong_Gallerys.Add(loaiphong_gallery);
                    _context.SaveChanges();
                }
                return Ok(loaiPhong);
            }
            return BadRequest(new ApiBadRequestResponse("Cập nhật không thành công"));
        }

        [HttpDelete]
        [Route("xoa")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> DeleteLoaiGiuong(int id)
        {
            var loaiPhong =  _context.LoaiPhongs.Where(a=>a.ID_LoaiPhong == id && a.ID_KhachSan == infoUser.ID_KhachSan).OrderBy(a=>a.Index).FirstOrDefault();
            if (loaiPhong == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id} không tồn tại"));
            }
            loaiPhong.Delete = true;
            _context.LoaiPhongs.Update(loaiPhong);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                //Ngôn ngữ loại phòng
                _context.NN_LoaiPhongs.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong).ToList().ForEach(a => a.Delete = true);
                _context.SaveChanges();

                //Loại phòng gallery
                _context.LoaiPhong_Gallerys.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong).ToList().ForEach(a => a.Delete = true);
                _context.SaveChanges();

                //Loại phòng tiện ích
                _context.LoaiPhong_TienIchs.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong).ToList().ForEach(a => a.Delete = true);
                _context.SaveChanges();

                //Loại phòng loại giường
                _context.LoaiPhong_LoaiGiuongs.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong).ToList().ForEach(a => a.Delete = true);
                _context.SaveChanges();


                return Ok(new { kq = true });
            }
            return BadRequest(new ApiBadRequestResponse("Xóa loại giường không thành công"));
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnObject = new LoaiPhongVM();
            var loaiPhong =  _context.LoaiPhongs.Where(a=>a.ID_LoaiPhong == id && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (loaiPhong == null)
            {
                returnObject = new LoaiPhongVM
                {
                    ID_LoaiPhong = 0,
                    MaLoaiPhong = "",
                    TenLoaiPhong = "",
                    AnhDaiDien = "",
                    KichThuoc = "",
                    ID_HuongNhin = 0,
                    NguoiLon = 1,
                    TreEm = 0,
                    TrangThai = false,
                    NN_LoaiPhongVMs = new List<NN_LoaiPhongVM>(),
                    LoaiPhong_LoaiGiuongVMs = new List<LoaiPhong_LoaiGiuongVM>(),
                    LoaiPhong_TienIchVMs = new List<LoaiPhong_TienIchVM>(),
                    LoaiPhong_GalleryVMs = new List<LoaiPhong_GalleryVM>()
                };
                foreach (var item in _context.NgonNgus.ToList())
                {
                    NN_LoaiPhongVM nN_Object = new NN_LoaiPhongVM
                    {
                        ID_NgonNgu = item.ID_NgonNgu,
                        TenNgonNgu = _context.NgonNgus.FirstOrDefault(b => b.ID_NgonNgu == item.ID_NgonNgu).TieuDe,
                        TenLoaiPhongTheoNgonNgu = ""
                    };
                    returnObject.NN_LoaiPhongVMs.Add(nN_Object);
                }

                return Ok(returnObject);
            }
            returnObject = new LoaiPhongVM
            {
                ID_LoaiPhong = loaiPhong.ID_LoaiPhong,
                MaLoaiPhong = loaiPhong.MaLoaiPhong,
                TenLoaiPhong = loaiPhong.TenLoaiPhong,
                AnhDaiDien = loaiPhong.AnhDaiDien,
                KichThuoc = loaiPhong.KichThuoc,
                ID_HuongNhin = loaiPhong.ID_HuongNhin,
                NguoiLon = loaiPhong.NguoiLon,
                TreEm = loaiPhong.TreEm,
                TrangThai = loaiPhong.TrangThai,
                NN_LoaiPhongVMs = _context.NN_LoaiPhongs.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong)
                .Select(a => new NN_LoaiPhongVM
                {
                    ID_NgonNgu = a.Id_NgonNgu,
                    TenLoaiPhongTheoNgonNgu = a.TenLoaiPhongTheoNgonNgu,
                    TenNgonNgu = _context.NgonNgus.FirstOrDefault(b => b.ID_NgonNgu == a.Id_NgonNgu).TieuDe
                }).ToList(),

                LoaiPhong_LoaiGiuongVMs = _context.LoaiPhong_LoaiGiuongs.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong)
                .Select(a => new LoaiPhong_LoaiGiuongVM
                {
                    ID_LoaiGiuong = a.Id_LoaiGiuong,
                    TenLoaiGiuong = _context.LoaiGiuongs.FirstOrDefault(b => b.ID_LoaiGiuong == a.Id_LoaiGiuong).TieuDe

                }).ToList(),

                LoaiPhong_TienIchVMs = _context.LoaiPhong_TienIchs.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong)
                .Select(a => new LoaiPhong_TienIchVM
                {
                    ID_TienIch = a.Id_TienIch,
                    TenTienIch = _context.TienIchs.FirstOrDefault(b => b.ID_TienIch == a.Id_TienIch).TieuDe
                }).ToList(),

                LoaiPhong_GalleryVMs = _context.LoaiPhong_Gallerys.Where(a => a.ID_LoaiPhong == loaiPhong.ID_LoaiPhong)
                .Select(a => new LoaiPhong_GalleryVM
                {
                    Url_Gallery = a.Url_Gallery

                }).ToList()

            };

            return Ok(returnObject);
        }

    }
}
