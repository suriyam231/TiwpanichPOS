using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class DbExamType
    {
        public DbExamType()
        {
            DbExam = new HashSet<DbExam>();
            DbExamDepartmentGroup = new HashSet<DbExamDepartmentGroup>();
        }

        public string ExamType { get; set; }
        public string ExamTypeName { get; set; }
        public int? ExamTypeSort { get; set; }
        public string Active { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }

        public virtual ICollection<DbExam> DbExam { get; set; }
        public virtual ICollection<DbExamDepartmentGroup> DbExamDepartmentGroup { get; set; }
    }
}