using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("CongTy")]
    public class CongTy : CommonIdentity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_CongTy { get; set; }
        [MaxLength(200)]
        [Required]
        public string TenCongTy { get; set; }
        [MaxLength(200)]
        public string DiaChiCongTy { get; set; }
        [MaxLength(50)]
        [Required]
        public string MaCongTy { get; set; }
        [MaxLength(200)]
        [Required]
        public string EmailCongTy { get; set; }
        [MaxLength(200)]
        public string AnhDaiDien { get; set; }
        [MaxLength(200)]
        [Required]
        public string NguoiDaiDien { get; set; }
        [MaxLength(200)]
        [Required]
        public string Hotline { get; set; }
        [MaxLength(200)]
        public string DienThoaiBan { get; set; }
        [MaxLength(200)]
        public string SoDiDong { get; set; }
        [MaxLength(2000)]
        public string Note { get; set; }
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