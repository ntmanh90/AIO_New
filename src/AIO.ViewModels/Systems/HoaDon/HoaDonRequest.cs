using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.HoaDon
{
    public class HoaDonRequest
    {
        public int ID_HoaDon { get; set; }
        [Required]
        [MaxLength(10)]
        public string ID_NgonNgu { get; set; }
        [Required]
        public int ID_HinhThucThanhToan { get; set; }
        [MaxLength(50)]
        [Required]
        public string GioiTinh { get; set; }
        [MaxLength(50)]
        [Required]
        public string HoTen { get; set; }
        [MaxLength(100)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public float SoTienThanhToan { get; set; }
        [Required]
        public DateTime ThoiGianDen { get; set; }
        public string MoTa { get; set; }

        [MaxLength(1000)]
        public string Link { get; set; }

        public bool DaPhanHoi { get; set; }
        public bool DaThanhToan { get; set; }

    }
}
