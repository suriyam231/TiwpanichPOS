using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class DbExamDepartmentGroup
    {
        public string ExamType { get; set; }
        public string DepartmentGroup { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string DepartmentName { get; set; }

        public virtual DbDepartmentGroup DepartmentGroupNavigation { get; set; }
        public virtual DbExamType ExamTypeNavigation { get; set; }
    }
}