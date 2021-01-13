using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.KhuyenMaiDatPhong
{
    public class KhuyenMaiDatPhongRequest
    {
        public int ID_KhuyenMaiDatPhong { get; set; }

        [MaxLength(300)]
        [Required]
        public string TenKhuyenMaiDatPhong { get; set; }
        [Required]
        public int SoNgayLuuTruToiThieu { get; set; }
        [Required]
        public int SoNgayDatTruoc { get; set; }
        [Required]
        public float GiaCongThem { get; set; }
        [Required]
        public float PhanTramGiamGia { get; set; }
        [Required]
        public float PhanTramDatCoc { get; set; }
        public bool BaoGomAnSang { get; set; }
        public bool DuocPhepHuy { get; set; }
        public bool DuocPhepThayDoi { get; set; }
        [Required]
        public DateTime NgayBatDau { get; set; }
        [Required]
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

        public List<NN_KhuyenMaiDatPhongRequest> NN_KhuyenMaiDatPhongRequests { get; set; }
    }
}
