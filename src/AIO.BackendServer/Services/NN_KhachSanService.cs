using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NN_KhachSan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class NN_KhachSanService
    {
        private readonly ApplicationDbContext _context;

        public NN_KhachSanService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
     
        public async Task<List<NN_KhachSanVM>> DanhSach()
        {
            return await _context.NN_KhachSans.Select(a => new NN_KhachSanVM
            {
                    CreateBy = a.CreateBy,
                    Delete =   a.Delete,
                    GioiThieu = a.GioiThieu,
                    ID_KhachSan = a.ID_KhachSan,
                    ID_NgonNgu = a.ID_NgonNgu,
                    ModifyBy = a.ModifyBy,
                    TenKhachSan = a.TenKhachSan                   
            }
            ).ToListAsync();
        }

        public async Task<int> Sua(NN_KhachSanRequest model)
        {

            NN_KhachSan nn_KhachSan = _context.NN_KhachSans.Where(a => a.ID_KhachSan == model.ID_KhachSan).FirstOrDefault();
            if (nn_KhachSan  == null)
            throw new Exception("Ngôn ngữ khách sạn không tồn tại.");

            nn_KhachSan.Delete = model.Delete;
            nn_KhachSan.GioiThieu = model.GioiThieu;
            nn_KhachSan.ID_KhachSan = model.ID_KhachSan;
            nn_KhachSan.ID_NgonNgu = model.ID_NgonNgu;
            nn_KhachSan.ModifyBy = model.ModifyBy;
            nn_KhachSan.TenKhachSan = model.TenKhachSan;
            nn_KhachSan.LastModifiedDate = DateTime.Now;

            _context.NN_KhachSans.Update(nn_KhachSan);
            await _context.SaveChangesAsync();
            return nn_KhachSan.ID_KhachSan;
        }

        public async Task<int> Them(NN_KhachSanRequest model)
        {
            NN_KhachSan nn_KhachSan = new NN_KhachSan();

            nn_KhachSan.Delete = model.Delete;
            nn_KhachSan.GioiThieu = model.GioiThieu;
            nn_KhachSan.ID_KhachSan = model.ID_KhachSan;
            nn_KhachSan.ID_NgonNgu = model.ID_NgonNgu;
            nn_KhachSan.ModifyBy = model.ModifyBy;
            nn_KhachSan.TenKhachSan = model.TenKhachSan;
            nn_KhachSan.CreateDate = DateTime.Now;
            _context.NN_KhachSans.Add(nn_KhachSan);
            await _context.SaveChangesAsync();
            return nn_KhachSan.ID_KhachSan;
        }

        public async Task<int> Xoa(int id)
        {
            NN_KhachSan nn_KhachSan = _context.NN_KhachSans.Where(a => a.ID_KhachSan == id).FirstOrDefault();
            if (nn_KhachSan == null)
                throw new Exception("Ngôn ngữ khách sạn không tồn tại.");
            nn_KhachSan.Delete = true;
            _context.NN_KhachSans.Update(nn_KhachSan);
            await _context.SaveChangesAsync();
            return nn_KhachSan.ID_KhachSan;
        }
    }
}