using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.NN_TienIchMoRong
{
    public class NN_TienIchMoRongRequest
    {
        public int Id_NgonNgu { get; set; }
        public int ID_CongTy { get; set; }
        public int ID_TienichMoRong { get; set; }
        public string NoiDungHienThi { get; set; }
        public bool Delete { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
