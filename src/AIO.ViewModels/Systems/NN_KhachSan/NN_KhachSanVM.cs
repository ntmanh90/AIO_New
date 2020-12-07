using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.NN_KhachSan
{
    public class NN_KhachSanVM
    {
        public int ID_KhachSan { get; set; }
        public int ID_NgonNgu { get; set; }
        public string TenKhachSan { get; set; }
        public string GioiThieu { get; set; }
        public bool Delete { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
