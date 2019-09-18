using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ApplicantInterviewerDTO
    {
        public int Empid { get; set; }
        public string FirstnameTh { get; set; }
        public string LastnameTh { get; set; }
        public string Tel { get; set; }
        public string Position { get; set; }
        public string StatusApplicant { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string TypeEmployee { get; set; }
    }
}
