﻿using System;
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
using AIO.ViewModels.Systems.KhuyenMaiDatPhong;

namespace AIO.BackendServer.Controllers
{
    public class KhuyenMaiDatPhongController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly string tieuDe = "khuyến mại đặt phòng";
        InfoUser infoUser = new InfoUser();

        public KhuyenMaiDatPhongController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("them")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> Post([FromBody] KhuyenMaiDatPhongRequest request)
        {
            var max_id = _context.KhuyenMaiDatPhongs.Any() ? _context.KhuyenMaiDatPhongs.Max(a => a.ID_KhuyenMaiDatPhong) : 0;
            // thêm thông tin
            var khuyenmaidatphong = new KhuyenMaiDatPhong()
            {
                TenKhuyenMaiDatPhong = request.TenKhuyenMaiDatPhong,
                SoNgayLuuTruToiThieu = request.SoNgayLuuTruToiThieu,
                SoNgayDatTruoc = request.SoNgayDatTruoc,
                GiaCongThem = request.GiaCongThem,
                PhanTramGiamGia = request.PhanTramGiamGia,
                PhanTramDatCoc = request.PhanTramDatCoc,
                BaoGomAnSang = request.BaoGomAnSang,
                DuocPhepHuy = request.DuocPhepHuy,
                DuocPhepThayDoi = request.DuocPhepThayDoi,
                NgayBatDau = request.NgayBatDau,
                NgayKetThuc = request.NgayKetThuc,
                TatCaNgayTrongTuan = request.TatCaNgayTrongTuan,
                ThuHai = request.ThuHai,
                ThuBa = request.ThuBa,
                ThuTu = request.ThuTu,
                ThuNam = request.ThuNam,
                ThuSau = request.ThuSau,
                ThuBay = request.ThuBay,
                ChuNhat = request.ChuNhat,
                TrangThai = request.TrangThai,

                MaKhuyenMaiDatPhong = infoUser.KyHieuKhachSan.Trim() + IdGenerator.NextId_KhuyenMaiDatPhong(max_id),
                ID_KhachSan = infoUser.ID_KhachSan,
                CreateBy = infoUser.TenDangNhap,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                ModifyBy = "",
                Delete = false

            };
            _context.KhuyenMaiDatPhongs.Add(khuyenmaidatphong);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                //thêm ngôn ngữ 
                foreach (var item in request.NN_KhuyenMaiDatPhongRequests)
                {
                    var nn_khuyenmaidatphong = new NN_KhuyenMaiDatPhong
                    {
                        ID_KhuyenMaiDatPhong = khuyenmaidatphong.ID_KhuyenMaiDatPhong,
                        Id_NgonNgu = item.ID_NgonNgu,
                        TenTheoNgonNgu = item.TenTheoNgonNgu,
                        DieuKhoan_DieuKien = item.DieuKhoan_DieuKien,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.NN_KhuyenMaiDatPhongs.Add(nn_khuyenmaidatphong);
                    _context.SaveChanges();
                }

                return Ok(khuyenmaidatphong);
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
            var result = await _context.KhuyenMaiDatPhongs.Where(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.Delete == DeleteStatus.ChuaXoa)
                .Select(a => new KhuyenMaiDatPhongListVM
                {
                    ID_KhuyenMaiDatPhong = a.ID_KhuyenMaiDatPhong,
                    MaKhuyenMaiDatPhong = a.MaKhuyenMaiDatPhong,
                    TenKhuyenMaiDatPhong = a.TenKhuyenMaiDatPhong,
                    SoNgayLuuTruToiThieu = a.SoNgayLuuTruToiThieu,
                    SoNgayDatTruoc = a.SoNgayDatTruoc,
                    GiaCongThem = a.GiaCongThem,
                    PhanTramGiamGia = a.PhanTramGiamGia,
                    PhanTramDatCoc = a.PhanTramDatCoc,
                    BaoGomAnSang = a.BaoGomAnSang,
                    DuocPhepHuy = a.DuocPhepHuy,
                    DuocPhepThayDoi = a.DuocPhepThayDoi,
                    NgayBatDau = a.NgayBatDau,
                    NgayKetThuc = a.NgayKetThuc,
                    TrangThai = a.TrangThai

                }).AsQueryable().ToListAsync();
            return Ok(result);
        }

        [Route("sua")]
        [HttpPut]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        [ApiValidationFilter]
        public async Task<IActionResult> Put([FromBody] KhuyenMaiDatPhongRequest request)
        {
            var khuyenmaidatphong = _context.KhuyenMaiDatPhongs.Where(a => a.ID_KhuyenMaiDatPhong == request.ID_KhuyenMaiDatPhong && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (khuyenmaidatphong == null)
            {
                return NotFound(new ApiNotFoundResponse($"{tieuDe} với id: {request.ID_KhuyenMaiDatPhong}  không tồn tại"));
            }

            khuyenmaidatphong.TenKhuyenMaiDatPhong = request.TenKhuyenMaiDatPhong;
            khuyenmaidatphong.SoNgayLuuTruToiThieu = request.SoNgayLuuTruToiThieu;
            khuyenmaidatphong.SoNgayDatTruoc = request.SoNgayDatTruoc;
            khuyenmaidatphong.GiaCongThem = request.GiaCongThem;
            khuyenmaidatphong.PhanTramGiamGia = request.PhanTramGiamGia;
            khuyenmaidatphong.PhanTramDatCoc = request.PhanTramDatCoc;
            khuyenmaidatphong.BaoGomAnSang = request.BaoGomAnSang;
            khuyenmaidatphong.DuocPhepHuy = request.DuocPhepHuy;
            khuyenmaidatphong.DuocPhepThayDoi = request.DuocPhepThayDoi;
            khuyenmaidatphong.NgayBatDau = request.NgayBatDau;
            khuyenmaidatphong.NgayKetThuc = request.NgayKetThuc;
            khuyenmaidatphong.TatCaNgayTrongTuan = request.TatCaNgayTrongTuan;
            khuyenmaidatphong.ThuHai = request.ThuHai;
            khuyenmaidatphong.ThuBa = request.ThuBa;
            khuyenmaidatphong.ThuTu = request.ThuTu;
            khuyenmaidatphong.ThuNam = request.ThuNam;
            khuyenmaidatphong.ThuSau = request.ThuSau;
            khuyenmaidatphong.ThuBay = request.ThuBay;
            khuyenmaidatphong.ChuNhat = request.ChuNhat;
            khuyenmaidatphong.TrangThai = request.TrangThai;


            _context.KhuyenMaiDatPhongs.Update(khuyenmaidatphong);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                _context.NN_KhuyenMaiDatPhongs.RemoveRange(_context.NN_KhuyenMaiDatPhongs.Where(a => a.ID_KhuyenMaiDatPhong == khuyenmaidatphong.ID_KhuyenMaiDatPhong).ToList());
                _context.SaveChanges();
                //thêm ngôn ngữ 
                foreach (var item in request.NN_KhuyenMaiDatPhongRequests)
                {
                    var nn_khuyenmaidatphong = new NN_KhuyenMaiDatPhong
                    {
                        ID_KhuyenMaiDatPhong = khuyenmaidatphong.ID_KhuyenMaiDatPhong,
                        Id_NgonNgu = item.ID_NgonNgu,
                        TenTheoNgonNgu = item.TenTheoNgonNgu,
                        DieuKhoan_DieuKien = item.DieuKhoan_DieuKien,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.NN_KhuyenMaiDatPhongs.Add(nn_khuyenmaidatphong);
                    _context.SaveChanges();
                }

                return Ok(khuyenmaidatphong);
            }
            return BadRequest(new ApiBadRequestResponse("Cập nhật không thành công"));
        }

        [HttpDelete]
        [Route("xoa")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var khuyenmaidatphong = _context.KhuyenMaiDatPhongs.Where(a => a.ID_KhuyenMaiDatPhong == id && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (khuyenmaidatphong == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id} không tồn tại"));
            }
            khuyenmaidatphong.Delete = true;
            _context.KhuyenMaiDatPhongs.Update(khuyenmaidatphong);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                //Ngôn ngữ 
                _context.NN_KhuyenMaiDatPhongs.Where(a => a.ID_KhuyenMaiDatPhong == khuyenmaidatphong.ID_KhuyenMaiDatPhong).ToList().ForEach(a => a.Delete = true);
                _context.SaveChanges();

                return Ok(new { kq = true });
            }
            return BadRequest(new ApiBadRequestResponse($"Xóa {tieuDe} không thành công"));
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnObject = new KhuyenMaiDatPhongVM();
            var khuyenmaidatphong = _context.KhuyenMaiDatPhongs.Where(a => a.ID_KhuyenMaiDatPhong == id && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (khuyenmaidatphong == null)
            {
                returnObject = new KhuyenMaiDatPhongVM
                {
                    TenKhuyenMaiDatPhong = "",
                    SoNgayLuuTruToiThieu =0,
                    SoNgayDatTruoc = 0,
                    GiaCongThem = 0,
                    PhanTramGiamGia = 0,
                    PhanTramDatCoc = 0,
                    BaoGomAnSang = false,
                    DuocPhepHuy = false,
                    DuocPhepThayDoi =false,
                    NgayBatDau = DateTime.Now,
                    NgayKetThuc = DateTime.Now,
                    TatCaNgayTrongTuan = false,
                    ThuHai = false,
                    ThuBa = false,
                    ThuTu = false,
                    ThuNam = false,
                    ThuSau = false,
                    ThuBay = false,
                    ChuNhat = false,
                    TrangThai = false,

                    NN_KhuyenMaiDatPhongVMs = new List<NN_KhuyenMaiDatPhongVM>()
                };
                foreach (var item in _context.NgonNgus.ToList())
                {
                    NN_KhuyenMaiDatPhongVM nN_Object = new NN_KhuyenMaiDatPhongVM
                    {
                        ID_NgonNgu = item.ID_NgonNgu,
                        TenNgonNgu = _context.NgonNgus.FirstOrDefault(b => b.ID_NgonNgu == item.ID_NgonNgu).TieuDe,
                        TenTheoNgonNgu = "",
                        DieuKhoan_DieuKien = ""
                    };
                    returnObject.NN_KhuyenMaiDatPhongVMs.Add(nN_Object);
                }

                return Ok(returnObject);
            }
            returnObject = new KhuyenMaiDatPhongVM
            {
                TenKhuyenMaiDatPhong = khuyenmaidatphong.TenKhuyenMaiDatPhong,
                SoNgayLuuTruToiThieu = khuyenmaidatphong.SoNgayLuuTruToiThieu,
                SoNgayDatTruoc = khuyenmaidatphong.SoNgayDatTruoc,
                GiaCongThem = khuyenmaidatphong.GiaCongThem,
                PhanTramGiamGia = khuyenmaidatphong.PhanTramGiamGia,
                PhanTramDatCoc = khuyenmaidatphong.PhanTramDatCoc,
                BaoGomAnSang = khuyenmaidatphong.BaoGomAnSang,
                DuocPhepHuy = khuyenmaidatphong.DuocPhepHuy,
                DuocPhepThayDoi = khuyenmaidatphong.DuocPhepThayDoi,
                NgayBatDau = khuyenmaidatphong.NgayBatDau,
                NgayKetThuc = khuyenmaidatphong.NgayKetThuc,
                TatCaNgayTrongTuan = khuyenmaidatphong.TatCaNgayTrongTuan,
                ThuHai = khuyenmaidatphong.ThuHai,
                ThuBa = khuyenmaidatphong.ThuBa,
                ThuTu = khuyenmaidatphong.ThuTu,
                ThuNam = khuyenmaidatphong.ThuNam,
                ThuSau = khuyenmaidatphong.ThuSau,
                ThuBay = khuyenmaidatphong.ThuBay,
                ChuNhat = khuyenmaidatphong.ChuNhat,
                TrangThai = khuyenmaidatphong.TrangThai,

                NN_KhuyenMaiDatPhongVMs = _context.NN_KhuyenMaiDatPhongs.Where(a => a.ID_KhuyenMaiDatPhong == khuyenmaidatphong.ID_KhuyenMaiDatPhong)
                .Select(a => new NN_KhuyenMaiDatPhongVM
                {
                    ID_NgonNgu = a.Id_NgonNgu,
                    TenTheoNgonNgu = a.TenTheoNgonNgu,
                    DieuKhoan_DieuKien = a.DieuKhoan_DieuKien,
                    TenNgonNgu = _context.NgonNgus.FirstOrDefault(b => b.ID_NgonNgu == a.Id_NgonNgu).TieuDe
                }).ToList(),
            };

            return Ok(returnObject);
        }

    }
}