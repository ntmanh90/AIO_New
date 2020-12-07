using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CauHinhKhachSan;
using AIO.ViewModels.CongTy;
using AIO.ViewModels.KhachSan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIO.BackendServer.Controllers
{
    [Route("api/cauhinhkhachsan")]
    [ApiController]
    public class CauHinhKhachSanControler : ControllerBase
    {
        readonly ApplicationDbContext _context;
        private readonly CauHinhKhachSanService _cauhinhkhachSanService;
        private CongTyRequestValidator validator;
        public CauHinhKhachSanControler(CauHinhKhachSanService cauhinhkhachsan, ApplicationDbContext dbContext)
        {
            _cauhinhkhachSanService = cauhinhkhachsan;
            _context = dbContext;
        }
        

        [HttpPost("themcauhinhkhachsan")]
        public async Task<IActionResult> ThemCauHinh([FromForm] CauHinhKhachSanRequest cauhinhkhachsan)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _cauhinhkhachSanService.ThemCauHinhKhachSan(cauhinhkhachsan);
            return Ok(test);
        }
        [HttpPost("suacauhinhkhachsan")]
        public async Task<IActionResult> SuaCauHinh([FromForm] CauHinhKhachSanRequest cauhinhkhachsan)
        {
            var test = await _cauhinhkhachSanService.SuaCauHinhKhachSan(cauhinhkhachsan);
            return Ok(test);
        }
        [HttpPost("xoacauhinhkhachsan")]
        public async Task<IActionResult> XoaCauHinh( int id)
        {
            var test = await _cauhinhkhachSanService.XoaCauHinhKhachSan(id);
            return Ok(test);
        }
        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _cauhinhkhachSanService.DanhSachCauHinh();
            return Ok(test);
        }

    }
}
