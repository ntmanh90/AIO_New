using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class CongTyService : ICongTyService
    {
        private readonly ApplicationDbContext _context;

        public CongTyService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<CongTyVM> ChiTietCongTy(int id)
        {
            var Congty = await _context.CongTys.Where(a => a.ID_CongTy == id).Select(a => new CongTyVM
            {
                ID_CongTy = a.ID_CongTy,
                AnhDaiDien = a.AnhDaiDien,
                CreateBy = a.CreateBy,
                CreateDate = a.CreateDate,
                Delete = a.Delete,
            }).FirstOrDefaultAsync();
            return Congty;
        }
        
        public async Task<List<CongTyVM>> DanhSachCongTy()
        {
            return await _context.CongTys.Select(a => new CongTyVM
            {
                ID_CongTy = a.ID_CongTy,
                AnhDaiDien = a.AnhDaiDien,
                CreateBy = a.CreateBy,
                CreateDate = a.CreateDate,
                Delete = a.Delete,
            }
            ).ToListAsync();
        }

        public async Task<int> SuaCongTy(CongTyRequest model)
        {

            CongTy detailCompany = _context.CongTys.Where(a => a.ID_CongTy == model.ID_CongTy).FirstOrDefault();
            if (detailCompany == null)

            throw new Exception("Công ty không tồn tại.");


            detailCompany.TenCongTy = model.TenCongTy;
            detailCompany.DiaChiCongTy = model.DiaChiCongTy;
            detailCompany.MaCongTy = model.MaCongTy;
            detailCompany.EmailCongTy = model.EmailCongTy;
            detailCompany.NguoiDaiDien = model.NguoiDaiDien;
            detailCompany.Hotline = model.Hotline;
            detailCompany.DienThoaiBan = model.DienThoaiBan;
            detailCompany.SoDiDong = model.SoDiDong;
            detailCompany.Note = model.Note;
            detailCompany.CreateDate = DateTime.Now;
            detailCompany.LastModifiedDate = DateTime.Now;
            detailCompany.Delete = false;
            detailCompany.ModifyBy = model.ModifyBy;
            detailCompany.AnhDaiDien = model.AnhDaiDien;
            detailCompany.CreateBy = model.CreateBy;
            detailCompany.TrangThai = model.TrangThai;

            _context.CongTys.Update(detailCompany);
            await _context.SaveChangesAsync();
            return detailCompany.ID_CongTy;
        }

        public async Task<int> ThemCongTy(CongTyRequest model)
        {
            CongTy congty = new CongTy();

            congty.TenCongTy = model.TenCongTy;
            congty.DiaChiCongTy = model.DiaChiCongTy;
            congty.MaCongTy = model.MaCongTy;
            congty.EmailCongTy = model.EmailCongTy;
            congty.NguoiDaiDien = model.NguoiDaiDien;
            congty.Hotline = model.Hotline;
            congty.DienThoaiBan = model.DienThoaiBan;
            congty.SoDiDong = model.SoDiDong;
            congty.Note = model.Note;
            congty.CreateDate = DateTime.Now;
            congty.LastModifiedDate = DateTime.Now;
            congty.Delete = false;
            congty.ModifyBy = model.ModifyBy;
            congty.AnhDaiDien = model.AnhDaiDien;
            congty.CreateBy = model.CreateBy;
            congty.TrangThai = model.TrangThai;

            _context.CongTys.Add(congty);
            await _context.SaveChangesAsync();
            return congty.ID_CongTy;
        }

        public async Task<int> XoaCongTy(int id)
        {
            CongTy detailCompany = _context.CongTys.Where(a => a.ID_CongTy == id).FirstOrDefault();
            if (detailCompany == null)
                throw new Exception("Công ty không tồn tại.");

            detailCompany.Delete = true;
            _context.CongTys.Update(detailCompany);
            await _context.SaveChangesAsync();
            return detailCompany.ID_CongTy;
        }
    }
}