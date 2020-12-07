using AIO.BackendServer.Data;
using AIO.BackendServer.Services;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NgonNgu;
using AIO.ViewModels.NN_KhachSan;
using AIO.ViewModels.NN_TienIchMoRong;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    [Route("api/nntienichmotrong")]
    [ApiController]
    public class NN_TienIchMoRongController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly NN_TienIchMoRongService _ngonngutienichmorongService;
        private LoaiPhongRequestValidator validator;

        public NN_TienIchMoRongController(NN_TienIchMoRongService nn_tienichmorongservice, ApplicationDbContext dbContext)
        {
            _ngonngutienichmorongService = nn_tienichmorongservice;
            _context = dbContext;
        }

        [HttpPost("them")]
        public async Task<IActionResult> ThemMoi([FromForm] NN_TienIchMoRongRequest nn_tienichmorongrequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _ngonngutienichmorongService.Them(nn_tienichmorongrequest);
            //validator = new LoaiPhongRequestValidator();
            return Ok(test);
        }

        [HttpPost("sua")]
        public async Task<IActionResult> Sua([FromForm] NN_TienIchMoRongRequest nn_tienichmorongrequest)
        {
            var test = await _ngonngutienichmorongService.Sua(nn_tienichmorongrequest);
            return Ok(test);
        }

        [HttpPost("xoa")]
        public async Task<IActionResult> Xoa(int id)
        {
            var test = await _ngonngutienichmorongService.Xoa(id);
            return Ok(test);
        }

        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _ngonngutienichmorongService.DanhSach();
            return Ok(test);
        }
    }
}