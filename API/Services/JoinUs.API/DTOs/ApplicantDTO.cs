using RegisterManange.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListApplicant.API.DTOs
{
    public class ApplicantDTO
    {
        public ApplicantDTO()
        {
            ApplicantProfile = new ApplicantProfileDTO();
            ApplicantEduHistories = new List<ApplicantEduHistoryDTO>();
            ApplicantWorkingHistories = new List<ApplicantWorkingHistoryDTO>();
            ApplicantTrainingHistories = new List<ApplicantTrainingHistoryDTO>();
            ApplicantSkillLanguages = new List<ApplicantSkillLanguageDTO>();
            ApplicantSkill = new ApplicantSkillDTO();
            ApplicantRef = new List<ApplicantRefDTO>();
            ApplicantAppointmentDates = new ApplicantAppointmentDateDTO();
        }

        public ApplicantProfileDTO ApplicantProfile { get; set; }
        public List<ApplicantEduHistoryDTO> ApplicantEduHistories { get; set; }
        public List<ApplicantWorkingHistoryDTO> ApplicantWorkingHistories { get; set; }
        public List<ApplicantTrainingHistoryDTO> ApplicantTrainingHistories { get; set; }
        public List<ApplicantSkillLanguageDTO> ApplicantSkillLanguages { get; set; }
        public ApplicantSkillDTO ApplicantSkill { get; set; }
        public List<ApplicantRefDTO> ApplicantRef { get; set; }
        public ApplicantAppointmentDateDTO ApplicantAppointmentDates { get; set; }
    }
}
