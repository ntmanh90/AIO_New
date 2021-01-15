using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.CaiDatBanPhong
{
    public class DanhSachBanPhongVM
    {
        public int ID_LoaiPhong { get; set; }
        public string Ten_LoaiPhong { get; set; }
        public List<KhuyenMaiCuaLoaiPhongVM> KhuyenMaiCuaLoaiPhongVMs { get; set; }
        public List<CaiDatBanPhongVM> CaiDatBanPhongVMs { get; set; }
    }
}
