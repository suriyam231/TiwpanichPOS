using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.DTOs
{
    public class EmployeeDTO
    {
        public string Empcode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstnameEn { get; set; }
        public string LastnameEn { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
    }
}
