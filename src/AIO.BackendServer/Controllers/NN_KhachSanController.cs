using AIO.BackendServer.Data;
using AIO.BackendServer.Services;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NN_KhachSan;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    [Route("api/nnkhachsan")]
    [ApiController]
    public class NN_KhachSanController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly NN_KhachSanService _nnkhachsanService;
        private LoaiPhongRequestValidator validator;

        public NN_KhachSanController(NN_KhachSanService nn_khachsanservice, ApplicationDbContext dbContext)
        {
            _nnkhachsanService = nn_khachsanservice;
            _context = dbContext;
        }

        [HttpPost("them")]
        public async Task<IActionResult> ThemMoi([FromForm] NN_KhachSanRequest nnkhachsan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _nnkhachsanService.Them(nnkhachsan);
            //validator = new LoaiPhongRequestValidator();
            return Ok(test);
        }

        [HttpPost("sua")]
        public async Task<IActionResult> Sua([FromForm] NN_KhachSanRequest nnkhachsan)
        {
            var test = await _nnkhachsanService.Sua(nnkhachsan);
            return Ok(test);
        }

        [HttpPost("xoa")]
        public async Task<IActionResult> Xoa(int id)
        {
            var test = await _nnkhachsanService.Xoa(id);
            return Ok(test);
        }

        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _nnkhachsanService.DanhSach();
            return Ok(test);
        }
    }
}