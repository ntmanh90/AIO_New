using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIO.BackendServer.Data.Entities
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public User()
        {
        }

        public User(string id, string userName, string maTaiKhoan, string firstName, string lastName,
            string email, string phoneNumber, DateTime dob, int id_CongTy, int id_NhomQuyen)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            MaTaiKhoan = maTaiKhoan;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Dob = dob;
            ID_CongTy = id_CongTy;
            ID_NhomQuyen = id_NhomQuyen;
        }

        [MaxLength(50)]
        [Required]
        public string MaTaiKhoan { get; set; }

        [MaxLength(50)]
        [Required]

        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Dob { get; set; }
        public int ID_CongTy { get; set; }
        public int ID_NhomQuyen { get; set; }
        public bool TrangThai { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string CreateBy { get; set; }
        [MaxLength(200)]
        public string ModifyBy { get; set; }
    }
}
