using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class LoaiPhongService
    {
        private readonly ApplicationDbContext _context;

        public LoaiPhongService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
     
        public async Task<List<LoaiPhongVM>> DanhSach()
        {
            return await _context.LoaiPhongs.Select(a => new LoaiPhongVM
            {
                  Delete = a.Delete,
                  DiaChiKhachSan = a.DiaChiKhachSan,
                  Email = a.Email,
                  Facebook = a.Facebook,
                  Hotline = a.Hotline,
                  ID = a.ID,
                  Instagram = a.Instagram,
                  LogoKhachSan = a.LogoKhachSan,
                  SoDiDong = a.SoDiDong,
                  SoFax = a.SoFax,
                  SoMayBan = a.SoMayBan,
                  TenLoaiPhongTA = a.TenLoaiPhongTA,
                  TenLoaiPhongTV = a.TenLoaiPhongTV,
                  TrangThai = a.TrangThai,
                  Twitter = a.Twitter,
                  Website= a.Website,
                  Youtube  = a.Youtube,                   
            }
            ).ToListAsync();
        }

        public async Task<int> Sua(LoaiPhongRequest model)
        {

            LoaiPhong loaiPhong = _context.LoaiPhongs.Where(a => a.ID == model.ID).FirstOrDefault();
            if (loaiPhong == null)
            throw new Exception("Loại phòng không tồn tại.");

            loaiPhong.Instagram = model.Instagram;
            loaiPhong.LogoKhachSan = model.LogoKhachSan;
            loaiPhong.LastModifiedDate = DateTime.Now;
            loaiPhong.LogoKhachSan = model.LogoKhachSan;
            loaiPhong.SoDiDong = model.SoDiDong;
            loaiPhong.SoFax = model.SoFax;
            loaiPhong.SoMayBan = model.SoMayBan;
            loaiPhong.TenLoaiPhongTA = model.TenLoaiPhongTA;
            loaiPhong.TenLoaiPhongTV = model.TenLoaiPhongTV;
            loaiPhong.TrangThai = model.TrangThai;
            loaiPhong.Twitter = model.Twitter;
            loaiPhong.Website = model.Website;
            loaiPhong.Youtube = model.Youtube;
            _context.LoaiPhongs.Update(loaiPhong);
            await _context.SaveChangesAsync();
            return loaiPhong.ID;
        }

        public async Task<int> Them(LoaiPhongRequest model)
        {
            LoaiPhong phong = new LoaiPhong();

            phong.Instagram = model.Instagram;
            phong.LogoKhachSan = model.LogoKhachSan;
            phong.CreateDate = DateTime.Now;
            phong.LogoKhachSan = model.LogoKhachSan;
            phong.SoDiDong = model.SoDiDong;
            phong.SoFax = model.SoFax;
            phong.SoMayBan = model.SoMayBan;
            phong.TenLoaiPhongTA = model.TenLoaiPhongTA;
            phong.TenLoaiPhongTV = model.TenLoaiPhongTV;
            phong.TrangThai = model.TrangThai;
            phong.Twitter = model.Twitter;
            phong.Website = model.Website;
            phong.Youtube = model.Youtube;

            _context.LoaiPhongs.Add(phong);
            await _context.SaveChangesAsync();
            return phong.ID;
        }

        public async Task<int> Xoa(int id)
        {
            LoaiPhong loaiphong = _context.LoaiPhongs.Where(a => a.ID == id).FirstOrDefault();
            if (loaiphong == null)
                throw new Exception("Loại phòng không tồn tại.");

            loaiphong.Delete = true;
            _context.LoaiPhongs.Update(loaiphong);
            await _context.SaveChangesAsync();
            return loaiphong.ID;
        }
    }
}