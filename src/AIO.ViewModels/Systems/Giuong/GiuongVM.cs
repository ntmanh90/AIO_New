﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Giuong
{
    public class GiuongVM
    {
        public int ID_LoaiGiuong { get; set; }
        public int ID_NgonNgu { get; set; }
        public string NoiDungHienThi { get; set; }
        public bool Delete { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
