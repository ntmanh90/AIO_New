using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("LoaiPhong")]
    public class LoaiPhong 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_LoaiPhong { get; set; }
        public string MaLoaiPhong { get; set; } //Mã loại phòng = Ký hiệu khách sạn + 3 chữ số phía sau
        public int ID_KhachSan { get; set; }
        public int ID_HuongNhin { get; set; }

        public int NguoiLon { get; set; }
        public int TreEm { get; set; }

        public string TenLoaiPhong { get; set; }

        public string AnhDaiDien { get; set; }

        public string KichThuoc { get; set; }
        public bool TrangThai { get ; set ; }
        public int Index { get; set; }
        public bool Delete { get ; set ; }

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public string CreateBy { get; set; }

        public string? ModifyBy { get; set; }
    }
}