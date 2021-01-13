using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.KhuyenMaiDatPhong
{
    public class KhuyenMaiDatPhongListVM
    {
        public int ID_KhuyenMaiDatPhong { get; set; }
        public string MaKhuyenMaiDatPhong { get; set; }
        public string TenKhuyenMaiDatPhong { get; set; }
        public int SoNgayLuuTruToiThieu { get; set; }
        public int SoNgayDatTruoc { get; set; }
        public float GiaCongThem { get; set; }
        public float PhanTramGiamGia { get; set; }
        public float PhanTramDatCoc { get; set; }
        public bool BaoGomAnSang { get; set; }
        public bool DuocPhepHuy { get; set; }
        public bool DuocPhepThayDoi { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public bool TrangThai { get; set; }

    }
}
