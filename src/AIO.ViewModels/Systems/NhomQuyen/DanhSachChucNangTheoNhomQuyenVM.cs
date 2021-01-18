using AIO.ViewModels.Systems.QuyenThaoTac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.NhomQuyen
{
    public class DanhSachChucNangTheoNhomQuyenVM
    {
        public int ID_NhomQuyen { get; set; }
        public string ID_ChucNang { get; set; }
        public string TenChucNang { get; set; }

        public List<QuyenThaoTacVM> QuyenThaoTacVMs { get; set; }
    }
}
