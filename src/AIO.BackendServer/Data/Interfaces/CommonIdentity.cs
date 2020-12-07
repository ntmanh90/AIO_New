using System;
using System.ComponentModel.DataAnnotations;

namespace AIO.BackendServer.Data.Interfaces
{
    internal interface CommonIdentity
    {
        [Required]
        DateTime CreateDate { get; set; }
        DateTime? LastModifiedDate { get; set; }
        [Required]
        public int TrangThai { get; set; }
        [Required]
        public bool Delete { get; set; }
        [MaxLength(200)]
        [Required]
        public string CreateBy { get; set; }
        [MaxLength(200)]
        public string ModifyBy { get; set; }
    }
}