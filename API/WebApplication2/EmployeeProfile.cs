using System;
using System.Collections.Generic;

namespace WebApplication2
{
    public partial class EmployeeProfile
    {
        public string Empcode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstnameTh { get; set; }
        public string LastnameTh { get; set; }
        public string FirstnameEn { get; set; }
        public string LastnameEn { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
        public string IdCard { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string PostalCode { get; set; }
        public string ImgPath { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
        public bool Active { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}