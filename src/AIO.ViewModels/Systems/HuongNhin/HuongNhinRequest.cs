using AIO.ViewModels.NgonNgu;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.View
{
    public class HuongNhinRequest
    {
        public int ID_HuongNhin { get; set; }
        public string TieuDe { get; set; }
        public bool TrangThai { get; set; }
        public bool Delete { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }

        public List<NN_ObjectRequest> NN_ObjectRequests { get; set; }
    }
}
