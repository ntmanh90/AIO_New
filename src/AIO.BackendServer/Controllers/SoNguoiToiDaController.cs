using AIO.BackendServer.Data;
using AIO.BackendServer.Services;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NgonNgu;
using AIO.ViewModels.NgonNgu_KhachSan;
using AIO.ViewModels.NN_KhachSan;
using AIO.ViewModels.NN_TienIchMoRong;
using AIO.ViewModels.SoNguoiToiDa;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    [Route("api/songuoitoida")]
    [ApiController]
    public class SoNguoiToiDaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly SoNguoiToiDaService _songuoitoidaservice;
        private LoaiPhongRequestValidator validator;

        public SoNguoiToiDaController(SoNguoiToiDaService songuoitoidaservice, ApplicationDbContext dbContext)
        {
            _songuoitoidaservice = songuoitoidaservice;
            _context = dbContext;
        }

        [HttpPost("them")]
        public async Task<IActionResult> ThemMoi([FromForm] SoNguoiToiDaRequest songuoitoidarequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _songuoitoidaservice.Them(songuoitoidarequest);
            //validator = new LoaiPhongRequestValidator();
            return Ok(test);
        }

        [HttpPost("sua")]
        public async Task<IActionResult> Sua([FromForm] SoNguoiToiDaRequest songuoitoidarequest)
        {
            var test = await _songuoitoidaservice.Sua(songuoitoidarequest);
            return Ok(test);
        }

        [HttpPost("xoa")]
        public async Task<IActionResult> Xoa(int id)
        {
            var test = await _songuoitoidaservice.Xoa(id);
            return Ok(test);
        }

        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _songuoitoidaservice.DanhSach();
            return Ok(test);
        }
    }
}