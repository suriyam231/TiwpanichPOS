using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ApplicantInterestingDTO
    {
        public ApplicantProfileDTO Applicant_Profile { get; set; }
        public ApplicantAppointmentDateDTO Applicant_AppointmentDate { get; set; }
    }
}
