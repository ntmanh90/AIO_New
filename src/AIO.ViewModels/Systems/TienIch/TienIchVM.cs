using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.TienIch
{
    public class TienIchVM
    {
        public int ID_TienIch { get; set; }
        public int ID_NgonNgu { get; set; }
        public string NoiDungHienThi { get; set; }
        public bool Delete { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
