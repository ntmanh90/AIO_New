using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.NhomQuyen
{
    public class NhomQuyenRequest
    {
        public int ID_NhomQuyen { get; set; }
        [Required]
        [MaxLength(200)]
        public string TenNhomQuyen { get; set; }
    }
}
