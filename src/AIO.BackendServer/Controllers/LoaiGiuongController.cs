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
using AIO.ViewModels.Systems;

namespace AIO.BackendServer.Controllers
{
    public class LoaiGiuongController : BaseController
    {
        private readonly ApplicationDbContext _context;
        InfoUser infoUser = new InfoUser();

        public LoaiGiuongController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("them")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> PostLoaiGiuong([FromBody] LoaiGiuongRequest request)
        {
            var loaigiuong = new LoaiGiuong()
            {
                TieuDe = request.TieuDe,
                CreateBy = infoUser.TenDangNhap,
                TrangThai =  request.TrangThai,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                ModifyBy ="",
                Delete = false

            };
            _context.LoaiGiuongs.Add(loaigiuong);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                foreach(var item in request.NN_ObjectRequests)
                {
                    var nn_LoaiGiuong = new NN_LoaiGiuong
                    {
                        ID_LoaiGiuong = loaigiuong.ID_LoaiGiuong,
                        Id_NgonNgu = item.ID_NgonNgu,
                        NoiDungHienThi = item.NoidungHienThi,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.NN_LoaiGiuongs.Add(nn_LoaiGiuong);
                    _context.SaveChanges();
                }
                return   Ok(loaigiuong);
            }    
            else
            {
                return BadRequest(new ApiBadRequestResponse("Tạo mới loại giường thất bại."));
            }    
        }
        [HttpGet("filter")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        public async Task<IActionResult> GetLoaiGiuongPaging(string filter, int pageIndex, int pagesize)
        {
            var query = _context.LoaiGiuongs.AsQueryable();
            if(!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.TieuDe.Contains(filter));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip(pageIndex - 1).Take(pagesize).ToListAsync();
            var data = items.ToList();
            var pagination = new Pagination<LoaiGiuong>
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
            var result = await _context.LoaiGiuongs.AsQueryable().ToListAsync();
            return Ok(result);
        }


        [HttpGet("danh-sach-select")]
        //cliam
        public async Task<IActionResult> DanhSachSelect()
        {
            var result = await _context.LoaiGiuongs.Where(a=>a.Delete == DeleteStatus.ChuaXoa).AsQueryable().ToListAsync();
            return Ok(result);
        }

        [Route("sua")]
        [HttpPut]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        [ApiValidationFilter]
        public async Task<IActionResult> PutLoaiGiuong( [FromBody] LoaiGiuongRequest request)
        {
            var loaigiuong = await _context.LoaiGiuongs.FindAsync(request.ID_LoaiGiuong);
            if(loaigiuong == null)
            {
                return NotFound(new ApiNotFoundResponse($"Loại giường với id: {request.ID_LoaiGiuong}  không tồn tại"));
            }
            loaigiuong.TieuDe = request.TieuDe;
            loaigiuong.TrangThai = request.TrangThai;
            loaigiuong.ModifyBy = infoUser.TenDangNhap;
            loaigiuong.ModifyDate = DateTime.Now;

            _context.LoaiGiuongs.Update(loaigiuong);
            var result = await _context.SaveChangesAsync();
            if(result> 0)
            {
                _context.NN_LoaiGiuongs.RemoveRange(_context.NN_LoaiGiuongs.Where(a => a.ID_LoaiGiuong == loaigiuong.ID_LoaiGiuong).ToList());

                foreach (var item in request.NN_ObjectRequests)
                {
                    var nn_LoaiGiuong = new NN_LoaiGiuong
                    {
                        ID_LoaiGiuong = loaigiuong.ID_LoaiGiuong,
                        NoiDungHienThi = item.NoidungHienThi,
                        Id_NgonNgu = item.ID_NgonNgu,
                        CreateDate = DateTime.Now,
                        CreateBy = infoUser.TenDangNhap,
                        ModifyDate = DateTime.Now,
                        ModifyBy = infoUser.TenDangNhap,
                        Delete = false
                    };
                    _context.NN_LoaiGiuongs.Add(nn_LoaiGiuong);
                    _context.SaveChanges();
                }
                return Ok(loaigiuong);
            }
            return BadRequest(new ApiBadRequestResponse("Cập nhật không thành công"));
        }

        [HttpDelete]
        [Route("xoa")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> DeleteLoaiGiuong(int id)
        {
            var loaigiuong = await _context.LoaiGiuongs.FindAsync(id);
            if(loaigiuong == null)
            {
                return BadRequest(new ApiBadRequestResponse($"Loại giường với id: {id} không tồn tại"));
            }
            loaigiuong.Delete = true;

            _context.LoaiGiuongs.Update(loaigiuong);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                foreach(var item in _context.NN_LoaiGiuongs.Where(a => a.ID_LoaiGiuong == loaigiuong.ID_LoaiGiuong).ToList())
                {
                    item.Delete = true;
                    _context.NN_LoaiGiuongs.Update(item);
                    _context.SaveChanges();
                }    
               

                return Ok(new { kq = true });
            }
            return BadRequest(new ApiBadRequestResponse("Xóa loại giường không thành công"));
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnObject = new LoaiGiuongRequest();
            var loaigiuong = await _context.LoaiGiuongs.FindAsync(id);
            if(loaigiuong == null)
            {
                returnObject = new LoaiGiuongRequest
                {
                    ID_LoaiGiuong = 0,
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
            returnObject = new LoaiGiuongRequest
            {
                ID_LoaiGiuong = loaigiuong.ID_LoaiGiuong,
                TieuDe = loaigiuong.TieuDe,
                TrangThai = loaigiuong.TrangThai,
                NN_ObjectRequests = _context.NN_LoaiGiuongs.Where(a=>a.ID_LoaiGiuong == loaigiuong.ID_LoaiGiuong)
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
