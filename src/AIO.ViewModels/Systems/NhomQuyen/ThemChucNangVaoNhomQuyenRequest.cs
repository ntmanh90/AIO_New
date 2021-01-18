using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.NhomQuyen
{
    public class ThemChucNangVaoNhomQuyenRequest
    {
        public int ID_NhomQuyen { get; set; }
        public List<string> ID_ChucNangs { get; set; }
    }
}
