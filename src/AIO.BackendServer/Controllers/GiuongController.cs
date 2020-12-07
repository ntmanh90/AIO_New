using AIO.BackendServer.Data;
using AIO.BackendServer.Services;
using AIO.ViewModels.Giuong;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    [Route("api/giuong")]
    [ApiController]
    public class GiuongController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly GiuongService _giuongService;
        private GiuongRequestValidator validator;

        public GiuongController(GiuongService giuongService, ApplicationDbContext dbContext)
        {
            _giuongService = giuongService;
            _context = dbContext;
        }

        [HttpPost("them")]
        public async Task<IActionResult> ThemMoi([FromForm] GiuongRequest giuong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _giuongService.Them(giuong);
            //validator = new GiuongRequestValidator();
            return Ok(test);
        }

        [HttpPost("sua")]
        public async Task<IActionResult> Sua([FromForm] GiuongRequest giuong)
        {
            var test = await _giuongService.Sua(giuong);
            return Ok(test);
        }

        [HttpPost("xoa")]
        public async Task<IActionResult> Xoa(int id)
        {
            var test = await _giuongService.Xoa(id);
            return Ok(test);
        }

        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _giuongService.DanhSach();
            return Ok(test);
        }
    }
}