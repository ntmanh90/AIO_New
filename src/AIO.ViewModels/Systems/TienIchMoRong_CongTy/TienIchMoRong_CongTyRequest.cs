using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.TienIchMoRong_CongTy
{
    public class TienIchMoRong_CongTyRequest
    {
       
        public int ID_CongTy { get; set; }
        public int ID_TienIchMoRong { get; set; }
        public string TenTienich { get; set; }
        public bool TrangThai { get; set; }
        public bool Delete { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
