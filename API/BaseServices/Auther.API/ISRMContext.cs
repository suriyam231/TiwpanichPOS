using Auther.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.Models
{
    public interface ISRMContext
    {
        //DbSet<AuAuthentication> AuAuthentication { get; set; }
        DbSet<EmployeeProfile> EmployeeProfile { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<DbPosition> DbPosition { get; set; }
        int SaveChanges();
    }



    public partial class SRMContext : DbContext, ISRMContext
    {


    }
}
