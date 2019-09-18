using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class DbDepartmentGroup
    {
        public DbDepartmentGroup()
        {
            DbExamDepartmentGroup = new HashSet<DbExamDepartmentGroup>();
        }

        public string DepartmentGroup { get; set; }
        public string DepartmentName { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }

        public virtual ICollection<DbExamDepartmentGroup> DbExamDepartmentGroup { get; set; }
    }
}