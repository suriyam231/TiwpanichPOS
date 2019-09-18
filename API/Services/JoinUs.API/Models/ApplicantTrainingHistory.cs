using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantTrainingHistory
    {
        public int Empid { get; set; }
        public int No { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TrainingName { get; set; }
        public string CourseName { get; set; }
        public string Certificate { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }

        public virtual ApplicantProfile Emp { get; set; }
    }
}