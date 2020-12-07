using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("KhachSan")]
    public class KhachSan : CommonIdentity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_KhachSan { get; set; }
        [MaxLength(200)]
        [Required]
        public string MaKhachSan { get; set; }
        [MaxLength(200)]
        [Required]
        public string TenKhachSan { get; set; }
        [MaxLength(200)]
        [Required]
        public string LogoKhachSan { get; set; }
        [MaxLength(200)]
        public string Hotline { get; set; }
        [MaxLength(50)]
        [Required]
        public string SoDiDong { get; set; }
        [MaxLength(200)]
        public string SoMayBan { get; set; }
        [MaxLength(200)]
        public string SoFax { get; set; }
        [MaxLength(200)]
        [Required]
        public string Email { get; set; }
        [MaxLength(200)]
        [Required]
        public string DiaChiKhachSan { get; set; }
        [MaxLength(200)]
        public string Website { get; set; }
        [MaxLength(200)]
        public string Facebook { get; set; }
        [MaxLength(2000)]
        public string Twitter { get; set; }
        [MaxLength(2000)]
        public string Youtube { get; set; }
        [MaxLength(2000)]
        public string Instagram { get; set; }
        public DateTime CreateDate { get; set ; }
        public DateTime? LastModifiedDate { get; set ; }
        public int TrangThai { get ; set ; }
        public bool Delete { get ; set ; }
        [MaxLength(200)]
        public string CreateBy { get ; set ; }
        [MaxLength(200)]
        public string ModifyBy { get ; set ; }

        [MaxLength(200)]
        public string GioiThieu { get; set; }

        [MaxLength(200)]
        public string ViTri { get; set; }


    }
}