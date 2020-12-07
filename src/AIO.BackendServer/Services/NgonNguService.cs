using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NgonNgu;
using AIO.ViewModels.NN_KhachSan;
using AIO.ViewModels.NN_TienIchMoRong;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class NgonNguService
    {
        private readonly ApplicationDbContext _context;

        public NgonNguService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<NgonNguVM>> DanhSach()
        {
            return await _context.NgonNgus.Select(a => new NgonNguVM
            {
                ModifyBy = a.ModifyBy,
                CreateBy = a.CreateBy,
                Delete = a.Delete,
                ID_NgonNgu = a.ID_NgonNgu,
                TenNgonNgu = a.TenNgonNgu,
            }
            ).ToListAsync();
        }

        public async Task<int> Sua(NgonNguRequest model)
        {

            NgonNgu ngonngu = _context.NgonNgus.Where(a => a.ID_NgonNgu == model.ID_NgonNgu).FirstOrDefault();
            if (ngonngu == null)
                throw new Exception("Ngôn ngữ không tồn tại.");
            ngonngu.ModifyBy = model.ModifyBy;
            ngonngu.CreateBy = model.CreateBy;
            ngonngu.Delete = model.Delete;
            ngonngu.ID_NgonNgu = model.ID_NgonNgu;
            ngonngu.TenNgonNgu = model.TenNgonNgu;
            ngonngu.ModifyDate = DateTime.Now;

            _context.NgonNgus.Update(ngonngu);
            await _context.SaveChangesAsync();
            return ngonngu.ID_NgonNgu;
        }

        public async Task<int> Them(NgonNguRequest model)
        {
            NgonNgu ngonngu = new NgonNgu();

            ngonngu.ModifyBy = model.ModifyBy;
            ngonngu.CreateBy = model.CreateBy;
            ngonngu.Delete = model.Delete;
            ngonngu.ID_NgonNgu = model.ID_NgonNgu;
            ngonngu.TenNgonNgu = model.TenNgonNgu;
            ngonngu.CreateDate = DateTime.Now;
            _context.NgonNgus.Add(ngonngu);
            await _context.SaveChangesAsync();
            return ngonngu.ID_NgonNgu;
        }

        public async Task<int> Xoa(int id)
        {
            NgonNgu ngonngu = _context.NgonNgus.Where(a => a.ID_NgonNgu == id).FirstOrDefault();
            if (ngonngu == null)
                throw new Exception("Ngôn ngữ không tồn tại.");
            ngonngu.Delete = true;
            _context.NgonNgus.Update(ngonngu);
            await _context.SaveChangesAsync();
            return ngonngu.ID_NgonNgu;
        }
    }
}