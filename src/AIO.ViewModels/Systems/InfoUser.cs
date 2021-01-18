using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems
{
    public class InfoUser
    {
        public int ID_TaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string TenDayDu { get; set; }
        public int ID_CongTy { get; set; }
        public int ID_KhachSan { get; set; }
        public string MaKhachSan { get; set; }
        public string KyHieuKhachSan { get; set; }

        public InfoUser()
        {
            TenDangNhap = "admin";
            TenDayDu = "admin";
            ID_KhachSan = 1;
            MaKhachSan = "KS001";
            KyHieuKhachSan = "AIO";
        }
    }
}
