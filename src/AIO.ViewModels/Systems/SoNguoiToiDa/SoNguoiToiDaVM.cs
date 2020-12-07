using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.SoNguoiToiDa
{
    public class SoNguoiToiDaVM
    {
        public int ID_SoNguoiToiDa { get; set; }
        public int ID_NgonNgu { get; set; }
        public string NoiDungHienThi { get; set; }
        public bool Delete { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
