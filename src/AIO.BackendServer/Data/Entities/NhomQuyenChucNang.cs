using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("NhomQuyenChucNang")]
    public class NhomQuyenChucNang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_NhomQuyenChucNang { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar(50)")]
        public string ID_ChucNang { get; set; }
        public int ID_NhomQuyen { get; set; }
        public int ID_KhachSan { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar(50)")]
        public string ID_QuyenThaoTac { get; set; }
    }
}