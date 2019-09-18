using ResoucreManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResoucreManager.API.DTOs
{
    public class EmployeeDTO
    {
        public EmployeeDTO()
        {
            EmployeeProfile = new EmployeeProfile();
        }

        public EmployeeProfile EmployeeProfile { get; set; }
    }
}
