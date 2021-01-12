using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("DichVu")]
    public class DichVu
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_DichVu { get; set; }

        public int ID_KhachSan { get; set; }

        [MaxLength(50)]
        public string MaDichVu { get; set; }
        [MaxLength(300)]
        public string TenDichvu { get; set; }
        [MaxLength(500)]
        public string AnhDaiDien { get; set; }
        public int GiaTinhTheo { get; set; }
        public float GiaTheoDichVu { get; set; }
        public float GiaTheoDemLuuTru { get; set; }
        public float GiaTheoNguoiLon { get; set; }
        public float GiaTheoTreEm { get; set; }
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