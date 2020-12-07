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
        [MaxLength(200)]
        [Required]
        public string TenNgonNgu { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(200)]
        [Required]
        public string CreateBy { get; set; }
        [MaxLength(200)]
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Delete { get; set; }
       
    }
}