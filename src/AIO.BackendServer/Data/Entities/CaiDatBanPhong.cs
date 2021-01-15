using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Data.Entities
{
    public class CaiDatBanPhong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_CaiDatBanPhong { get; set; }
        public int ID_LoaiPhong { get; set; }
        public int SoLuong { get; set; }
        public float GiaBan { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayCaiDat { get; set; }
    }
}
