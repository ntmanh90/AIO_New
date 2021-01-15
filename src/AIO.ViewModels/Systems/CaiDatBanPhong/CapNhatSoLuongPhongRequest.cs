using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.CaiDatBanPhong
{
    public class CapNhatSoLuongPhongRequest
    {
        public int ID_CaiDatBanPhong { get; set; }
        public int ID_LoaiPhong { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayCaiDat { get; set; }
    }
}
