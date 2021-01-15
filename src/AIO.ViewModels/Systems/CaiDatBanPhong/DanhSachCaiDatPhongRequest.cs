using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.CaiDatBanPhong
{
    public class DanhSachCaiDatPhongRequest
    {
        [Required]
        public  DateTime TuNgay { get; set; }

        [MaxLength(60)]
        [Required]
        public int KhoangNgay { get; set; }
    }
}
