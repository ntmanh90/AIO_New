using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.NgonNgu_KhachSan
{
    public class NgonNgu_KhachSanVM
    {
        public int ID_KhachSan { get; set; }
        public int ID_NgonNgu { get; set; }
        public bool TrangThai { get; set; }
        public bool MacDinh { get; set; }
        public bool Delete { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
