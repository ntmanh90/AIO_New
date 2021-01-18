using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("NhomQuyen")]
    public class NhomQuyen 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_NhomQuyen { get; set; }
        public int ID_KhachSan { get; set; }

        [MaxLength(50)]
        public string MaNhomQuyen { get; set; }
        [MaxLength(200)]
        public string TenNhomQuyen { get; set; }

        public bool Delete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreateBy { get; set; }
        [MaxLength(200)]
        public string? ModifyBy { get; set; }
    }
}