using System;

namespace AIO.ViewModels.Systems.HoaDon
{
    public class DanhSachHoaDonVM
    {
        public int ID_HoaDon { get; set; }
        public int ID_HinhThucThanhToan { get; set; }
        public string MaHoaDon { get; set; }
        public string GioiTinh { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public float SoTienThanhToan { get; set; }
        public DateTime ThoiGianDen { get; set; }
        public bool DaPhanHoi { get; set; }
        public bool DaThanhToan { get; set; }
    }
}