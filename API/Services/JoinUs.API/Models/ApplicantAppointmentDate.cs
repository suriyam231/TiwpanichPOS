using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantAppointmentDate
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
    }
}