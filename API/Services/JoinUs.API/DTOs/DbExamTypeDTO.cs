using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class DbExamTypeDTO
    {
        public string ExamType { get; set; }
        public string ExamTypeName { get; set; }
        public int? ExamTypeSort { get; set; }
        public string Active { get; set; }
        public string CrBy { get; set; }
        public string ExamTypecolumn { get; set; }
        public DateTime? CrDate { get; set; }
    }
}
