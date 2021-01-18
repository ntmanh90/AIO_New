using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.NhomQuyen
{
    public class ThemTaiKhoanVaoNhomQuyenRequest
    {
        public int ID_NhomQuyen { get; set; }
        public List<string> ID_TaiKhoans { get; set; }
    }
}
