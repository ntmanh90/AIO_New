using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.KhachSan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class KhachSanService
    {
        private readonly ApplicationDbContext _context;

        public KhachSanService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<KhachSanVM> ChiTietKhachSan(int id_khachsan)
        {
            var Congty = await _context.KhachSans.Where(a => a.ID_KhachSan == id_khachsan).Select(a => new KhachSanVM
            {
                ID_KhachSan = a.ID_KhachSan,
                TenKhachSan = a.TenKhachSan,
                CreateBy = a.CreateBy,
                CreateDate = a.CreateDate,
                Delete = a.Delete,
                DiaChiKhachSan = a.DiaChiKhachSan,
                Email = a.Email,
                Facebook = a.Facebook,
                Hotline = a.Hotline,
                LastModifiedDate = a.LastModifiedDate,
                MaKhachSan = a.MaKhachSan,
                ModifyBy = a.ModifyBy,
                SoDiDong = a.SoDiDong,
                SoFax = a.SoFax,
                SoMayBan = a.SoMayBan,
                TrangThai = a.TrangThai,
                Twitter = a.Twitter,
                Website = a.Website,
                Youtube = a.Youtube,
                Instagram   = a.Instagram,
                GioiThieu = a.GioiThieu,
                ViTri = a.ViTri,

            }).FirstOrDefaultAsync();
            return Congty;
        }

        public async Task<List<KhachSanVM>> DanhSachKhachSan()
        {
            return await _context.KhachSans.Select(a => new KhachSanVM
            {
                ID_KhachSan = a.ID_KhachSan,
                TenKhachSan = a.TenKhachSan,
                CreateBy = a.CreateBy,
                CreateDate = a.CreateDate,
                Delete = a.Delete,
                DiaChiKhachSan = a.DiaChiKhachSan,
                Email = a.Email,
                Facebook = a.Facebook,
                Hotline = a.Hotline,
                LastModifiedDate = a.LastModifiedDate,
                MaKhachSan = a.MaKhachSan,
                ModifyBy = a.ModifyBy,
                SoDiDong = a.SoDiDong,
                SoFax = a.SoFax,
                SoMayBan = a.SoMayBan,
                TrangThai = a.TrangThai,
                Twitter = a.Twitter,
                Website = a.Website,
                Youtube = a.Youtube,
                Instagram = a.Instagram,
                GioiThieu = a.GioiThieu,
                ViTri = a.ViTri,
            }
            ).ToListAsync();
        }

        public async Task<int> SuaKhachSan(CauHinhKhachSanRequiter khachsan)
        {

            KhachSan detailKhachSan = _context.KhachSans.Where(a => a.ID_KhachSan == khachsan.ID_KhachSan).FirstOrDefault();
            if (detailKhachSan == null)

                throw new Exception("Công ty không tồn tại.");


            //detailKhachSan.ID_KhachSan = khachsan.ID_KhachSan;
            detailKhachSan.TenKhachSan = khachsan.TenKhachSan;
            detailKhachSan.LogoKhachSan = khachsan.LogoKhachSan;
            detailKhachSan.CreateBy = khachsan.CreateBy;
            detailKhachSan.CreateDate = DateTime.Now;
            detailKhachSan.Delete = khachsan.Delete;
            detailKhachSan.DiaChiKhachSan = khachsan.DiaChiKhachSan;
            detailKhachSan.Email = khachsan.Email;
            detailKhachSan.Facebook = khachsan.Facebook;
            detailKhachSan.Hotline = khachsan.Hotline;
            detailKhachSan.LastModifiedDate = DateTime.Now;
            detailKhachSan.MaKhachSan = khachsan.MaKhachSan;
            detailKhachSan.ModifyBy = khachsan.ModifyBy;
            detailKhachSan.SoDiDong = khachsan.SoDiDong;
            detailKhachSan.SoFax = khachsan.SoFax;
            detailKhachSan.SoMayBan = khachsan.SoMayBan;
            detailKhachSan.TrangThai = khachsan.TrangThai;
            detailKhachSan.Twitter = khachsan.Twitter;
            detailKhachSan.Website = khachsan.Website;
            detailKhachSan.Youtube = khachsan.Youtube;
            detailKhachSan.Instagram = khachsan.Instagram;
            detailKhachSan.GioiThieu = khachsan.GioiThieu;
            detailKhachSan.ViTri = khachsan.ViTri;

            _context.KhachSans.Update(detailKhachSan);
            await _context.SaveChangesAsync();
            return detailKhachSan.ID_KhachSan;
        }

        public async Task<int> ThemKhachSan(CauHinhKhachSanRequiter khachsan)
        {
            KhachSan khachsanadd = new KhachSan();

            //khachsanadd.ID_KhachSan = khachsan.ID_KhachSan;
            khachsanadd.TenKhachSan = khachsan.TenKhachSan;
            khachsanadd.CreateBy = khachsan.CreateBy;
            khachsanadd.LogoKhachSan = khachsan.LogoKhachSan;
            khachsanadd.CreateDate = DateTime.Now;
            khachsanadd.Delete = khachsan.Delete;
            khachsanadd.DiaChiKhachSan = khachsan.DiaChiKhachSan;
            khachsanadd.Email = khachsan.Email;
            khachsanadd.Facebook = khachsan.Facebook;
            khachsanadd.Hotline = khachsan.Hotline;
            khachsanadd.LastModifiedDate = DateTime.Now;
            khachsanadd.MaKhachSan = khachsan.MaKhachSan;
            khachsanadd.ModifyBy = khachsan.ModifyBy;
            khachsanadd.SoDiDong = khachsan.SoDiDong;
            khachsanadd.SoFax = khachsan.SoFax;
            khachsanadd.SoMayBan = khachsan.SoMayBan;
            khachsanadd.TrangThai = khachsan.TrangThai;
            khachsanadd.Twitter = khachsan.Twitter;
            khachsanadd.Website = khachsan.Website;
            khachsanadd.Youtube = khachsan.Youtube;
            khachsanadd.Instagram = khachsan.Instagram;
            khachsanadd.GioiThieu = khachsan.GioiThieu;
            khachsanadd.ViTri = khachsan.ViTri;
            _context.KhachSans.Add(khachsanadd);
            await _context.SaveChangesAsync();
            return khachsanadd.ID_KhachSan;
        }

        public async Task<int> XoaKhachSan(int id)
        {
            KhachSan khachsan = _context.KhachSans.Where(a => a.ID_KhachSan == id).FirstOrDefault();
            if (khachsan == null)
                throw new Exception("Công ty không tồn tại.");

            khachsan.Delete = true;
            _context.KhachSans.Update(khachsan);
            await _context.SaveChangesAsync();
            return khachsan.ID_KhachSan;
        }
    }
}