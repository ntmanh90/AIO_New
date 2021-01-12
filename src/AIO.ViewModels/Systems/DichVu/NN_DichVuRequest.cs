using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIO.ViewModels.Systems.DichVu
{
    public class NN_DichVuRequest
    {
        public int ID_NgonNgu { get; set; }
        [MaxLength(500)]
        public string TenTheoNgonNgu { get; set; }
        public string NoiDungTheoNgonNgu { get; set; }
    }
}
