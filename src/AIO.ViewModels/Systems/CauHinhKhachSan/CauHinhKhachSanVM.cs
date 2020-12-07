using System;

namespace AIO.ViewModels.CauHinhKhachSan
{
    public class CauHinhKhachSanVM
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