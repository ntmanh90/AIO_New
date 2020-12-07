using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.CauHinhKhachSan
{
    public class CauHinhKhachSanRequest
    {
        public int ID { get; set; }
        public string KyHieuDatPhong { get; set; }
        public string EmailNhanPhong { get; set; }
        public string EmailNhanThongBao { get; set; }
        public int TrangThai { get; set; }
        public bool Delete { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
