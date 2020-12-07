using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.NgonNgu
{
    public class NgonNguVM
    {
        public int ID_NgonNgu { get; set; }
        public string TenNgonNgu { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
        public bool Delete { get; set; }
    }
}
