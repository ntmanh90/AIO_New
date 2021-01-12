﻿using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("LoaiPhong_LoaiGiuong ")]
    public class LoaiPhong_LoaiGiuong
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int Id_LoaiGiuong { get; set; }
        public int ID_LoaiPhong{ get; set; }
        
        public bool Delete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [MaxLength(200)]
        public string CreateBy { get; set; }
        [MaxLength(200)]
        public string? ModifyBy { get; set; }

    }
}