using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_HoaDon { get; set; }

        public int ID_KhachSan { get; set; }
        public int ID_HinhThucThanhToan { get; set; }
        [MaxLength(10)]
        public string KyHieuNgonNgu { get; set; }
        [MaxLength(50)]
        public string MaHoaDon { get; set; }

        [MaxLength(50)]
        public string GioiTinh { get; set; }

        [MaxLength(50)]
        public string HoTen { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public float SoTienThanhToan { get; set; }
        public DateTime ThoiGianDen { get; set; }
        public string MoTa { get; set; }

        [MaxLength(1000)]
        public string Link { get; set; }

        public bool DaPhanHoi { get; set; }
        public bool DaThanhToan { get; set; }

        public bool Delete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        [MaxLength(200)]
        public string CreateBy { get; set; }

        [MaxLength(200)]
        public string? ModifyBy { get; set; }
    }
}