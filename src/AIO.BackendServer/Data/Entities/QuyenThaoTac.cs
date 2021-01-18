using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("QuyenThaoTac")]
    public class QuyenThaoTac
    {
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [Key]
        public string ID_QuyenThaoTac { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}