using ListApplicant.API.DTOs;
using ListInterviewerResult.API.Interface;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListInterviewerResult.API.Service
{
    public class ListInterviewerResultService : IListInterviewerResultInterface
    {
        private readonly SRM_DEVContext Context;

        public ListInterviewerResultService(SRM_DEVContext context)
        {
            Context = context;
        }

        public List<ApplicantProfile> GetAssessment()
        {
            List<ApplicantProfile> result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "Agreemented" || x.StatusApplicant == "Interview_C" || x.StatusApplicant == "Interview_N").OrderByDescending(x => x.UpdDate).ToList();

            return result;
        }


        public ApplicantAssessmentDTO GetDataAssessmentByID(int empID)
        {
            ApplicantAssessmentDTO listData = new ApplicantAssessmentDTO();

            ApplicantProfile applicantProfile = new ApplicantProfile();
            ApplicantAssetment applicantAssetment = new ApplicantAssetment();

            applicantAssetment = Context.ApplicantAssetment.Where(x => x.Empid == empID).FirstOrDefault();
            applicantProfile = Context.ApplicantProfile.Where(x => x.Empid == empID).FirstOrDefault();

            listData.FirstnameTh = applicantProfile.FirstnameTh != null ? applicantProfile.FirstnameTh : String.Empty;
            listData.LastnameTh = applicantProfile.LastnameTh != null ? applicantProfile.LastnameTh : String.Empty;
            listData.Position = applicantProfile.Position != null ? applicantProfile.Position : String.Empty;
            listData.Per_01 = applicantAssetment.Per01 != null ? applicantAssetment.Per01 : String.Empty;
            listData.Per_02 = applicantAssetment.Per02 != null ? applicantAssetment.Per02 : String.Empty;
            listData.Per_03 = applicantAssetment.Per03 != null ? applicantAssetment.Per03 : String.Empty;
            listData.Per_04 = applicantAssetment.Per04 != null ? applicantAssetment.Per04 : String.Empty;
            listData.Edu_01 = applicantAssetment.Edu01 != null ? applicantAssetment.Edu01 : String.Empty;
            listData.Edu_02 = applicantAssetment.Edu02 != null ? applicantAssetment.Edu02 : String.Empty;
            listData.Edu_03 = applicantAssetment.Edu03 != null ? applicantAssetment.Edu03 : String.Empty;
            listData.Edu_04 = applicantAssetment.Edu04 != null ? applicantAssetment.Edu04 : String.Empty;
            listData.Oth_01 = applicantAssetment.Oth01 != null ? applicantAssetment.Oth01 : String.Empty;
            listData.Oth_02 = applicantAssetment.Oth02 != null ? applicantAssetment.Oth02 : String.Empty;
            listData.Recomment = applicantAssetment.Recomment != null ? applicantAssetment.Recomment : String.Empty;
            listData.Summ_Ass = applicantAssetment.SummAss != null ? applicantAssetment.SummAss : String.Empty;
            listData.CrBy = applicantAssetment.CrBy != null ? applicantAssetment.CrBy : String.Empty;
            listData.CrDate = applicantAssetment.CrDate;

            return listData;


        }

        public async Task<string> SaveApplicant(ApplicantDTO data)
        {
            try
            {
                ApplicantProfile applicant = new ApplicantProfile();

                applicant.FirstnameTh = data.ApplicantProfile.FirstnameTh;
                applicant.LastnameTh = data.ApplicantProfile.LastnameTh;
                applicant.FirstnameEn = data.ApplicantProfile.FirstnameEn;
                applicant.LastnameEn = data.ApplicantProfile.LastnameEn;
                applicant.Birthday = data.ApplicantProfile.Birthday;
                applicant.Age = data.ApplicantProfile.Age;
                applicant.IdCard = data.ApplicantProfile.IdCard;

                applicant.Gender = data.ApplicantProfile.Gender;
                applicant.Status = data.ApplicantProfile.Status;
                applicant.Height = data.ApplicantProfile.Height;
                applicant.Weight = data.ApplicantProfile.Weight;
                applicant.Nationality = data.ApplicantProfile.Nationality;

                applicant.Tel = data.ApplicantProfile.Tel;
                applicant.Email = data.ApplicantProfile.Email;

                applicant.Address = data.ApplicantProfile.Address;
                applicant.Province = data.ApplicantProfile.Province;
                applicant.District = data.ApplicantProfile.District;
                applicant.SubDistrict = data.ApplicantProfile.SubDistrict;
                applicant.PostalCode = data.ApplicantProfile.PostalCode.ToString();
                applicant.ImgPath = data.ApplicantProfile.ImgPath;

                applicant.Position = data.ApplicantProfile.Position;
                applicant.Salary = data.ApplicantProfile.Salary;

                applicant.CrBy = data.ApplicantProfile.CrBy;
                applicant.CrDate = data.ApplicantProfile.CrDate;
                applicant.UpdBy = data.ApplicantProfile.UpdBy;
                applicant.UpdDate = data.ApplicantProfile.UpdDate;

                applicant.StatusApplicant = "SSSS";


                Context.ApplicantProfile.Add(applicant);
                Context.SaveChanges();


                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ApplicantProfile> GetDataSearchListInterviewerResult(string name,string position,string type)
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
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(position))
            {
                if (position == "All")
                {
                    result = Context.ApplicantProfile.Where(x => (x.StatusApplicant == "Agreemented" || x.StatusApplicant == "Interview_C" || x.StatusApplicant == "Interview_N") && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.UpdDate).ToList();
                }
                else
                {
                    result = Context.ApplicantProfile.Where(x => (x.StatusApplicant == "Agreemented" || x.StatusApplicant == "Interview_C" || x.StatusApplicant == "Interview_N") && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && (x.Position.Contains(position)) && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.UpdDate).ToList();
                }
            }
            else if (!string.IsNullOrWhiteSpace(position))
            {
                if (position == "All")
                {
                    result = Context.ApplicantProfile.Where(x => (x.StatusApplicant == "Agreemented" || x.StatusApplicant == "Interview_C" || x.StatusApplicant == "Interview_N") && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.UpdDate).ToList();
                }
                else
                {
                    result = Context.ApplicantProfile.Where(x => (x.StatusApplicant == "Agreemented" || x.StatusApplicant == "Interview_C" || x.StatusApplicant == "Interview_N") && (x.Position.Contains(position)) && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.UpdDate).ToList();
                }
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                result = Context.ApplicantProfile.Where(x => (x.StatusApplicant == "Agreemented" || x.StatusApplicant == "Interview_C" || x.StatusApplicant == "Interview_N") && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.UpdDate).ToList();
            }
            else
            {
                result = Context.ApplicantProfile.Where(x => (x.StatusApplicant == "Agreemented" || x.StatusApplicant == "Interview_C" || x.StatusApplicant == "Interview_N") && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.UpdDate).ToList();
            }

            return result;
        }
    }
}
