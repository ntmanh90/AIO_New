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
using AIO.ViewModels.Systems;

namespace AIO.BackendServer.Controllers
{
    public class NgonNguController : BaseController
    {
        private readonly ApplicationDbContext _context;
        InfoUser infoUser = new InfoUser();

        public NgonNguController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("them")]
        [ApiValidationFilter]
        // gọi claim check quyền
        public async Task<IActionResult> Post([FromBody] NgonNgu request)
        {
            var ngonNgu = new NgonNgu()
            {
               KyHieu = request.KyHieu,
               TieuDe = request.TieuDe,
               CreateBy = infoUser.TenDangNhap,
               CreateDate = DateTime.Now,
               ModifyDate = DateTime.Now,
               ModifyBy ="",
               Delete = false
            };
            _context.NgonNgus.Add(ngonNgu);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return Ok(ngonNgu);
            }    
            else
            {
                return BadRequest(new ApiBadRequestResponse("Tạo mới ngôn ngữ thất bại."));
            }    
        }
        [HttpGet("filter")]
        //cliam
        public async Task<IActionResult> GetPaging(string filter, int pageIndex, int pagesize)
        {
            var query = _context.NgonNgus.AsQueryable();
            if(!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.TieuDe.Contains(filter));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip(pageIndex - 1).Take(pagesize).ToListAsync();
            var data = items.ToList();
            var pagination = new Pagination<NgonNgu>
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
            var result = await _context.NgonNgus.AsQueryable().ToListAsync();
            return Ok(result);
        }

        [Route("sua")]
        [HttpPut]
        //Claim
        [ApiValidationFilter]
        public async Task<IActionResult> PutLoaiGiuong( [FromBody] NgonNgu request)
        {
            var ngonNgu = await _context.NgonNgus.FindAsync(request.ID_NgonNgu);
            if(ngonNgu == null)
            {
                return NotFound(new ApiNotFoundResponse($"Ngôn ngữ với id: {ngonNgu.ID_NgonNgu}  không tồn tại"));
            }
            ngonNgu.TieuDe = request.TieuDe;
            ngonNgu.KyHieu = request.KyHieu;
            ngonNgu.ModifyBy = infoUser.TenDangNhap;
            ngonNgu.ModifyDate = DateTime.Now;

            _context.NgonNgus.Update(ngonNgu);
            var result = await _context.SaveChangesAsync();
            if(result> 0)
            {
                return Ok(ngonNgu);
            }
            return BadRequest(new ApiBadRequestResponse("Cập nhật không thành công"));
        }

        [HttpDelete]
        [Route("xoa")]
        //cliam
        public async Task<IActionResult> Delete(int id)
        {
            var ngonNgu = await _context.NgonNgus.FindAsync(id);
            if(ngonNgu == null)
            {
                return BadRequest(new ApiBadRequestResponse($"Ngôn ngữ với id: {id} không tồn tại"));
            }
            _context.NgonNgus.Remove(ngonNgu);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return Ok(new { kq = true});
            }
            return BadRequest(new ApiBadRequestResponse("Xóa lại ngôn ngữ không thành công"));
        }


        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetById(int id)
        {
            var ngonNgu = await _context.NgonNgus.FindAsync(id);
            if(ngonNgu == null)
            {
                return NotFound(new ApiNotFoundResponse($"Ngôn ngữ với id: {id} không tồn tại"));
            }

            return Ok(ngonNgu);
        }

        
    }
}
