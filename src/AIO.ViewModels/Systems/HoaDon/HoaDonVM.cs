using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.HoaDon
{
    public class HoaDonVM
    {
        public int ID_HoaDon { get; set; }
        public int ID_HinhThucThanhToan { get; set; }
        public string ID_NgonNgu { get; set; }
        public string MaHoaDon { get; set; }
        public string GioiTinh { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public float SoTienThanhToan { get; set; }
        public DateTime ThoiGianDen { get; set; }
        public string MoTa { get; set; }
        public string Link { get; set; }
        public bool DaPhanHoi { get; set; }
        public bool DaThanhToan { get; set; }
    }
}
