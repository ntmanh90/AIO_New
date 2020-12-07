using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("CauHinhKhachSan")]
    public class CauHinhKhachSan : CommonIdentity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(200)]
        [Required]
        public string KyHieuDatPhong { get; set; }
        [MaxLength(200)]
        [Required]
        public string EmailNhanPhong { get; set; }
        [MaxLength(200)]
        [Required]
        public string EmailNhanThongBao { get; set; }       
        public DateTime CreateDate { get; set ; }
        public DateTime? LastModifiedDate { get; set ; }
        public int TrangThai { get ; set ; }
        public bool Delete { get ; set ; }
        [MaxLength(200)]
        public string CreateBy { get ; set ; }
        [MaxLength(200)]
        public string ModifyBy { get ; set ; }
    }
}