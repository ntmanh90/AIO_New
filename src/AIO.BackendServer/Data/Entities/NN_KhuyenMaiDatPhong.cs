using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("NN_KhuyenMaiDatPhong")]
    public class NN_KhuyenMaiDatPhong
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int Id_NgonNgu { get; set; }
        public int ID_KhuyenMaiDatPhong{ get; set; }
        [MaxLength(300)]
        public string TenTheoNgonNgu { get; set; }
        public string DieuKhoan_DieuKien { get; set; }
        public bool Delete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [MaxLength(200)]
        public string CreateBy { get; set; }
        [MaxLength(200)]
        public string? ModifyBy { get; set; }

    }
}