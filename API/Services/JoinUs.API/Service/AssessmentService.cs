using AssessmentByPM.API.Interface;
using System.Collections.Generic;
using System;
using System.Linq;
using RegisterManange.API.Models;
using RegisterManange.API.DTOs;
using System.Threading.Tasks;

namespace AssessmentByPM.API.Service
{
    public class AssessmentService : AssessmentInterface
    {
        private readonly SRM_DEVContext Context;
        public AssessmentService(SRM_DEVContext context)
        {
            Context = context;
        }
        public List<ApplicantInterviewerDTO> GetDataAssessmenByPM(string team)
        {
            List<ApplicantInterviewerDTO> Interviewer = (from profile in Context.ApplicantProfile
                                                               join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                                                               where profile.StatusApplicant == "Contact_Inte" && profile.Team == team
                                                               orderby appointment.CrDate descending
                                                         select new ApplicantInterviewerDTO
                                                               {
                                                                   Empid = appointment.Empid,
                                                                   FirstnameTh = profile.FirstnameTh,
                                                                   LastnameTh = profile.LastnameTh,
                                                                   Tel = profile.Tel,
                                                                   Position = profile.Position,
                                                                   StatusApplicant = profile.StatusApplicant,
                                                                   AppointmentDate = appointment.AppointmentDate.Value,
                                                                   TypeEmployee = profile.TypeEmployee
                                                               }).ToList();

            return Interviewer;
        }

        public ApplicantAssessmentDTO GetDataAssessmentPmByID(int empID)
        {
            ApplicantAssessmentDTO listData = new ApplicantAssessmentDTO();

            ApplicantProfile applicantProfile = new ApplicantProfile();

            applicantProfile = Context.ApplicantProfile.Where(x => x.Empid == empID).FirstOrDefault();

            listData.Empid = applicantProfile.Empid;
            listData.FirstnameTh = applicantProfile.FirstnameTh;
            listData.LastnameTh = applicantProfile.LastnameTh;
            listData.Position = applicantProfile.Position;


            return listData;
        }

        public List<ApplicantInterviewerDTO> GetDataAssessmentByPM(string name, string date, string team,string type)
        {
            List<ApplicantInterviewerDTO> result;

            string firstName = string.Empty;
            string lastName = string.Empty;
            if (!string.IsNullOrWhiteSpace(name))
            {
                string[] fullName = name.Split(' ');
                if (fullName.Length > 1)
                {
                    firstName = fullName[0].Trim();
                    lastName = fullName[1].Trim();
                }
                else
                {
                    firstName = fullName[0].Trim();
                }
            }
            string[] applicantType;
            if (type == "A")
            {
                applicantType = new string[] { "P", "T" };
            }
            else
            {
                applicantType = new String[] { type };
            }

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(date))
            {
                string dateFromParse = DateTime.Parse(date).ToString("yyyy-MM-dd");
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where profile.StatusApplicant == "Contact_Inte" && profile.Team == team &&  (profile.FirstnameEn.Contains(name) || profile.LastnameEn.Contains(name) || profile.FirstnameTh.Contains(name) || profile.LastnameTh.Contains(name) || (profile.FirstnameTh.Contains(firstName) && profile.LastnameTh.Contains(lastName)) ) && (appointment.AppointmentDate.Value.Date.ToString() == dateFromParse) && applicantType.Contains(profile.TypeEmployee)
                          orderby appointment.CrDate descending
                          select new ApplicantInterviewerDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              AppointmentDate = appointment.AppointmentDate.Value,
                              TypeEmployee = profile.TypeEmployee

                          }).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where profile.StatusApplicant == "Contact_Inte" && profile.Team == team && (profile.FirstnameEn.Contains(name) || profile.LastnameEn.Contains(name) || profile.FirstnameTh.Contains(name) || profile.LastnameTh.Contains(name) || (profile.FirstnameTh.Contains(firstName) && profile.LastnameTh.Contains(lastName)) ) && applicantType.Contains(profile.TypeEmployee)
                          orderby appointment.CrDate descending
                          select new ApplicantInterviewerDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              AppointmentDate = appointment.AppointmentDate.Value,
                              TypeEmployee = profile.TypeEmployee

                          }).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(date))
            {
                string dateFromParse = DateTime.Parse(date).ToString("yyyy-MM-dd");
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where profile.StatusApplicant == "Contact_Inte" && profile.Team == team && appointment.AppointmentDate.Value.Date.ToString() == dateFromParse && applicantType.Contains(profile.TypeEmployee)
                          orderby appointment.CrDate descending
                          select new ApplicantInterviewerDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              AppointmentDate = appointment.AppointmentDate.Value,
                              TypeEmployee = profile.TypeEmployee
                          }).ToList();
            }
            else
            {
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where profile.StatusApplicant == "Contact_Inte" && profile.Team == team && applicantType.Contains(profile.TypeEmployee)
                          orderby appointment.CrDate descending
                          select new ApplicantInterviewerDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              AppointmentDate = appointment.AppointmentDate.Value,
                              TypeEmployee = profile.TypeEmployee

                          }).ToList();
            }

            return result;
        }

        public async Task<string> SaveAssessmentOnline(ApplicantAssessmentDTO data,string name)
        {
            try
            {
                ApplicantAssetment assetment = new ApplicantAssetment();

                assetment.Empid = data.Empid;
                assetment.Per01 = data.Per_01;
                assetment.Per02 = data.Per_02;
                assetment.Per03 = data.Per_03;
                assetment.Per04 = data.Per_04;
                assetment.Edu01 = data.Edu_01;
                assetment.Edu02 = data.Edu_02;
                assetment.Edu03 = data.Edu_03;
                assetment.Edu04 = data.Edu_04;
                assetment.Oth01 = data.Oth_01;
                assetment.Oth02 = data.Oth_02;
                assetment.Recomment = data.Recomment;
                assetment.SummAss = data.Summ_Ass;
                assetment.CrBy = name;
                assetment.CrDate = DateTime.Today;

                Context.ApplicantAssetment.Add(assetment);
                Context.SaveChanges();


                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateStatus(int id, string status,string name)
        {
            try
            {
                
                    ApplicantProfile applicantProfile = new ApplicantProfile();
                    applicantProfile = Context.ApplicantProfile.Where(x => x.Empid == id).FirstOrDefault();
                    applicantProfile.UpdBy = name;
                    applicantProfile.UpdDate = DateTime.Now;
                    applicantProfile.StatusApplicant = status;
                    Context.ApplicantProfile.Update(applicantProfile);
                    Context.SaveChanges();
                

                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail";
            }
        }

    }
}
