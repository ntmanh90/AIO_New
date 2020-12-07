using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NgonNgu;
using AIO.ViewModels.SoNguoiToiDa;
using AIO.ViewModels.NN_KhachSan;
using AIO.ViewModels.NN_TienIchMoRong;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIO.ViewModels.TienIch;
using AIO.ViewModels.TienIchMoRong_CongTy;

namespace AIO.BackendServer.Services
{
    public class TienIchMoRong_CongTyService
    {
        private readonly ApplicationDbContext _context;

        public TienIchMoRong_CongTyService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<TienIchMoRong_CongTyVM>> DanhSach()
        {
            return await _context.TienIchMoRong_CongTys.Select(a => new TienIchMoRong_CongTyVM
            {
                ModifyBy = a.ModifyBy,
                CreateBy = a.CreateBy,
                Delete = a.Delete,
                ID_CongTy = a.ID_CongTy,
                ID_TienIchMoRong = a.ID_TienIchMoRong,
                TenTienich = a.TenTienich,
                TrangThai = a.TrangThai,
            }
            ).ToListAsync();
        }

        public async Task<int> Sua(TienIchMoRong_CongTyRequest model)
        {

            TienIchMoRong_CongTy tienichmorong_congty = _context.TienIchMoRong_CongTys.Where(a => a.ID_TienIchMoRong == model.ID_TienIchMoRong).FirstOrDefault();
            if (tienichmorong_congty == null)
                throw new Exception("Tiên ích mở rộng của công ty không tồn tại");
            tienichmorong_congty.ModifyBy = model.ModifyBy;
            tienichmorong_congty.CreateBy = model.CreateBy;
            tienichmorong_congty.Delete = model.Delete;
            tienichmorong_congty.ID_CongTy = model.ID_CongTy;
            tienichmorong_congty.ID_TienIchMoRong = model.ID_TienIchMoRong;
            tienichmorong_congty.TenTienich = model.TenTienich;
            tienichmorong_congty.TrangThai = model.TrangThai;
            tienichmorong_congty.LastModifiedDate = DateTime.Now;
            _context.TienIchMoRong_CongTys.Update(tienichmorong_congty);
            await _context.SaveChangesAsync();
            return tienichmorong_congty.ID_TienIchMoRong;
        }

        public async Task<int> Them(TienIchMoRong_CongTyRequest model)
        {
            TienIchMoRong_CongTy tienichmorong_congty = new TienIchMoRong_CongTy();

            tienichmorong_congty.ModifyBy = model.ModifyBy;
            tienichmorong_congty.CreateBy = model.CreateBy;
            tienichmorong_congty.Delete = model.Delete;
            tienichmorong_congty.ID_CongTy = model.ID_CongTy;
            tienichmorong_congty.ID_TienIchMoRong = model.ID_TienIchMoRong;
            tienichmorong_congty.TenTienich = model.TenTienich;
            tienichmorong_congty.TrangThai = model.TrangThai;
            tienichmorong_congty.CreateDate = DateTime.Now;
            _context.TienIchMoRong_CongTys.Add(tienichmorong_congty);
            await _context.SaveChangesAsync();
            return tienichmorong_congty.ID_TienIchMoRong;
        }

        public async Task<int> Xoa(int id)
        {
            TienIchMoRong_CongTy tienichmorong_congty = _context.TienIchMoRong_CongTys.Where(a => a.ID_TienIchMoRong == id).FirstOrDefault();
            if (tienichmorong_congty == null)
                throw new Exception("Tiện ích mở rộng của công ty không tồn tại.");
            tienichmorong_congty.Delete = true;
            _context.TienIchMoRong_CongTys.Update(tienichmorong_congty);
            await _context.SaveChangesAsync();
            return tienichmorong_congty.ID_TienIchMoRong;
        }
    }
}