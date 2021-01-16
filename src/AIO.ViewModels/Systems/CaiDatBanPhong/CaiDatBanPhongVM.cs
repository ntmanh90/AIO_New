using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.CaiDatBanPhong
{
    public class CaiDatBanPhongVM
    {
        public int ID_LoaiPhong { get; set; }
        public int ID_CaiDatBanPhong { get; set; }
        public int SoLuong { get; set; }
        public float GiaBan { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayCaiDat { get; set; }
        public  List<GiaKhuyenMaiDatPhongVM> GiaKhuyenMaiDatPhongVMs { get; set; }
    }
    public class GiaKhuyenMaiDatPhongVM
    {
        public Double Price { get; set; }
    }
}
