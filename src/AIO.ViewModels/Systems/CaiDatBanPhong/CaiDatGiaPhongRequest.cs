using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.CaiDatBanPhong
{
   public class CaiDatGiaPhongRequest
    {
        public int ID_LoaiPhong { get; set; }
        public int GiaBan { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
