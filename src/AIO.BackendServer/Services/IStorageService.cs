using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName, string makhachsan);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName, string makhachsan);

        Task DeleteFileAsync(string fileName, string makhachsan);
    }
}