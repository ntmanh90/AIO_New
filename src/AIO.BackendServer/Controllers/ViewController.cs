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
using AIO.ViewModels.View;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    [Route("api/view")]
    [ApiController]
    public class ViewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ViewService _viewservice;
        private LoaiPhongRequestValidator validator;

        public ViewController(ViewService viewservice, ApplicationDbContext dbContext)
        {
            _viewservice = viewservice;
            _context = dbContext;
        }

        [HttpPost("them")]
        public async Task<IActionResult> ThemMoi([FromForm] ViewRequest viewrequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _viewservice.Them(viewrequest);
            //validator = new LoaiPhongRequestValidator();
            return Ok(test);
        }

        [HttpPost("sua")]
        public async Task<IActionResult> Sua([FromForm] ViewRequest viewrequest)
        {
            var test = await _viewservice.Sua(viewrequest);
            return Ok(test);
        }

        [HttpPost("xoa")]
        public async Task<IActionResult> Xoa(int id)
        {
            var test = await _viewservice.Xoa(id);
            return Ok(test);
        }

        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _viewservice.DanhSach();
            return Ok(test);
        }
    }
}