using AIO.ViewModels.NgonNgu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.LoaiGiuong
{
    public class LoaiGiuongRequest
    {
        public int ID_LoaiGiuong { get; set; }
        [Required]
        public string TieuDe { get; set; }
        public bool TrangThai { get; set; }
        public bool Delete { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }

        public List<NN_ObjectRequest> NN_ObjectRequests { get; set; }
    }
    
}
