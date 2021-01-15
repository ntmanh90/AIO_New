using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.CaiDatBanPhong
{
   public class CaiDatTrangThaiPhongRequest
    {
        public int ID_LoaiPhong { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
