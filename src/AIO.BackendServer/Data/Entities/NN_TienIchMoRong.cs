﻿using AIO.BackendServer.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("NN_TienIchMoRong")]
    public class NN_TienIchMoRong
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_NgonNgu { get; set; }
        public int ID_CongTy { get; set; }
        public int ID_TienichMoRong { get; set; }
        public string NoiDungHienThi { get; set; }
        public bool Delete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [MaxLength(200)]
        public string CreateBy { get; set; }
        [MaxLength(200)]
        public string ModifyBy { get; set; }

    }
}