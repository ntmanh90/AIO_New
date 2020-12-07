using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NN_KhachSan;
using AIO.ViewModels.NN_TienIchMoRong;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class NN_TienIchMoRongService
    {
        private readonly ApplicationDbContext _context;

        public NN_TienIchMoRongService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
     
        public async Task<List<NN_TienIchMoRongVM>> DanhSach()
        {
            return await _context.NN_TienIchMoRongs.Select(a => new NN_TienIchMoRongVM
            {
                 CreateBy =a.CreateBy,
                 Delete =a.Delete,
                 ID_CongTy = a.ID_CongTy,
                 Id_NgonNgu = a.Id_NgonNgu,
                 ID_TienichMoRong = a.ID_TienichMoRong,
                 ModifyBy =a.ModifyBy,
                 NoiDungHienThi = a.NoiDungHienThi
            }
            ).ToListAsync();
        }

        public async Task<int> Sua(NN_TienIchMoRongRequest model)
        {

            NN_TienIchMoRong NN_TienIchMoRong = _context.NN_TienIchMoRongs.Where(a => a.ID_TienichMoRong == model.ID_TienichMoRong).FirstOrDefault();
            if (NN_TienIchMoRong == null)
            throw new Exception("Tiện ích mở rộng không tồn tại.");

            NN_TienIchMoRong.CreateBy = model.CreateBy;
            NN_TienIchMoRong.Delete = model.Delete;
            NN_TienIchMoRong.ID_CongTy = model.ID_CongTy;
            NN_TienIchMoRong.Id_NgonNgu = model.Id_NgonNgu;
            NN_TienIchMoRong.ID_TienichMoRong = model.ID_TienichMoRong;
            NN_TienIchMoRong.ModifyBy = model.ModifyBy;
            NN_TienIchMoRong.NoiDungHienThi = model.NoiDungHienThi;
            NN_TienIchMoRong.LastModifiedDate = DateTime.Now;

            _context.NN_TienIchMoRongs.Update(NN_TienIchMoRong);
            await _context.SaveChangesAsync();
            return NN_TienIchMoRong.ID_TienichMoRong;
        }

        public async Task<int> Them(NN_TienIchMoRongRequest model)
        {
            NN_TienIchMoRong NN_TienIchMoRong = new NN_TienIchMoRong();

            NN_TienIchMoRong.CreateBy = model.CreateBy;
            NN_TienIchMoRong.Delete = model.Delete;
            NN_TienIchMoRong.ID_CongTy = model.ID_CongTy;
            NN_TienIchMoRong.Id_NgonNgu = model.Id_NgonNgu;
            NN_TienIchMoRong.ID_TienichMoRong = model.ID_TienichMoRong;
            NN_TienIchMoRong.ModifyBy = model.ModifyBy;
            NN_TienIchMoRong.NoiDungHienThi = model.NoiDungHienThi;
            NN_TienIchMoRong.CreateDate = DateTime.Now;
            _context.NN_TienIchMoRongs.Add(NN_TienIchMoRong);
            await _context.SaveChangesAsync();
            return NN_TienIchMoRong.ID_TienichMoRong;
        }

        public async Task<int> Xoa(int id)
        {
            NN_TienIchMoRong NN_TienIchMoRong = _context.NN_TienIchMoRongs.Where(a => a.ID_TienichMoRong == id).FirstOrDefault();
            if (NN_TienIchMoRong == null)
                throw new Exception("Tiện tích không tồn tại.");
            NN_TienIchMoRong.Delete = true;
            _context.NN_TienIchMoRongs.Update(NN_TienIchMoRong);
            await _context.SaveChangesAsync();
            return NN_TienIchMoRong.ID_TienichMoRong;
        }
    }
}