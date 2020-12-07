using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Services.CongTySer;
using AIO.ViewModels.CongTy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIO.BackendServer.Controllers
{
    [Route("api/congty")]
    [ApiController]
    public class CongTyController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        private readonly ICongTyService _congTyService;
        private CongTyRequestValidator validator;
        public CongTyController(ICongTyService congTyService, ApplicationDbContext dbContext)
        {
            _congTyService = congTyService;
            _context = dbContext;
        }
        

        [HttpGet("chitiet")]
        public async Task<IActionResult> ChiTietCongTy(int id_congty)
        {
            
            var test = await _congTyService.ChiTietCongTy(id_congty);
            return Ok(test);
        }

        [HttpPost("themcongty")]
        public async Task<IActionResult> ThemMoiCongTy([FromForm] CongTyRequest congty)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _congTyService.ThemCongTy(congty);
            //validator = new CongTyRequestValidator();
            return Ok(test);
        }
        [HttpPost("suacongty")]
        public async Task<IActionResult> SuaCongTy([FromForm] CongTyRequest congty)
        {
            var test = await _congTyService.SuaCongTy(congty);
            return Ok(test);
        }
        [HttpPost("xoacongty")]
        public async Task<IActionResult> XoaCongTy( int id_congty)
        {
            var test = await _congTyService.XoaCongTy(id_congty);
            return Ok(test);
        }
        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _congTyService.DanhSachCongTy();
            return Ok(test);
        }

    }
}
