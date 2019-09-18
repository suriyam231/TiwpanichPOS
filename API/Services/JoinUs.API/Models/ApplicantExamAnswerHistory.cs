using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantExamAnswerHistory
    {
        public int Empid { get; set; }
        public string ExamType { get; set; }
        public int Seq { get; set; }
        public string Question { get; set; }
        public string QuestionImage { get; set; }
        public string QuestionType { get; set; }
        public string ChoiceType { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string Choice5 { get; set; }
        public string Choice6 { get; set; }
        public string CorrectAnswer { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UdBy { get; set; }
        public DateTime? UdDate { get; set; }
        public string ApplicantAnswer { get; set; }

        public virtual ApplicantProfile Emp { get; set; }
    }
}