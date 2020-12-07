using AIO.BackendServer.Data;
using AIO.BackendServer.Services;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NgonNgu;
using AIO.ViewModels.NN_KhachSan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    [Route("api/ngonngu")]
    [ApiController]
    public class NgonNguController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly NgonNguService _ngonnguService;
        private LoaiPhongRequestValidator validator;

        public NgonNguController(NgonNguService ngonnguservice, ApplicationDbContext dbContext)
        {
            _ngonnguService = ngonnguservice;
            _context = dbContext;
        }

        [HttpPost("them")]
        public async Task<IActionResult> ThemMoi([FromForm] NgonNguRequest ngonngurequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _ngonnguService.Them(ngonngurequest);
            //validator = new LoaiPhongRequestValidator();
            return Ok(test);
        }

        [HttpPost("sua")]
        public async Task<IActionResult> Sua([FromForm] NgonNguRequest ngonngurequest)
        {
            var test = await _ngonnguService.Sua(ngonngurequest);
            return Ok(test);
        }

        [HttpPost("xoa")]
        public async Task<IActionResult> Xoa(int id)
        {
            var test = await _ngonnguService.Xoa(id);
            return Ok(test);
        }

        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _ngonnguService.DanhSach();
            return Ok(test);
        }
    }
}