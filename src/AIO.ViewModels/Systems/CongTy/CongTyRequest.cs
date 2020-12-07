using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.CongTy
{
    public class CongTyRequest
    {
        public int ID_CongTy { get; set; }
  
        public string TenCongTy { get; set; }
        
        public string DiaChiCongTy { get; set; }
        
        public string MaCongTy { get; set; }
               
        public string EmailCongTy { get; set; }
        
        public string AnhDaiDien { get; set; }
        
        public string NguoiDaiDien { get; set; }
        
        public string Hotline { get; set; }
        
        public string DienThoaiBan { get; set; }
        
        public string SoDiDong { get; set; }
    
        public string Note { get; set; }
       
        public int TrangThai { get ; set ; }
      
        public string CreateBy { get ; set ; }
        
        public string ModifyBy { get ; set ; }
    }
}
