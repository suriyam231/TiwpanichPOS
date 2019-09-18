using ListInteresting.API.Interface;
using ListApplicant.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterManange.API.Models;
using RegisterManange.API.DTOs;

namespace ListInteresting.API.Service
{
    public class ListInterestingService : ListInterestingInterface
    {
        private readonly SRM_DEVContext Context;

        public ListInterestingService(SRM_DEVContext context)
        {
            Context = context;
        }



        public List<ApplicantInterestingsDTO> getDataIntertings()
        {
            List<ApplicantInterestingsDTO> applicantProfile = (from profile in Context.ApplicantProfile
                                                               join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                                                               where profile.StatusApplicant == "Pass_PM" || profile.StatusApplicant == "Contact_Cnot"
                                                               orderby profile.CrDate descending
                                                               select new ApplicantInterestingsDTO
                                                               {
                                                                   Empid = appointment.Empid,
                                                                   FirstnameTh = profile.FirstnameTh,
                                                                   LastnameTh = profile.LastnameTh,
                                                                   Tel = profile.Tel,
                                                                   Position = profile.Position,
                                                                   StatusApplicant = profile.StatusApplicant,
                                                                   DateTime_1 = (appointment.Datetime1).Value,
                                                                   DateTime_2 = (appointment.Datetime2).Value,
                                                                   TypeEmployee = profile.TypeEmployee
                                                               }).ToList();

            return applicantProfile;
        }
        
        //Join table listapplcantByPM Join DateTime
        public List<ApplicantInterestingsDTO> getDataIntertingsss()
        {
            List<ApplicantInterestingsDTO> applicantProfile = (from profile in Context.ApplicantProfile
                                                               join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                                                               where profile.StatusApplicant == "Pass_PM" || profile.StatusApplicant == "Contact_Cnot"
                                                               select new ApplicantInterestingsDTO
                                                               {
                                                                   Empid = appointment.Empid,
                                                                   FirstnameTh = profile.FirstnameTh,
                                                                   LastnameTh = profile.LastnameTh,
                                                                   Tel = profile.Tel,
                                                                   Position = profile.Position,
                                                                   StatusApplicant = profile.StatusApplicant,
                                                                   DateTime_1 = appointment.Datetime1.Value,
                                                                   DateTime_2 = appointment.Datetime2.Value,
                                                                   TypeEmployee = profile.TypeEmployee
                                                               }).ToList();

            return applicantProfile;
        }

