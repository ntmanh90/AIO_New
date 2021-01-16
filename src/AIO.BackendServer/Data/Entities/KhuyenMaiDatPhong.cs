using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("KhuyenMaiDatPhong")]
    public class KhuyenMaiDatPhong
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_KhuyenMaiDatPhong { get; set; }

        public int ID_KhachSan { get; set; }

        [MaxLength(50)]
        public string MaKhuyenMaiDatPhong { get; set; }
        [MaxLength(300)]
        public string TenKhuyenMaiDatPhong { get; set; }
        [MaxLength(500)]
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
        public int Index { get; set; }
        public bool TrangThai { get; set; }

        public bool Delete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [MaxLength(200)]
        public string CreateBy { get; set; }
        [MaxLength(200)]
        public string? ModifyBy { get; set; }

    }
}