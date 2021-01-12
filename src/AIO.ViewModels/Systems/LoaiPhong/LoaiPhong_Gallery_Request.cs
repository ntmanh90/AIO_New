using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.LoaiPhong
{
    public class LoaiPhong_Gallery_Request
    {
        [MaxLength(500)]
        [Required]
        public string Url_Gallery { get; set; }
    }
}
