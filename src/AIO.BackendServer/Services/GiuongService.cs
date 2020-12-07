using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.Giuong;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class GiuongService 
    {
        private readonly ApplicationDbContext _context;

        public GiuongService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
     
        public async Task<List<GiuongVM>> DanhSach()
        {
            return await _context.Giuongs.Select(a => new GiuongVM
            {
              ID_LoaiGiuong = a.ID_LoaiGiuong,
              CreateBy = a.CreateBy,
              Delete = a.Delete,
              ID_NgonNgu = a.ID_NgonNgu,
              ModifyBy = a.ModifyBy,
              NoiDungHienThi   = a.NoiDungHienThi,
            }
            ).ToListAsync();
        }

        public async Task<int> Sua(GiuongRequest model)
        {

            Giuong detaiGiuong = _context.Giuongs.Where(a => a.ID_LoaiGiuong == model.ID_LoaiGiuong).FirstOrDefault();
            if (detaiGiuong == null)
            throw new Exception("Loại giường không tồn tại.");

            detaiGiuong.ID_LoaiGiuong = model.ID_LoaiGiuong;
            detaiGiuong.ID_NgonNgu = model.ID_NgonNgu;
            detaiGiuong.LastModifiedDate = DateTime.Now;
            //detaiGiuong.ModifyBy = ;
            detaiGiuong.NoiDungHienThi = model.NoiDungHienThi;
            detaiGiuong.Delete = model.Delete;
            _context.Giuongs.Update(detaiGiuong);
            await _context.SaveChangesAsync();
            return detaiGiuong.ID_LoaiGiuong;
        }

        public async Task<int> Them(GiuongRequest model)
        {
            Giuong giuong = new Giuong();

            giuong.ID_LoaiGiuong = model.ID_LoaiGiuong;
            giuong.ID_NgonNgu = model.ID_NgonNgu;
            giuong.CreateDate = DateTime.Now;
            //detaiGiuong.ModifyBy = ;
            giuong.NoiDungHienThi = model.NoiDungHienThi;
            giuong.Delete = model.Delete;

            _context.Giuongs.Add(giuong);
            await _context.SaveChangesAsync();
            return giuong.ID_LoaiGiuong;
        }

        public async Task<int> Xoa(int id)
        {
            Giuong giuong = _context.Giuongs.Where(a => a.ID_LoaiGiuong == id).FirstOrDefault();
            if (giuong == null)
                throw new Exception("Loại giường không tồn tại.");

            giuong.Delete = true;
            _context.Giuongs.Update(giuong);
            await _context.SaveChangesAsync();
            return giuong.ID_LoaiGiuong;
        }
    }
}