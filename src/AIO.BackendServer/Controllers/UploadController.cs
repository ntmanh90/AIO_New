using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Helpers;
using AIO.BackendServer.Services;
using AIO.ViewModels.Systems;
using AIO.ViewModels.Systems.UploadFile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    public class UploadController: BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IStorageService _storageService;
        InfoUser infoUser = new InfoUser();

        public UploadController(ApplicationDbContext context,
            ISequenceService sequenceService,
            IStorageService storageService )
        {
            _context = context;
            _storageService = storageService;
           
        }

        [HttpPost("upload-file")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload([FromForm] FileUploadRequest request)
        {
            List<FileUploadVM> fileUploadVMs = new List<FileUploadVM>();
            if(request.FileUploads.Count > 0)
            {
                foreach (var attachment in request.FileUploads)
                {
                    if(attachment.Length < 1097152)
                    {
                        var attachmentEntity = await SaveFile(infoUser.ID_KhachSan, attachment);
                        _context.Attachments.Add(attachmentEntity);
                        _context.SaveChanges();
                        fileUploadVMs.Add(new FileUploadVM
                        {
                            NameFile = attachmentEntity.FileName,
                            UrlFile = attachmentEntity.FilePath
                        });
                    }    
                }
                return Ok(fileUploadVMs);
            }
            return NoContent();
        }

        [HttpGet("list-file")]
        public async Task<IActionResult> ListFile()
        {
            var result = await _context.Attachments.Where(a => a.ID_KhachSan == infoUser.ID_KhachSan).OrderBy(a=>a.Id).AsQueryable().ToListAsync();
            return Ok(result);
        }

        private async Task<Attachment> SaveFile(int id_khachsan, IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{TextHelper.RandomString(30)}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName, infoUser.MaKhachSan);
            var attachmentEntity = new Attachment()
            {
                FileName = fileName,
                FilePath = _storageService.GetFileUrl(fileName, infoUser.MaKhachSan),
                FileSize = file.Length,
                FileType = Path.GetExtension(fileName),
                ID_KhachSan = id_khachsan
            };
            return attachmentEntity;
        }
    }
}
