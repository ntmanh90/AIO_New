using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.KhuyenMaiDatPhong
{
    public class KhuyenMaiDatPhongVM
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
        public bool TatCaNgayTrongTuan { get; set; }
        public bool ThuHai { get; set; }
        public bool ThuBa { get; set; }
        public bool ThuTu { get; set; }
        public bool ThuNam { get; set; }
        public bool ThuSau { get; set; }
        public bool ThuBay { get; set; }
        public bool ChuNhat { get; set; }
        public bool TrangThai { get; set; }


        public List<NN_KhuyenMaiDatPhongVM> NN_KhuyenMaiDatPhongVMs { get; set; }
    }
}
