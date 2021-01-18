using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("TaiKhoan_QL_KhachSan")]
    public class TaiKhoan_QL_KhachSan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_TaiKhoan_QL_KhachSan { get; set; }
        public string ID_TaiKhoan { get; set; }
        public int ID_KhachSan { get; set; }

        public bool Delete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [MaxLength(200)]
        public string CreateBy { get; set; }
        [MaxLength(200)]
        public string? ModifyBy { get; set; }
    }
}