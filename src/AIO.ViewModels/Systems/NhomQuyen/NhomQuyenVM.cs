using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.NhomQuyen
{
    public class NhomQuyenVM
    {
        public int ID_NhomQuyen { get; set; }
        public string TenNhomQuyen { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
