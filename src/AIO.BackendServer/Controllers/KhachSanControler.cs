using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.KhachSan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIO.BackendServer.Controllers
{
    [Route("api/khachsan")]
    [ApiController]
    public class KhachSanControler : ControllerBase
    {
        readonly ApplicationDbContext _context;
        private readonly KhachSanService _khachSanService;
        private CongTyRequestValidator validator;
        public KhachSanControler(KhachSanService khachsanSevice, ApplicationDbContext dbContext)
        {
            _khachSanService = khachsanSevice;
            _context = dbContext;
        }
        

        [HttpGet("chitiet")]
        public async Task<IActionResult> ChiTiet(int id_khachsan)
        {           
            var test = await _khachSanService.ChiTietKhachSan(id_khachsan);
            return Ok(test);
        }

        [HttpPost("themkhachsan")]
        public async Task<IActionResult> ThemKhachSan([FromForm] CauHinhKhachSanRequiter khachsan)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _khachSanService.ThemKhachSan(khachsan);
            return Ok(test);
        }
        [HttpPost("suacongty")]
        public async Task<IActionResult> SuaKhachSan([FromForm] CauHinhKhachSanRequiter khachsan)
        {
            var test = await _khachSanService.SuaKhachSan(khachsan);
            return Ok(test);
        }
        [HttpPost("xoacongty")]
        public async Task<IActionResult> XoaKhachSan( int id_khachsan)
        {
            var test = await _khachSanService.XoaKhachSan(id_khachsan);
            return Ok(test);
        }
        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _khachSanService.DanhSachKhachSan();
            return Ok(test);
        }

    }
}
