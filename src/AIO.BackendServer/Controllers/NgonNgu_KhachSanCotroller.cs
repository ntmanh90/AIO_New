using AIO.BackendServer.Data;
using AIO.BackendServer.Services;
using AIO.ViewModels.Giuong;
using AIO.ViewModels.LoaiPhong;
using AIO.ViewModels.NgonNgu;
using AIO.ViewModels.NgonNgu_KhachSan;
using AIO.ViewModels.NN_KhachSan;
using AIO.ViewModels.NN_TienIchMoRong;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    [Route("api/ngonngukhachsan")]
    [ApiController]
    public class NgonNgu_KhachSanCotroller : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly NgonNgu_KhachSanService _ngonngu_khachsanservice;
        private LoaiPhongRequestValidator validator;

        public NgonNgu_KhachSanCotroller(NgonNgu_KhachSanService ngonngu_khachsanservice, ApplicationDbContext dbContext)
        {
            _ngonngu_khachsanservice = ngonngu_khachsanservice;
            _context = dbContext;
        }

        [HttpPost("them")]
        public async Task<IActionResult> ThemMoi([FromForm] NgonNgu_KhachSanRequest ngonngu_khachsanrequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = await _ngonngu_khachsanservice.Them(ngonngu_khachsanrequest);
            //validator = new LoaiPhongRequestValidator();
            return Ok(test);
        }

        [HttpPost("sua")]
        public async Task<IActionResult> Sua([FromForm] NgonNgu_KhachSanRequest ngonngu_khachsanrequest)
        {
            var test = await _ngonngu_khachsanservice.Sua(ngonngu_khachsanrequest);
            return Ok(test);
        }

        [HttpPost("xoa")]
        public async Task<IActionResult> Xoa(int id)
        {
            var test = await _ngonngu_khachsanservice.Xoa(id);
            return Ok(test);
        }

        [HttpPost("danhsach")]
        public async Task<IActionResult> DanhSach()
        {
            var test = await _ngonngu_khachsanservice.DanhSach();
            return Ok(test);
        }
    }
}