using Agreement.API.Interface;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.API.Service
{
    public class AgreementService : AgreementInterface
    {
        private readonly SRM_DEVContext Context;

        public AgreementService(SRM_DEVContext context)
        {
            Context = context;
        }

        public string AddDatatoAgreement(ApplicantAgreement data)
        {
            try
            {
                ApplicantAgreement agreement = new ApplicantAgreement();

                agreement.Empid = data.Empid;
                agreement.Company = data.Company;
                agreement.StartDate = data.StartDate;
                agreement.Salary = data.Salary;
                agreement.Other = data.Other;
                agreement.CrBy = data.UpdBy;
                agreement.CrDate = DateTime.Now;
                agreement.UpdBy = data.UpdBy;
                agreement.UpdDate = DateTime.Now;

                Context.ApplicantAgreement.Add(agreement);
                Context.SaveChanges();

                ApplicantProfile profile = new ApplicantProfile();

                profile = Context.ApplicantProfile.Where(x => x.Empid == data.Empid).FirstOrDefault();
                profile.StatusApplicant = "Agreemented";
                profile.UpdBy = data.UpdBy;
                profile.UpdDate = DateTime.Now;

                Context.ApplicantProfile.Update(profile);
                Context.SaveChanges();

                return "success";
            }
            catch (Exception e) { throw e; }
        }

        public List<ApplicantInterviewerDTO> GetDatatoAgreement(string team)
        {


            List<ApplicantInterviewerDTO> Interviewer = (from profile in Context.ApplicantProfile
                                                         where profile.StatusApplicant == "Interview_P" && profile.Team == team
                                                         orderby profile.UpdDate descending
                                                         select new ApplicantInterviewerDTO
                                                         {
                                                             Empid = profile.Empid,
                                                             FirstnameTh = profile.FirstnameTh,
                                                             LastnameTh = profile.LastnameTh,
                                                             Tel = profile.Tel,
                                                             Position = profile.Position,
                                                             StatusApplicant = profile.StatusApplicant,
                                                             TypeEmployee = profile.TypeEmployee
                                                         }).ToList();

            return Interviewer;
        }


        public List<ApplicantProfile> GetDataBySearch(string name, string date, string team,string type)
        {
            List<ApplicantProfile> result;

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
                result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "Interview_P" && x.Team == team && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && x.CrDate.Value.Date.ToString() == dateFromParse && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.UpdDate).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "Interview_P" && x.Team == team && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.UpdDate).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(date))
            {
                string dateFromParse = DateTime.Parse(date).ToString("yyyy-MM-dd");
                result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "Interview_P" && x.Team == team && x.CrDate.Value.Date.ToString() == dateFromParse && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.UpdDate).ToList();
            }
            else
            {
                result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "Interview_P" && x.Team == team && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.UpdDate).ToList();
            }

            return result;
        }

        public ApplicantAgreement GetDatatoAgreementByEmpId(int empID)
        {
            ApplicantAgreement agreement = new ApplicantAgreement();
            agreement = Context.ApplicantAgreement.Where(x => x.Empid == empID ).FirstOrDefault();
            return agreement;
        }
    }
}
