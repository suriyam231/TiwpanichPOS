using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.DTOs
{
    public class TokenDTO
    {
        public string empCode { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FirstnameTH { get; set; }
        public string LastnameTH { get; set; }
        public string Email { get; set; }
        public string DepartmentGroup { get; set; }
        public string Department { get; set; }
        public string PositionCode { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy{ get; set; }
        public DateTime ExpiresDate { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }

    }
}
