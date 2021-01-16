using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.DichVu
{
    public class DichVuRequest
    {
        public int ID_DichVu { get; set; }
        [MaxLength(300)]
        [Required]
        public string TenDichvu { get; set; }
        [MaxLength(500)]
        [Required]
        public string AnhDaiDien { get; set; }
        [Required]
        public int GiaTinhTheo { get; set; }
        [Required]
        public float GiaTheoDichVu { get; set; }
        [Required]
        public float GiaTheoDemLuuTru { get; set; }
        [Required]
        public float GiaTheoNguoiLon { get; set; }
        [Required]
        public float GiaTheoTreEm { get; set; }
        [Required]
        public int Index { get; set; }
        public bool TrangThai { get; set; }

        //Ngôn ngữ 
        public List<NN_DichVuRequest> NN_DichVuRequests { get; set; }
    }
}
