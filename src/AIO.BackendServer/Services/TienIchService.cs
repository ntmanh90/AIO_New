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

namespace AIO.BackendServer.Services
{
    public class TienIchService
    {
        private readonly ApplicationDbContext _context;

        public TienIchService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<TienIchVM>> DanhSach()
        {
            return await _context.TienIchs.Select(a => new TienIchVM
            {
                NoiDungHienThi = a.NoiDungHienThi,
                ID_NgonNgu = a.ID_NgonNgu,
                Delete = a.Delete,
                CreateBy = a.CreateBy,
                ID_TienIch = a.ID_TienIch,
                ModifyBy = a.ModifyBy,
            }
            ).ToListAsync();
        }

        public async Task<int> Sua(TienIchRequest model)
        {

            TienIch tienich = _context.TienIchs.Where(a => a.ID_TienIch == model.ID_TienIch).FirstOrDefault();
            if (tienich == null)
                throw new Exception("Tiên ích không tồn tại");
            tienich.NoiDungHienThi = model.NoiDungHienThi;
            tienich.ID_NgonNgu = model.ID_NgonNgu;
            tienich.Delete = model.Delete;
            tienich.CreateBy = model.CreateBy;
            tienich.ID_TienIch = model.ID_TienIch;
            tienich.ModifyBy = model.ModifyBy;
            tienich.LastModifiedDate = DateTime.Now;
            _context.TienIchs.Update(tienich);
            await _context.SaveChangesAsync();
            return tienich.ID_TienIch;
        }

        public async Task<int> Them(TienIchRequest model)
        {
            TienIch tienich = new TienIch();

            tienich.NoiDungHienThi = model.NoiDungHienThi;
            tienich.ID_NgonNgu = model.ID_NgonNgu;
            tienich.Delete = model.Delete;
            tienich.CreateBy = model.CreateBy;
            tienich.ID_TienIch = model.ID_TienIch;
            tienich.ModifyBy = model.ModifyBy;
            tienich.CreateDate = DateTime.Now;
            _context.TienIchs.Add(tienich);
            await _context.SaveChangesAsync();
            return tienich.ID_TienIch;
        }

        public async Task<int> Xoa(int id)
        {
            TienIch tienich = _context.TienIchs.Where(a => a.ID_TienIch == id).FirstOrDefault();
            if (tienich == null)
                throw new Exception("Tiện ích không tồn tại.");
            tienich.Delete = true;
            _context.TienIchs.Update(tienich);
            await _context.SaveChangesAsync();
            return tienich.ID_TienIch;
        }
    }
}