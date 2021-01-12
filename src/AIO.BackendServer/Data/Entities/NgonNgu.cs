using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("NgonNgu")]
    public class NgonNgu 
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_NgonNgu { get; set; }
        [MaxLength(10)]
        [Required]
        public string KyHieu { get; set; }
        [MaxLength(200)]
        [MinLength(5)]
        [Required]
        public string TieuDe { get; set; }
        public DateTime? CreateDate { get; set; }
        [MaxLength(200)]
  
        public string? CreateBy { get; set; }
        [MaxLength(200)]
        public string? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool Delete { get; set; }
       
    }
}