using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.KhuyenMaiDatPhong
{
   public class NN_KhuyenMaiDatPhongRequest
    {
        public int ID_NgonNgu { get; set; }
        [MaxLength(500)]
        public string TenTheoNgonNgu { get; set; }
        public string DieuKhoan_DieuKien { get; set; }
    }
}
