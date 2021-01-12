using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.DichVu
{
    public class DichVuVM
    {
        public int ID_DichVu { get; set; }

        public string TenDichvu { get; set; }

        public string AnhDaiDien { get; set; }

        public int GiaTinhTheo { get; set; }
        public int TheoDichVu { get; set; }
        public int TheoDemLuuTru { get; set; }
        public int TheoSoNguoi { get; set; }

        public float GiaTheoDichVu { get; set; }

        public float GiaTheoDemLuuTru { get; set; }
  
        public float GiaTheoNguoiLon { get; set; }
      
        public float GiaTheoTreEm { get; set; }
        public bool TrangThai { get; set; }

        //Ngôn ngữ 
        public List<NN_DichVuVM> NN_DichVuVMs { get; set; }
    }
}
