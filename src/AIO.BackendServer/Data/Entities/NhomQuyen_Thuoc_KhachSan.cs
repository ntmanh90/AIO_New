using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("NhomQuyen_Thuoc_KhachSan")]
    public class NhomQuyen_Thuoc_KhachSan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_NhomQuyen_Thuoc_KhachSan { get; set; }
        public int ID_NhomQuyen { get; set; }
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