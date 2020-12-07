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
using AIO.ViewModels.SoNguoiToiDa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class SoNguoiToiDaService
    {
        private readonly ApplicationDbContext _context;

        public SoNguoiToiDaService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<SoNguoiToiDaVM>> DanhSach()
        {
            return await _context.SoNguoiToiDas.Select(a => new SoNguoiToiDaVM
            {
                ModifyBy = a.ModifyBy,
                CreateBy = a.CreateBy,
                Delete = a.Delete,
                ID_NgonNgu = a.ID_NgonNgu,
                ID_SoNguoiToiDa = a.ID_SoNguoiToiDa,
                NoiDungHienThi = a.NoiDungHienThi
            }
            ).ToListAsync();
        }

        public async Task<int> Sua(SoNguoiToiDaRequest model)
        {

            SoNguoiToiDa songuoitoida = _context.SoNguoiToiDas.Where(a => a.ID_SoNguoiToiDa == model.ID_SoNguoiToiDa).FirstOrDefault();
            if (songuoitoida == null)
                throw new Exception("Ngôn ngữ khách sạn không tồn tại.");
            songuoitoida.ModifyBy = model.ModifyBy;
            songuoitoida.CreateBy = model.CreateBy;
            songuoitoida.Delete = model.Delete;
            songuoitoida.ID_NgonNgu = model.ID_NgonNgu;
            songuoitoida.ID_SoNguoiToiDa = model.ID_SoNguoiToiDa;
            songuoitoida.NoiDungHienThi = model.NoiDungHienThi;
            songuoitoida.LastModifiedDate = DateTime.Now;
            _context.SoNguoiToiDas.Update(songuoitoida);
            await _context.SaveChangesAsync();
            return songuoitoida.ID_SoNguoiToiDa;
        }

        public async Task<int> Them(SoNguoiToiDaRequest model)
        {
            SoNguoiToiDa songuoitoida = new SoNguoiToiDa();

            songuoitoida.ModifyBy = model.ModifyBy;
            songuoitoida.CreateBy = model.CreateBy;
            songuoitoida.Delete = model.Delete;
            songuoitoida.ID_NgonNgu = model.ID_NgonNgu;
            songuoitoida.ID_SoNguoiToiDa = model.ID_SoNguoiToiDa;
            songuoitoida.NoiDungHienThi = model.NoiDungHienThi;
            songuoitoida.CreateDate = DateTime.Now;
            _context.SoNguoiToiDas.Add(songuoitoida);
            await _context.SaveChangesAsync();
            return songuoitoida.ID_SoNguoiToiDa;
        }

        public async Task<int> Xoa(int id)
        {
            SoNguoiToiDa songuoitoida = _context.SoNguoiToiDas.Where(a => a.ID_SoNguoiToiDa == id).FirstOrDefault();
            if (songuoitoida == null)
                throw new Exception("Ngôn ngức khách sạn không tồn tại.");
            songuoitoida.Delete = true;
            _context.SoNguoiToiDas.Update(songuoitoida);
            await _context.SaveChangesAsync();
            return songuoitoida.ID_SoNguoiToiDa;
        }
    }
}