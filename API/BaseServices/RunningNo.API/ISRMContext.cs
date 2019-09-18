using Microsoft.EntityFrameworkCore;
using RunningNo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningNo.API.Models
{
    public interface ISRMContext
    {
        DbSet<RuRunningNo> RuRunningNo { get; set; }
        DbSet<RuRunningType> RuRunningType { get; set; }
        int SaveChanges();
    }
        public partial class SRM_DEVContext : DbContext, ISRMContext
        {


        }
    
}
