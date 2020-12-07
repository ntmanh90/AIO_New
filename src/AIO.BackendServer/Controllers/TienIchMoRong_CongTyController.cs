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
using AIO.ViewModels.TienIchMoRong_CongTy;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    [Route("api/tienichmorongcongty")]
    [ApiController]
    public class TienIchMoRong_CongTyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TienIchMoRong_CongTyService _tienichmorong_congtyservice;
        private LoaiPhongRequestValidator validator;

        public TienIchMoRong_CongTyController(TienIchMoRong_CongTyService tienichmorong_congtyservice, ApplicationDbContext dbContext)
        {
            _tienichmorong_congtyservice = tienichmorong_congtyservice;
            _context = dbContext;
        }
        
        [HttpPost("them")]
        public async Task<IActionResult> ThemMoi([FromForm] TienIchMoRong_CongTyRequest tienichmorong_congtyrequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _tienichmorong_congtyservice.Them(tienichmorong_congtyrequest);
            //validator = new LoaiPhongRequestValidator();
            return Ok(test);
        }

        [HttpPost("sua")]
        public async Task<IActionResult> Sua([FromForm] TienIchMoRong_CongTyRequest tienichmorong_congtyrequest)
        {
            var test = await _tienichmorong_congtyservice.Sua(tienichmorong_congtyrequest);
            return Ok(test);
        }

        [HttpPost("xoa")]
        public async Task<IActionResult> Xoa(int id)
        {
            var test = await _tienichmorong_congtyservice.Xoa(id);
            return Ok(test);
        }

        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _tienichmorong_congtyservice.DanhSach();
            return Ok(test);
        }
    }
}