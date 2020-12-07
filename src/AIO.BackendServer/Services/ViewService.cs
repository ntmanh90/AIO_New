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
using AIO.ViewModels.View;

namespace AIO.BackendServer.Services
{
    public class ViewService
    {
        private readonly ApplicationDbContext _context;

        public ViewService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<ViewVM>> DanhSach()
        {
            return await _context.Views.Select(model => new ViewVM
            {
                Delete = model.Delete,
                CreateBy = model.CreateBy,
                ID_NgonNgu = model.ID_NgonNgu,
                ID_View = model.ID_View,
                ModifyBy = model.ModifyBy,
                NoiDungHienThi  = model.NoiDungHienThi,
            }
            ).ToListAsync();
        }

        public async Task<int> Sua(ViewRequest model)
        {

            View view = _context.Views.Where(a => a.ID_View == model.ID_View).FirstOrDefault();
            if (view == null)
                throw new Exception("View không tồn tại");
            view.Delete = model.Delete;
            view.CreateBy = model.CreateBy;
            view.ID_NgonNgu = model.ID_NgonNgu;
            view.ModifyBy = model.ModifyBy;
            view.NoiDungHienThi = model.NoiDungHienThi;
            view.LastModifiedDate = DateTime.Now;
            _context.Views.Update(view);
            await _context.SaveChangesAsync();
            return view.ID_View;
        }

        public async Task<int> Them(ViewRequest model)
        {
            View view = new View();

            view.Delete = model.Delete;
            view.CreateBy = model.CreateBy;
            view.ID_NgonNgu = model.ID_NgonNgu;
            view.ModifyBy = model.ModifyBy;
            view.NoiDungHienThi = model.NoiDungHienThi;
            view.CreateDate = DateTime.Now;
            _context.Views.Add(view);
            await _context.SaveChangesAsync();
            return view.ID_View;
        }

        public async Task<int> Xoa(int id)
        {
            View view = _context.Views.Where(a => a.ID_View == id).FirstOrDefault();
            if (view == null)
                throw new Exception("View không tồn tại.");
            view.Delete = true;
            _context.Views.Update(view);
            await _context.SaveChangesAsync();
            return view.ID_View;
        }
    }
}