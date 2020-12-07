using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CauHinhKhachSan;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.KhachSan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class CauHinhKhachSanService
    {
        private readonly ApplicationDbContext _context;

        public CauHinhKhachSanService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<CauHinhKhachSanVM>> DanhSachCauHinh()
        {
            return await _context.CauHinhKhachSans.Select(a => new CauHinhKhachSanVM
            {
                CreateBy = a.CreateBy,
                Delete = a.Delete,
                EmailNhanPhong = a.EmailNhanPhong,
                EmailNhanThongBao = a.EmailNhanThongBao,
                ID = a.ID,
                KyHieuDatPhong = a.KyHieuDatPhong,
                ModifyBy = a.ModifyBy,
                TrangThai = a.TrangThai,
            }).ToListAsync();
        }

        public async Task<int> SuaCauHinhKhachSan(CauHinhKhachSanRequest cauhinh)
        {

            CauHinhKhachSan detailCauHinh = _context.CauHinhKhachSans.Where(a => a.ID == cauhinh.ID).FirstOrDefault();
            if (detailCauHinh == null)

                throw new Exception("Không tồn tại cấu hình khách sạn.");

            detailCauHinh.KyHieuDatPhong = cauhinh.KyHieuDatPhong;
            detailCauHinh.EmailNhanThongBao = cauhinh.EmailNhanThongBao;
            detailCauHinh.EmailNhanPhong = cauhinh.EmailNhanPhong;
            detailCauHinh.LastModifiedDate = DateTime.Now;
            detailCauHinh.ModifyBy = cauhinh.ModifyBy;
            detailCauHinh.Delete = cauhinh.Delete;
            detailCauHinh.TrangThai = cauhinh.TrangThai;
            _context.CauHinhKhachSans.Update(detailCauHinh);
            await _context.SaveChangesAsync();
            return detailCauHinh.ID;
        }

        public async Task<int> ThemCauHinhKhachSan(CauHinhKhachSanRequest cauhinh)
        {
            CauHinhKhachSan khachsanadd = new CauHinhKhachSan();

            khachsanadd.KyHieuDatPhong = cauhinh.KyHieuDatPhong;
            khachsanadd.EmailNhanThongBao = cauhinh.EmailNhanThongBao;
            khachsanadd.EmailNhanPhong = cauhinh.EmailNhanPhong;
            khachsanadd.LastModifiedDate = DateTime.Now;
            khachsanadd.CreateBy = cauhinh.CreateBy;
            khachsanadd.CreateDate = DateTime.Now;
            khachsanadd.ModifyBy = cauhinh.ModifyBy;
            khachsanadd.Delete = cauhinh.Delete;
            khachsanadd.TrangThai = cauhinh.TrangThai;
            _context.CauHinhKhachSans.Add(khachsanadd);
            await _context.SaveChangesAsync();
            return khachsanadd.ID;
        }

        public async Task<int> XoaCauHinhKhachSan(int id)
        {
            CauHinhKhachSan cauhinhkhachsan = _context.CauHinhKhachSans.Where(a => a.ID == id).FirstOrDefault();
            if (cauhinhkhachsan == null)
                throw new Exception("Cấu hình khách sạn không tồn tại.");

            cauhinhkhachsan.Delete = true;
            _context.CauHinhKhachSans.Update(cauhinhkhachsan);
            await _context.SaveChangesAsync();
            return cauhinhkhachsan.ID;
        }
    }
}