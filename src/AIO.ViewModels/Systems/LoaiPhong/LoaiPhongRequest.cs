using AIO.ViewModels.NgonNgu;
using AIO.ViewModels.Systems.Common;
using AIO.ViewModels.Systems.LoaiPhong;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.LoaiPhong
{
    public class LoaiPhongRequest
    {
        public int ID_LoaiPhong { get; set; }
        [Required] 
        public int ID_HuongNhin { get; set; }
        [Required]
        public int NguoiLon { get; set; }
        [Required]
        public int TreEm { get; set; }
        [MaxLength(50)]
        [Required]
        public string MaLoaiPhong { get; set; } //Mã loại phòng = Ký hiệu khách sạn + 3 chữ số phía sau
        [MaxLength(500)]
        [Required]
        public string TenLoaiPhong { get; set; }
        [MaxLength(500)]
        [Required]
        public string AnhDaiDien { get; set; }
        [MaxLength(200)]
        [Required]
        public string KichThuoc { get; set; }
        [Required]
        public int Index { get; set; }
        public bool TrangThai { get; set; }

        //Ngôn ngữ cho tiêu đề loại phòng
        public List<NN_LoaiPhongRequest> NN_LoaiPhongRequests { get; set; }
        public List<LoaiPhong_LoaiGiuong_Request> LoaiPhong_LoaiGiuong_Requests { get; set; }
        public List<LoaiPhong_TienIch_Request> LoaiPhong_TienIch_Requests { get; set; }

        public List<LoaiPhong_Gallery_Request> loaiPhong_Gallery_Requests { get; set; }

    }
}
