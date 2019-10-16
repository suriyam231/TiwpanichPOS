using System;
using System.Collections.Generic;

namespace Database.API.Models
{
    public partial class ProfileUser
    {
        public int UserId { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public string LocationNumber { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string ZipCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}