        public string UpdateStatusInteresting(int[] id, string status)
        {
            try
            {
                foreach (int empID in id)
                {
                    ApplicantProfile applicantProfile = new ApplicantProfile();
                    applicantProfile = Context.ApplicantProfile.Where(x => x.Empid == empID).FirstOrDefault();

                    applicantProfile.StatusApplicant = status;
                    applicantProfile.UpdDate = DateTime.Now;
                    Context.ApplicantProfile.Update(applicantProfile);
                    Context.SaveChanges();
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail";
            }
        }


        public List<ApplicantInterestingsDTO> GetDataListinteresting(string name, string date, string status, string type)
        {
            List<ApplicantInterestingsDTO> result;

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

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(date) && !string.IsNullOrWhiteSpace(status) && !(status == "null" || status == "undefined"))
            {
                string dateFromParse = DateTime.Parse(date).ToString("yyyy-MM-dd");
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where (profile.StatusApplicant == "Pass_PM" || profile.StatusApplicant == "Contact_Cnot") && (profile.FirstnameEn.Contains(name) || profile.LastnameEn.Contains(name) || profile.FirstnameTh.Contains(name) || profile.LastnameTh.Contains(name) || (profile.FirstnameTh.Contains(firstName) && profile.LastnameTh.Contains(lastName))) && (appointment.Datetime1.Value.Date.ToString() == dateFromParse || appointment.Datetime2.Value.Date.ToString() == dateFromParse) && (profile.StatusApplicant.Contains(status)) && applicantType.Contains(profile.TypeEmployee)
                          orderby profile.CrDate descending
                          select new ApplicantInterestingsDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              DateTime_1 = appointment.Datetime1.Value,
                              DateTime_2 = appointment.Datetime2.Value,
                              TypeEmployee = profile.TypeEmployee
                          }).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(status) && !(status == "null" || status == "undefined"))
            {
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where (profile.StatusApplicant == "Pass_PM" || profile.StatusApplicant == "Contact_Cnot") && (profile.FirstnameEn.Contains(name) || profile.LastnameEn.Contains(name) || profile.FirstnameTh.Contains(name) || profile.LastnameTh.Contains(name) || (profile.FirstnameTh.Contains(firstName) && profile.LastnameTh.Contains(lastName))) && (profile.StatusApplicant.Contains(status)) && applicantType.Contains(profile.TypeEmployee)
                          orderby profile.CrDate descending
                          select new ApplicantInterestingsDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              DateTime_1 = appointment.Datetime1.Value,
                              DateTime_2 = appointment.Datetime2.Value,
                              TypeEmployee = profile.TypeEmployee
                          }).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(date) && !string.IsNullOrWhiteSpace(status) && !(status == "null" || status == "undefined"))
            {
                string dateFromParse = DateTime.Parse(date).ToString("yyyy-MM-dd");
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where ( profile.StatusApplicant == "Pass_PM" || profile.StatusApplicant == "Contact_Cnot") && (appointment.Datetime1.Value.Date.ToString() == dateFromParse || appointment.Datetime2.Value.Date.ToString() == dateFromParse) && (profile.StatusApplicant.Contains(status)) && applicantType.Contains(profile.TypeEmployee)
                          orderby profile.CrDate descending
                          select new ApplicantInterestingsDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              DateTime_1 = appointment.Datetime1.Value,
                              DateTime_2 = appointment.Datetime2.Value,
                              TypeEmployee = profile.TypeEmployee
                          }).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(date))
            {
                string dateFromParse = DateTime.Parse(date).ToString("yyyy-MM-dd");
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where (profile.StatusApplicant == "Pass_PM" || profile.StatusApplicant == "Contact_Cnot") && (profile.FirstnameEn.Contains(name) || profile.LastnameEn.Contains(name) || profile.FirstnameTh.Contains(name) || profile.LastnameTh.Contains(name) || (profile.FirstnameTh.Contains(firstName) && profile.LastnameTh.Contains(lastName))) && (appointment.Datetime1.Value.Date.ToString() == dateFromParse || appointment.Datetime2.Value.Date.ToString() == dateFromParse) && applicantType.Contains(profile.TypeEmployee)
                          orderby profile.CrDate descending
                          select new ApplicantInterestingsDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              DateTime_1 = appointment.Datetime1.Value,
                              DateTime_2 = appointment.Datetime2.Value,
                              TypeEmployee = profile.TypeEmployee
                          }).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where (profile.StatusApplicant == "Pass_PM" || profile.StatusApplicant == "Contact_Cnot") && (profile.FirstnameEn.Contains(name) || profile.LastnameEn.Contains(name) || profile.FirstnameTh.Contains(name) || profile.LastnameTh.Contains(name) || (profile.FirstnameTh.Contains(firstName) && profile.LastnameTh.Contains(lastName))) && applicantType.Contains(profile.TypeEmployee)
                          orderby profile.CrDate descending
                          select new ApplicantInterestingsDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              DateTime_1 = appointment.Datetime1.Value,
                              DateTime_2 = appointment.Datetime2.Value,
                              TypeEmployee = profile.TypeEmployee
                          }).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(date))
            {
                string dateFromParse = DateTime.Parse(date).ToString("yyyy-MM-dd");
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where (profile.StatusApplicant == "Pass_PM" || profile.StatusApplicant == "Contact_Cnot") && (appointment.Datetime1.Value.Date.ToString() == dateFromParse || appointment.Datetime2.Value.Date.ToString() == dateFromParse) && applicantType.Contains(profile.TypeEmployee)
                          orderby profile.CrDate descending
                          select new ApplicantInterestingsDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              DateTime_1 = appointment.Datetime1.Value,
                              DateTime_2 = appointment.Datetime2.Value,
                              TypeEmployee = profile.TypeEmployee
                          }).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(status) && !(status == "null" || status == "undefined"))
            {
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where profile.StatusApplicant == status && applicantType.Contains(profile.TypeEmployee)
                          orderby profile.CrDate descending
                          select new ApplicantInterestingsDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              DateTime_1 = appointment.Datetime1.Value,
                              DateTime_2 = appointment.Datetime2.Value,
                              TypeEmployee = profile.TypeEmployee
                          }).ToList();
            }
            else
            {
                result = (from profile in Context.ApplicantProfile
                          join appointment in Context.ApplicantAppointmentDate on profile.Empid equals appointment.Empid
                          where (profile.StatusApplicant == "Pass_PM" || profile.StatusApplicant == "Contact_Cnot") && applicantType.Contains(profile.TypeEmployee)
                          orderby profile.CrDate descending
                          select new ApplicantInterestingsDTO
                          {
                              Empid = appointment.Empid,
                              FirstnameTh = profile.FirstnameTh,
                              LastnameTh = profile.LastnameTh,
                              Tel = profile.Tel,
                              Position = profile.Position,
                              StatusApplicant = profile.StatusApplicant,
                              DateTime_1 = appointment.Datetime1.Value,
                              DateTime_2 = appointment.Datetime2.Value,
                              TypeEmployee = profile.TypeEmployee
                          }).ToList();
            }

            return result;
        }

        public string UpdateAppointmentDate(List<UpdateApplicantInterestingsDTO> updatedata)
        {
            try
            {
                foreach (var data in updatedata)
                {
                    ApplicantProfile applicantProfile = new ApplicantProfile();
                    applicantProfile = Context.ApplicantProfile.Where(x => x.Empid == data.Empid).FirstOrDefault();
                    applicantProfile.StatusApplicant = data.StatusApplicant;
                    applicantProfile.UpdDate = DateTime.Now;
                    Context.ApplicantProfile.Update(applicantProfile);
                    Context.SaveChanges();


                    ApplicantAppointmentDate applicantAppointmentDate = new ApplicantAppointmentDate();
                    applicantAppointmentDate = Context.ApplicantAppointmentDate.Where(x => x.Empid == data.Empid).FirstOrDefault();
                    if (data.StatusApplicant == "Contact_Nint" || data.StatusApplicant == "Contact_Cnot")
                    {
                        applicantAppointmentDate.AppointmentDate = null;
                    }
                    else if (data.StatusApplicant == "Contact_Inte")
                    {
                        applicantAppointmentDate.AppointmentDate = data.AppointmentDate;
                    }
                    Context.ApplicantAppointmentDate.Update(applicantAppointmentDate);
                    Context.SaveChanges();
                }
                return "Success";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
