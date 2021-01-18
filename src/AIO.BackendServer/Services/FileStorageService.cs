using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class FileStorageService : IStorageService
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "user-attachments";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, USER_CONTENT_FOLDER_NAME);
        }

        public string GetFileUrl(string fileName, string makhachsan)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{makhachsan}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName, string makhachsan)
        {
            string thuMucKhachSan = $"{_userContentFolder}/{makhachsan}";
            if (!Directory.Exists(thuMucKhachSan))
                Directory.CreateDirectory(thuMucKhachSan);

            var filePath = Path.Combine(thuMucKhachSan, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName, string makhachsan)
        {
            string thuMucKhachSan = $"{_userContentFolder}/{makhachsan}";
            var filePath = Path.Combine(thuMucKhachSan, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}