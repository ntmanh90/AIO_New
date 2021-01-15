using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.UploadFile
{
    public class FileUploadRequest
    {
        public List<IFormFile> FileUploads { get; set; }
    }
}
