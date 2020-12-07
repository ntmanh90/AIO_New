using AIO.BackendServer.Data;
using AIO.BackendServer.Services;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    [Route("api/loaiphong")]
    [ApiController]
    public class LoaiPhongController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly LoaiPhongService _loaiphongService;
        private LoaiPhongRequestValidator validator;

        public LoaiPhongController(LoaiPhongService loaiphongService, ApplicationDbContext dbContext)
        {
            _loaiphongService = loaiphongService;
            _context = dbContext;
        }

        [HttpPost("them")]
        public async Task<IActionResult> ThemMoi([FromForm] LoaiPhongRequest loaiphong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _loaiphongService.Them(loaiphong);
            //validator = new LoaiPhongRequestValidator();
            return Ok(test);
        }

        [HttpPost("sua")]
        public async Task<IActionResult> Sua([FromForm] LoaiPhongRequest loaiphong)
        {
            var test = await _loaiphongService.Sua(loaiphong);
            return Ok(test);
        }

        [HttpPost("xoa")]
        public async Task<IActionResult> Xoa(int id)
        {
            var test = await _loaiphongService.Xoa(id);
            return Ok(test);
        }

        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _loaiphongService.DanhSach();
            return Ok(test);
        }
    }
}