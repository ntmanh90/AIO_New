using AIO.BackendServer.Data;
using AIO.BackendServer.Services;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NgonNgu;
using AIO.ViewModels.NgonNgu_KhachSan;
using AIO.ViewModels.NN_KhachSan;
using AIO.ViewModels.NN_TienIchMoRong;
using AIO.ViewModels.SoNguoiToiDa;
using AIO.ViewModels.TienIch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    [Route("api/tienich")]
    [ApiController]
    public class TienIchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TienIchService _tienichservice;
        private LoaiPhongRequestValidator validator;

        public TienIchController(TienIchService tienichservice, ApplicationDbContext dbContext)
        {
            _tienichservice = tienichservice;
            _context = dbContext;
        }

        [HttpPost("them")]
        public async Task<IActionResult> ThemMoi([FromForm] TienIchRequest tienichrequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _tienichservice.Them(tienichrequest);
            //validator = new LoaiPhongRequestValidator();
            return Ok(test);
        }

        [HttpPost("sua")]
        public async Task<IActionResult> Sua([FromForm] TienIchRequest tienichrequest)
        {
            var test = await _tienichservice.Sua(tienichrequest);
            return Ok(test);
        }

        [HttpPost("xoa")]
        public async Task<IActionResult> Xoa(int id)
        {
            var test = await _tienichservice.Xoa(id);
            return Ok(test);
        }

        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _tienichservice.DanhSach();
            return Ok(test);
        }
    }
}