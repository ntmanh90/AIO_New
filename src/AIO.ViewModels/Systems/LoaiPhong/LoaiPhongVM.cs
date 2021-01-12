using AIO.ViewModels.Systems.LoaiPhong;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.LoaiPhong
{
    public class LoaiPhongVM
    {
        public int ID_LoaiPhong { get; set; }
        public int ID_HuongNhin { get; set; }
        public int NguoiLon { get; set; }
        public int TreEm { get; set; }
        public string MaLoaiPhong { get; set; } //Mã loại phòng = Ký hiệu khách sạn + 3 chữ số phía sau
        public string TenLoaiPhong { get; set; }
        public string AnhDaiDien { get; set; }
        public string KichThuoc { get; set; }
        public bool TrangThai { get; set; }

        //Ngôn ngữ cho tiêu đề loại phòng
        public List<NN_LoaiPhongVM> NN_LoaiPhongVMs { get; set; }
        public List<LoaiPhong_LoaiGiuongVM> LoaiPhong_LoaiGiuongVMs { get; set; }
        public List<LoaiPhong_TienIchVM> LoaiPhong_TienIchVMs { get; set; }

        public List<LoaiPhong_GalleryVM> LoaiPhong_GalleryVMs { get; set; }
    }
}
