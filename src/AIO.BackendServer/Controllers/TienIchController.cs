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
using AIO.ViewModels.NgonNgu;
using System.Collections.Generic;
using AIO.ViewModels.View;
using AIO.ViewModels.TienIch;
using AIO.ViewModels.Systems;

namespace AIO.BackendServer.Controllers
{
    public class TienIchController : BaseController
    {
        private readonly ApplicationDbContext _context;
        const string tieuDe = "Tiện ích";
        InfoUser InfoUser = new InfoUser();

        public TienIchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("them")]
        //[ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> Post([FromBody] TienIchRequest request)
        {
            var tienich = new TienIch()
            {
                TieuDe = request.TieuDe,
                CreateBy = InfoUser.TenDangNhap,
                TrangThai =  request.TrangThai,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                ModifyBy ="",
                Delete = false

            };
            _context.TienIchs.Add(tienich);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                foreach(var item in request.NN_ObjectRequests)
                {
                    var nn_tienich = new NN_TienIch
                    {
                        ID_TienIch = tienich.ID_TienIch,
                        Id_NgonNgu = item.ID_NgonNgu,
                        NoiDungHienThi = item.NoidungHienThi,
                        CreateBy = InfoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.NN_TienIchs.Add(nn_tienich);
                    _context.SaveChanges();
                }
                return   Ok(tienich);
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
            var query = _context.TienIchs.AsQueryable();
            if(!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.TieuDe.Contains(filter));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip(pageIndex - 1).Take(pagesize).ToListAsync();
            var data = items.ToList();
            var pagination = new Pagination<TienIch>
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
            var result = await _context.TienIchs.AsQueryable().ToListAsync();
            return Ok(result);
        }

        [HttpGet("danh-sach-select")]
        //cliam
        public async Task<IActionResult> DanhSachSelect()
        {
            var result = await _context.TienIchs.Where(a=>a.Delete == DeleteStatus.ChuaXoa).AsQueryable().ToListAsync();
            return Ok(result);
        }

        [Route("sua")]
        [HttpPut]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        [ApiValidationFilter]
        public async Task<IActionResult> Put( [FromBody] TienIchRequest request)
        {
            var tienich = await _context.TienIchs.FindAsync(request.ID_TienIch);
            if(tienich == null)
            {
                return NotFound(new ApiNotFoundResponse($"{tieuDe} với id: {request.ID_TienIch}  không tồn tại"));
            }
            tienich.TieuDe = request.TieuDe;
            tienich.TrangThai = request.TrangThai;
            tienich.ModifyBy = InfoUser.TenDangNhap;
            tienich.ModifyDate = DateTime.Now;

            _context.TienIchs.Update(tienich);
            var result = await _context.SaveChangesAsync();
            if(result> 0)
            {
                _context.NN_TienIchs.RemoveRange(_context.NN_TienIchs.Where(a => a.ID_TienIch == tienich.ID_TienIch).ToList());

                foreach (var item in request.NN_ObjectRequests)
                {
                    var nn_tienich = new NN_TienIch
                    {
                        ID_TienIch = tienich.ID_TienIch,
                        Id_NgonNgu = item.ID_NgonNgu,
                        NoiDungHienThi = item.NoidungHienThi,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = InfoUser.TenDangNhap,
                        CreateBy = InfoUser.TenDangNhap,
                        Delete = false
                    };
                    _context.NN_TienIchs.Add(nn_tienich);
                    _context.SaveChanges();
                }
                return Ok(tienich);
            }
            return BadRequest(new ApiBadRequestResponse($"Cập nhật {tieuDe} không thành công"));
        }

        [HttpDelete]
        [Route("xoa")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var tienich = await _context.TienIchs.FindAsync(id);
            if (tienich == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id} không tồn tại"));
            }
            tienich.Delete = true;
            _context.TienIchs.Update(tienich);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                foreach (var item in _context.NN_TienIchs.Where(a => a.ID_TienIch == tienich.ID_TienIch).ToList())
                {
                    item.Delete = true;
                    _context.NN_TienIchs.Update(item);
                    _context.SaveChanges();
                }

                return Ok(new { kq = true });
            }
            return BadRequest(new ApiBadRequestResponse($"Xóa {tieuDe} không thành công"));
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnObject = new TienIchRequest();
            var tienich = await _context.TienIchs.FindAsync(id);
            if(tienich == null)
            {
                returnObject = new TienIchRequest
                {
                    ID_TienIch = 0,
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
            returnObject = new TienIchRequest
            {
                ID_TienIch = tienich.ID_TienIch,
                TieuDe = tienich.TieuDe,
                TrangThai = tienich.TrangThai,
                NN_ObjectRequests = _context.NN_TienIchs.Where(a=>a.ID_TienIch == tienich.ID_TienIch)
                .Select(a=> new NN_ObjectRequest { 
                    ID_NgonNgu = a.Id_NgonNgu,
                    NoidungHienThi = a.NoiDungHienThi,
                    TieuDe = _context.NgonNgus.FirstOrDefault(b => b.ID_NgonNgu == a.Id_NgonNgu).TieuDe
                }).ToList()
            };

            return Ok(returnObject);
        }

    }
}
