using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ApplicantAppointmentDateDTO
    {
        public string Username { get; set; }
        public int Empid { get; set; }
        public DateTime? Datetime1 { get; set; }
        public DateTime? Datetime2 { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentStatus { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }

        public static implicit operator ApplicantAppointmentDateDTO(List<ApplicantAppointmentDateDTO> v)
        {
            throw new NotImplementedException();
        }
    }
}
