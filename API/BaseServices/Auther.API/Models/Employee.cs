using System;
using System.Collections.Generic;

namespace Auther.API.Models
{
    public partial class Employee
    {
        public string Empcode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Passwordsalt { get; set; }
        public int Failtime { get; set; }
        public DateTime? Passwordexpirydate { get; set; }
        public bool Active { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}