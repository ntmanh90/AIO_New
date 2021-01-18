using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems.NhomQuyen
{
    public class CapNhatQuyenThaoTacNhomQuyenRequest
    {
        public int ID_NhomQuyen { get; set; }
        public string ID_ChucNang { get; set; }
        public string ID_QuyenThaoTac { get; set; }
        public bool LuaChon { get; set; }
    }
}
