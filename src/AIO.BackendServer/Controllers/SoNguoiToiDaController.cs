using System;
using System.Linq;
using System.Threading.Tasks;
using AIO.BackendServer.Authorization;
using AIO.BackendServer.Constants;
using AIO.BackendServer.Data;
using AIO.BackendServer.Helpers;
using Microsoft.AspNetCore.Mvc;
using AIO.BackendServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using AIO.ViewModels;
using Microsoft.AspNetCore.Mvc.Filters;
using AIO.ViewModels.LoaiGiuong;
using AIO.ViewModels.NgonNgu;
using System.Collections.Generic;
using AIO.ViewModels.View;
using AIO.ViewModels.SoNguoiToiDa;
using AIO.ViewModels.Systems;

namespace AIO.BackendServer.Controllers
{
    public class SoNguoiToiDaController : BaseController
    {
        private readonly ApplicationDbContext _context;
        const string tieuDe = "Số người tối đa";
        InfoUser infoUser = new InfoUser();

        public SoNguoiToiDaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("them")]
        //[ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> Post([FromBody] SoNguoiToiDaRequest request)
        {
            var songuoitoida = new SoNguoiToiDa()
            {
                TieuDe = request.TieuDe,
                CreateBy = infoUser.TenDangNhap,
                TrangThai =  request.TrangThai,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                ModifyBy ="",
                Delete = false

            };
            _context.SoNguoiToiDas.Add(songuoitoida);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                foreach(var item in request.NN_ObjectRequests)
                {
                    var nn_songuoitoida = new NN_SoNguoiToiDa
                    {
                        ID_NguoiToiDa = songuoitoida.ID_SoNguoiToiDa,
                        Id_NgonNgu = item.ID_NgonNgu,
                        NoiDungHienThi = item.NoidungHienThi,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.NN_SoNguoiToiDas.Add(nn_songuoitoida);
                    _context.SaveChanges();
                }
                return   Ok(songuoitoida);
            }    
            else
            {
                return BadRequest(new ApiBadRequestResponse($"Tạo mới {tieuDe} thất bại."));
            }    
        }
        [HttpGet("filter")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        public async Task<IActionResult> GetLoaiGiuongPaging(string filter, int pageIndex, int pagesize)
        {
            var query = _context.SoNguoiToiDas.AsQueryable();
            if(!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.TieuDe.Contains(filter));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip(pageIndex - 1).Take(pagesize).ToListAsync();
            var data = items.ToList();
            var pagination = new Pagination<SoNguoiToiDa>
            {
                Items = data,
                TotalRecords = totalRecords
            };
            return Ok(pagination);
        }

        [HttpGet("danh-sach")]
        //cliam
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.SoNguoiToiDas.AsQueryable().ToListAsync();
            return Ok(result);
        }

        [Route("sua")]
        [HttpPut]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        [ApiValidationFilter]
        public async Task<IActionResult> Put( [FromBody] SoNguoiToiDaRequest request)
        {
            var songuoitoida = await _context.SoNguoiToiDas.FindAsync(request.ID_SoNguoiToiDa);
            if(songuoitoida == null)
            {
                return NotFound(new ApiNotFoundResponse($"{tieuDe} với id: {request.ID_SoNguoiToiDa}  không tồn tại"));
            }
            songuoitoida.TieuDe = request.TieuDe;
            songuoitoida.TrangThai = request.TrangThai;
            songuoitoida.ModifyBy = infoUser.TenDangNhap;
            songuoitoida.ModifyDate = DateTime.Now;

            _context.SoNguoiToiDas.Update(songuoitoida);
            var result = await _context.SaveChangesAsync();
            if(result> 0)
            {
                _context.NN_SoNguoiToiDas.RemoveRange(_context.NN_SoNguoiToiDas.Where(a => a.ID_NguoiToiDa == songuoitoida.ID_SoNguoiToiDa).ToList());

                foreach (var item in request.NN_ObjectRequests)
                {
                    var nn_songuoitoida = new NN_SoNguoiToiDa
                    {
                        ID_NguoiToiDa = songuoitoida.ID_SoNguoiToiDa,
                        Id_NgonNgu = item.ID_NgonNgu,
                        NoiDungHienThi = item.NoidungHienThi,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = infoUser.TenDangNhap,
                        CreateBy = infoUser.TenDangNhap,
                        Delete = false
                    };
                    _context.NN_SoNguoiToiDas.Add(nn_songuoitoida);
                    _context.SaveChanges();
                }
                return Ok(songuoitoida);
            }
            return BadRequest(new ApiBadRequestResponse($"Cập nhật {tieuDe} không thành công"));
        }

        [HttpDelete]
        [Route("xoa")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var songuoitoida = await _context.SoNguoiToiDas.FindAsync(id);
            if (songuoitoida == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id} không tồn tại"));
            }
            songuoitoida.Delete = true;
            _context.SoNguoiToiDas.Update(songuoitoida);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                foreach (var item in _context.NN_SoNguoiToiDas.Where(a => a.ID_NguoiToiDa == songuoitoida.ID_SoNguoiToiDa).ToList())
                {
                    item.Delete = true;
                    _context.NN_SoNguoiToiDas.Update(item);
                    _context.SaveChanges();
                }

                return Ok(new { kq = true });
            }
            return BadRequest(new ApiBadRequestResponse($"Xóa {tieuDe} không thành công"));
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnObject = new SoNguoiToiDaRequest();
            var songuoitoida = await _context.SoNguoiToiDas.FindAsync(id);
            if(songuoitoida == null)
            {
                returnObject = new SoNguoiToiDaRequest
                {
                    ID_SoNguoiToiDa = 0,
                    TieuDe ="",
                    TrangThai = true,
                    NN_ObjectRequests = new List<NN_ObjectRequest>()
                };
                foreach(var item in _context.NgonNgus.ToList())
                {
                    NN_ObjectRequest nN_Object = new NN_ObjectRequest
                    {
                        ID = 0,
                        ID_NgonNgu = item.ID_NgonNgu,
                        NoidungHienThi = "",
                        TieuDe = _context.NgonNgus.FirstOrDefault(b => b.ID_NgonNgu == item.ID_NgonNgu).TieuDe
                    };
                   returnObject.NN_ObjectRequests.Add(nN_Object);
                }    

                return Ok(returnObject);
            }
            returnObject = new SoNguoiToiDaRequest
            {
                ID_SoNguoiToiDa = songuoitoida.ID_SoNguoiToiDa,
                TieuDe = songuoitoida.TieuDe,
                TrangThai = songuoitoida.TrangThai,
                NN_ObjectRequests = _context.NN_SoNguoiToiDas.Where(a=>a.ID_NguoiToiDa == songuoitoida.ID_SoNguoiToiDa)
                .Select(a=> new NN_ObjectRequest { 
                    ID_NgonNgu = a.Id_NgonNgu,
                    NoidungHienThi = a.NoiDungHienThi,
                    TieuDe = _context.NgonNgus.FirstOrDefault(b=>b.ID_NgonNgu ==a.Id_NgonNgu).TieuDe
                }).ToList()
            };

            return Ok(returnObject);
        }

    }
}
