using AIO.BackendServer.Constants;
using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Helpers;
using AIO.ViewModels;
using AIO.ViewModels.NgonNgu;
using AIO.ViewModels.Systems;
using AIO.ViewModels.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    public class HuongNhinController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private const string tieuDe = "Hướng nhìn";
        private InfoUser infoUser = new InfoUser();

        public HuongNhinController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("them")]
        //[ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> Post([FromBody] HuongNhinRequest request)
        {
            var huongNhin = new HuongNhin()
            {
                TieuDe = request.TieuDe,
                CreateBy = infoUser.TenDangNhap,
                TrangThai = request.TrangThai,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                ModifyBy = "",
                Delete = false
            };
            _context.HuongNhins.Add(huongNhin);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                foreach (var item in request.NN_ObjectRequests)
                {
                    var nn_HuongNhin = new NN_HuongNhin
                    {
                        ID_HuongNhin = huongNhin.ID_HuongNhin,
                        Id_NgonNgu = item.ID_NgonNgu,
                        NoiDungHienThi = item.NoidungHienThi,
                        CreateBy = infoUser.TenDangNhap,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        ModifyBy = "",
                        Delete = false
                    };
                    _context.NN_HuongNhins.Add(nn_HuongNhin);
                    _context.SaveChanges();
                }
                return Ok(huongNhin);
            }
            else
            {
                return BadRequest(new ApiBadRequestResponse("Tạo mới hướng nhìn thất bại."));
            }
        }

        [HttpGet("filter")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        public async Task<IActionResult> GetLoaiGiuongPaging(string filter, int pageIndex, int pagesize)
        {
            var query = _context.HuongNhins.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.TieuDe.Contains(filter));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip(pageIndex - 1).Take(pagesize).ToListAsync();
            var data = items.ToList();
            var pagination = new Pagination<HuongNhin>
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
            var result = await _context.HuongNhins.AsQueryable().ToListAsync();
            return Ok(result);
        }

        [HttpGet("danh-sach-select")]
        //cliam
        public async Task<IActionResult> DanhSachSelect()
        {
            var result = await _context.HuongNhins.Where(a => a.Delete == DeleteStatus.ChuaXoa).AsQueryable().ToListAsync();
            return Ok(result);
        }

        [Route("sua")]
        [HttpPut]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        [ApiValidationFilter]
        public async Task<IActionResult> Put(int id, [FromBody] HuongNhinRequest request)
        {
            var huongNhin = await _context.HuongNhins.FindAsync(request.ID_HuongNhin);
            if (huongNhin == null)
            {
                return NotFound(new ApiNotFoundResponse($"{tieuDe} với id: {request.ID_HuongNhin}  không tồn tại"));
            }
            huongNhin.TieuDe = request.TieuDe;
            huongNhin.TrangThai = request.TrangThai;
            huongNhin.ModifyBy = infoUser.TenDangNhap;
            huongNhin.ModifyDate = DateTime.Now;

            _context.HuongNhins.Update(huongNhin);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                _context.NN_HuongNhins.RemoveRange(_context.NN_HuongNhins.Where(a => a.ID_HuongNhin == huongNhin.ID_HuongNhin).ToList());

                foreach (var item in request.NN_ObjectRequests)
                {
                    var nn_huongNhin = new NN_HuongNhin
                    {
                        ID_HuongNhin = huongNhin.ID_HuongNhin,
                        Id_NgonNgu = item.ID_NgonNgu,
                        NoiDungHienThi = item.NoidungHienThi,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        CreateBy = infoUser.TenDangNhap,
                        ModifyBy = infoUser.TenDangNhap,
                        Delete = false
                    };
                    _context.NN_HuongNhins.Add(nn_huongNhin);
                    _context.SaveChanges();
                }
                return Ok(huongNhin);
            }
            return BadRequest(new ApiBadRequestResponse($"Cập nhật {tieuDe} không thành công"));
        }

        [HttpDelete]
        [Route("xoa")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var huongnhin = await _context.HuongNhins.FindAsync(id);
            if (huongnhin == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id} không tồn tại"));
            }
            huongnhin.Delete = true;
            _context.HuongNhins.Update(huongnhin);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                foreach (var item in _context.NN_HuongNhins.Where(a => a.ID_HuongNhin == huongnhin.ID_HuongNhin).ToList())
                {
                    item.Delete = true;
                    _context.NN_HuongNhins.Update(item);
                    _context.SaveChanges();
                }

                return Ok(new { kq = true });
            }
            return BadRequest(new ApiBadRequestResponse($"Xóa {tieuDe} không thành công"));
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnObject = new HuongNhinRequest();
            var huongnhin = await _context.HuongNhins.FindAsync(id);
            if (huongnhin == null)
            {
                returnObject = new HuongNhinRequest
                {
                    ID_HuongNhin = 0,
                    TieuDe = "",
                    TrangThai = true,
                    NN_ObjectRequests = new List<NN_ObjectRequest>()
                };
                foreach (var item in _context.NgonNgus.ToList())
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
            returnObject = new HuongNhinRequest
            {
                ID_HuongNhin = huongnhin.ID_HuongNhin,
                TieuDe = huongnhin.TieuDe,
                TrangThai = huongnhin.TrangThai,
                NN_ObjectRequests = _context.NN_HuongNhins.Where(a => a.ID_HuongNhin == huongnhin.ID_HuongNhin)
                .Select(a => new NN_ObjectRequest
                {
                    ID_NgonNgu = a.Id_NgonNgu,
                    NoidungHienThi = a.NoiDungHienThi,
                    TieuDe = _context.NgonNgus.FirstOrDefault(b => b.ID_NgonNgu == a.Id_NgonNgu).TieuDe
                }).ToList()
            };

            return Ok(returnObject);
        }
    }
}