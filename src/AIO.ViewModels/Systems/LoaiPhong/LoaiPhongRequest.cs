using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.LoaiPhong
{
    public class LoaiPhongRequest
    {       
        public int ID { get; set; }
        public string TenLoaiPhongTV { get; set; }
        public string TenLoaiPhongTA { get; set; }
        public string LogoKhachSan { get; set; }
        public string Hotline { get; set; }
        public string SoDiDong { get; set; }   
        public string SoMayBan { get; set; }
        public string SoFax { get; set; }
        public string Email { get; set; }
        public string DiaChiKhachSan { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public int TrangThai { get; set; }
        public bool Delete { get; set; }
    }
}
