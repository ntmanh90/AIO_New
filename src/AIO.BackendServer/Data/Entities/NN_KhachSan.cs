using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("NN_KhachSan")]
    public class NN_KhachSan
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_KhachSan { get; set; }
        [MaxLength(200)]
        [Required]
        public int ID_NgonNgu { get; set; }
        [MaxLength(500)]
        [Required]
        public string TenKhachSan { get; set; }
        [MaxLength(500)]
        [Required]
        public string GioiThieu { get; set; }
        public bool Delete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [MaxLength(200)]
        public string CreateBy { get; set; }
        [MaxLength(200)]
        public string ModifyBy { get; set; }

    }
}