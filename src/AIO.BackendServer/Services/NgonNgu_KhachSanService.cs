using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NgonNgu;
using AIO.ViewModels.NgonNgu_KhachSan;
using AIO.ViewModels.NN_KhachSan;
using AIO.ViewModels.NN_TienIchMoRong;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class NgonNgu_KhachSanService
    {
        private readonly ApplicationDbContext _context;

        public NgonNgu_KhachSanService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<NgonNgu_KhachSanVM>> DanhSach()
        {
            return await _context.NgonNgu_KhachSans.Select(a => new NgonNgu_KhachSanVM
            {
                ID_NgonNgu = a.ID_NgonNgu,
                Delete = a.Delete,
                CreateBy = a.CreateBy,
                ModifyBy = a.ModifyBy,
                ID_KhachSan = a.ID_KhachSan,
                MacDinh = a.MacDinh,
                TrangThai = a.TrangThai,
            }
            ).ToListAsync();
        }

        public async Task<int> Sua(NgonNgu_KhachSanRequest model)
        {

            NgonNgu_KhachSan ngonngu_khachsan = _context.NgonNgu_KhachSans.Where(a => a.ID_KhachSan == model.ID_NgonNgu).FirstOrDefault();
            if (ngonngu_khachsan == null)
                throw new Exception("Ngôn ngữ khách sạn không tồn tại.");
            ngonngu_khachsan.ID_NgonNgu = model.ID_NgonNgu;
            ngonngu_khachsan.Delete = model.Delete;
            ngonngu_khachsan.CreateBy = model.CreateBy;
            ngonngu_khachsan.ModifyBy = model.ModifyBy;
            ngonngu_khachsan.ID_KhachSan = model.ID_KhachSan;
            ngonngu_khachsan.MacDinh = model.MacDinh;
            ngonngu_khachsan.TrangThai = model.TrangThai;
            ngonngu_khachsan.LastModifiedDate =DateTime.Now;
            _context.NgonNgu_KhachSans.Update(ngonngu_khachsan);
            await _context.SaveChangesAsync();
            return ngonngu_khachsan.ID_KhachSan;
        }

        public async Task<int> Them(NgonNgu_KhachSanRequest model)
        {
            NgonNgu_KhachSan ngonngu_khachsan = new NgonNgu_KhachSan();

            ngonngu_khachsan.ID_NgonNgu = model.ID_NgonNgu;
            ngonngu_khachsan.Delete = model.Delete;
            ngonngu_khachsan.CreateBy = model.CreateBy;
            ngonngu_khachsan.ModifyBy = model.ModifyBy;
            ngonngu_khachsan.ID_KhachSan = model.ID_KhachSan;
            ngonngu_khachsan.MacDinh = model.MacDinh;
            ngonngu_khachsan.TrangThai = model.TrangThai;
            ngonngu_khachsan.CreateDate = DateTime.Now;
            _context.NgonNgu_KhachSans.Add(ngonngu_khachsan);
            await _context.SaveChangesAsync();
            return ngonngu_khachsan.ID_KhachSan;
        }

        public async Task<int> Xoa(int id)
        {
            NgonNgu_KhachSan ngonngu_khachsan = _context.NgonNgu_KhachSans.Where(a => a.ID_NgonNgu == id).FirstOrDefault();
            if (ngonngu_khachsan == null)
                throw new Exception("Ngôn ngức khách sạn không tồn tại.");
            ngonngu_khachsan.Delete = true;
            _context.NgonNgu_KhachSans.Update(ngonngu_khachsan);
            await _context.SaveChangesAsync();
            return ngonngu_khachsan.ID_KhachSan;
        }
    }
}