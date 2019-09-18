using JoinUs.API.Interface;
using ListApplicant.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterManange.API.DTOs;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using RegisterManange.API.Models;

namespace JoinUs.API.Service
{
    public class JoinUsService : JoinUsInterface
    {
        private readonly SRM_DEVContext Context;

        public JoinUsService(SRM_DEVContext context)
        {
            Context = context;
        }

        public List<ApplicantProfile> GetDataProfile()
        {
            List<ApplicantProfile> result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "New").OrderByDescending(x => x.Empid).ToList();

            return result;
        }

        public ApplicantDTO GetDataProfileByID(int empID)
        {
            ApplicantDTO listData = new ApplicantDTO();


            ApplicantProfile applicantProfile = new ApplicantProfile();
            ApplicantSkill applicantSkill = new ApplicantSkill();
            List<ApplicantEduHistory> applicantEduHis = new List<ApplicantEduHistory>();
            List<ApplicantWorkingHistory> applicantWorkingHistories = new List<ApplicantWorkingHistory>();
            List<ApplicantTrainingHistory> applicantTrainingHistories = new List<ApplicantTrainingHistory>();
            List<ApplicantSkillLanguage> applicantSkillLanguages = new List<ApplicantSkillLanguage>();
            List<ApplicantRef> applicantRefs = new List<ApplicantRef>();


            applicantProfile = Context.ApplicantProfile.Where(x => x.Empid == empID).FirstOrDefault();
            applicantSkill = Context.ApplicantSkill.Where(x => x.Empid == empID).FirstOrDefault();
            applicantEduHis = Context.ApplicantEduHistory.Where(x => x.Empid == empID).ToList();
            applicantWorkingHistories = Context.ApplicantWorkingHistory.Where(x => x.Empid == empID).ToList();
            applicantTrainingHistories = Context.ApplicantTrainingHistory.Where(x => x.Empid == empID).ToList();
            applicantSkillLanguages = Context.ApplicantSkillLanguage.Where(x => x.Empid == empID).ToList();
            applicantRefs = Context.ApplicantRef.Where(x => x.Empid == empID).ToList();


            listData.ApplicantProfile.TitelnameTh = applicantProfile.TitlenameTh;
            listData.ApplicantProfile.FirstnameTh = string.IsNullOrEmpty(applicantProfile.FirstnameTh) ? "" : applicantProfile.FirstnameTh;
            listData.ApplicantProfile.LastnameTh = string.IsNullOrEmpty(applicantProfile.LastnameTh) ? "" : applicantProfile.LastnameTh;
            listData.ApplicantProfile.TitelnameEn = applicantProfile.TitlenameEn;
            listData.ApplicantProfile.FirstnameEn = string.IsNullOrEmpty(applicantProfile.FirstnameEn) ? "" : applicantProfile.FirstnameEn;
            listData.ApplicantProfile.LastnameEn = string.IsNullOrEmpty(applicantProfile.LastnameEn) ? "" : applicantProfile.LastnameEn;
            listData.ApplicantProfile.Birthday = applicantProfile.Birthday;
            listData.ApplicantProfile.Age = applicantProfile.Age != null ? applicantProfile.Age : 0;
            listData.ApplicantProfile.IdCard = string.IsNullOrEmpty(applicantProfile.IdCard) ? "" : applicantProfile.IdCard;
            listData.ApplicantProfile.Status = string.IsNullOrEmpty(applicantProfile.Status) ? "" : applicantProfile.Status;
            listData.ApplicantProfile.Height = applicantProfile.Height != null ? applicantProfile.Height : 0;
            listData.ApplicantProfile.Weight = applicantProfile.Weight != null ? applicantProfile.Weight : 0;
            listData.ApplicantProfile.Nationality = string.IsNullOrEmpty(applicantProfile.Nationality) ? "" : applicantProfile.Nationality;
            listData.ApplicantProfile.Religion = string.IsNullOrEmpty(applicantProfile.Religion) ? "" : applicantProfile.Religion;

            listData.ApplicantProfile.Tel = string.IsNullOrEmpty(applicantProfile.Tel) ? "" : applicantProfile.Tel;
            listData.ApplicantProfile.Email = string.IsNullOrEmpty(applicantProfile.Email) ? "" : applicantProfile.Email;
            listData.ApplicantProfile.LineID = applicantProfile.Lineid;

            listData.ApplicantProfile.Address = string.IsNullOrEmpty(applicantProfile.Address) ? "" : applicantProfile.Address;
            listData.ApplicantProfile.Province = string.IsNullOrEmpty(applicantProfile.Province) ? "" : applicantProfile.Province;
            listData.ApplicantProfile.District = string.IsNullOrEmpty(applicantProfile.District) ? "" : applicantProfile.District;
            listData.ApplicantProfile.SubDistrict = string.IsNullOrEmpty(applicantProfile.SubDistrict) ? "" : applicantProfile.SubDistrict;
            listData.ApplicantProfile.PostalCode = int.Parse(applicantProfile.PostalCode);
            listData.ApplicantProfile.Stay = applicantProfile.Stay;

            listData.ApplicantProfile.ImgPath = string.IsNullOrEmpty(applicantProfile.ImgPath) ? "" : applicantProfile.ImgPath;
            listData.ApplicantProfile.Position = string.IsNullOrEmpty(applicantProfile.Position) ? "" : applicantProfile.Position;
            listData.ApplicantProfile.Salary = string.IsNullOrEmpty(applicantProfile.Salary) ? "" : applicantProfile.Salary;
            listData.ApplicantProfile.TypeEmployee = string.IsNullOrEmpty(applicantProfile.TypeEmployee) ? "" : applicantProfile.TypeEmployee;
            listData.ApplicantSkill.TypingTh = applicantSkill.TypingTh != null ? applicantSkill.TypingTh : 0;
            listData.ApplicantSkill.TypingEn = applicantSkill.TypingEn != null ? applicantSkill.TypingEn : 0;
            listData.ApplicantSkill.Special1 = string.IsNullOrEmpty(applicantSkill.Special1) ? "" : applicantSkill.Special1;
            listData.ApplicantSkill.Special2 = string.IsNullOrEmpty(applicantSkill.Special2) ? "" : applicantSkill.Special2;
            listData.ApplicantSkill.Special3 = string.IsNullOrEmpty(applicantSkill.Special3) ? "" : applicantSkill.Special3;
            listData.ApplicantSkill.Special4 = string.IsNullOrEmpty(applicantSkill.Special4) ? "" : applicantSkill.Special4;

            listData.ApplicantProfile.CrBy = string.IsNullOrEmpty(applicantProfile.CrBy) ? "" : applicantProfile.CrBy;
            listData.ApplicantProfile.CrDate = applicantProfile.CrDate;
            listData.ApplicantProfile.Gender = string.IsNullOrEmpty(applicantProfile.Gender) ? "" : applicantProfile.Gender;
            listData.ApplicantProfile.StatusApplicant = string.IsNullOrEmpty(applicantProfile.StatusApplicant) ? "" : applicantProfile.StatusApplicant;
            listData.ApplicantProfile.FirstnameTh = string.IsNullOrEmpty(applicantProfile.FirstnameTh) ? "" : applicantProfile.FirstnameTh;
            listData.ApplicantProfile.UpdBy = string.IsNullOrEmpty(applicantProfile.UpdBy) ? "" : applicantProfile.UpdBy;
            listData.ApplicantProfile.UpdDate = applicantProfile.UpdDate;

            foreach (ApplicantEduHistory eduHistory in applicantEduHis)
            {
                if (eduHistory != null)
                {
                    ApplicantEduHistoryDTO eduHistoryDTO = new ApplicantEduHistoryDTO();
                    eduHistoryDTO.Education = eduHistory.Education;
                    eduHistoryDTO.SchoolName = eduHistory.SchoolName;
                    eduHistoryDTO.Faculty = eduHistory.Faculty;
                    eduHistoryDTO.Major = eduHistory.Major;
                    eduHistoryDTO.GradYear = DateTime.Parse("01/01/" + eduHistory.GradYear);
                    eduHistoryDTO.Gpa = eduHistory.Gpa;
                    listData.ApplicantEduHistories.Add(eduHistoryDTO);
                }
                else
                {
                    listData.ApplicantEduHistories = null;
                }
            }

            foreach (ApplicantWorkingHistory workingHistory in applicantWorkingHistories)
            {
                if (workingHistory != null)
                {
                    ApplicantWorkingHistoryDTO workingHistoryDTO = new ApplicantWorkingHistoryDTO();
                    workingHistoryDTO.StartDate = workingHistory.StartDate;
                    workingHistoryDTO.EndDate = workingHistory.EndDate;
                    workingHistoryDTO.CompanyName = workingHistory.CompanyName;
                    workingHistoryDTO.CompanyAddress = workingHistory.CompanyAddress;
                    workingHistoryDTO.Position = workingHistory.Position;
                    workingHistoryDTO.Salary = workingHistory.Salary;
                    listData.ApplicantWorkingHistories.Add(workingHistoryDTO);

                }
                else
                {
                    listData.ApplicantWorkingHistories = null;
                }
            }

            foreach (ApplicantTrainingHistory trainingHistory in applicantTrainingHistories)
            {
                if (trainingHistory != null)
                {
                    ApplicantTrainingHistoryDTO trainingHistoryDTO = new ApplicantTrainingHistoryDTO();
                    trainingHistoryDTO.StartDate = trainingHistory.StartDate;
                    trainingHistoryDTO.EndDate = trainingHistory.EndDate;
                    trainingHistoryDTO.TrainingName = trainingHistory.TrainingName;
                    trainingHistoryDTO.CourseName = trainingHistory.CourseName;
                    trainingHistoryDTO.Certificate = trainingHistory.Certificate;
                    listData.ApplicantTrainingHistories.Add(trainingHistoryDTO);

                }
                else
                {
                    listData.ApplicantTrainingHistories = null;
                }
            }

            foreach (ApplicantSkillLanguage skillLanguage in applicantSkillLanguages)
            {
                if (skillLanguage != null)
                {
                    ApplicantSkillLanguageDTO skillLanguageDTO = new ApplicantSkillLanguageDTO();
                    skillLanguageDTO.Language = skillLanguage.Language;
                    skillLanguageDTO.LanguageSpeak = skillLanguage.LanguageSpeak;
                    skillLanguageDTO.LanguageRead = skillLanguage.LanguageRead;
                    skillLanguageDTO.LanguageWrite = skillLanguage.LanguageWrite;
                    listData.ApplicantSkillLanguages.Add(skillLanguageDTO);
                }
                else
                {
                    listData.ApplicantTrainingHistories = null;
                }
            }

            foreach (ApplicantRef Ref in applicantRefs)
            {
                if (Ref != null)
                {
                    ApplicantRefDTO RefDTO = new ApplicantRefDTO();
                    RefDTO.RefName = Ref.RefName;
                    RefDTO.RefPosition = Ref.RefPosition;
                    RefDTO.RefTel = Ref.RefTel;

                    listData.ApplicantRef.Add(RefDTO);
                }
                else
                {
                    listData.ApplicantRef = null;
                }
            }

            return listData;
        }

        public async Task<string> SaveApplicant(ApplicantDTO data)
        {
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    int empID = Context.ApplicantProfile.Max(i => i.Empid) + 1; // EMDID
                    DateTime dateTime = DateTime.Now;

                    #region // ########## Table APPLICANT_PROFILE ########## //
                    ApplicantProfile applicant = new ApplicantProfile();

                    // EMDID
                    applicant.Empid = empID;

                    // รูปโปรไฟล์
                    applicant.ImgPath = data.ApplicantProfile.ImgPath;

                    // ลักษณะงานที่ต้องการ
                    applicant.Position = data.ApplicantProfile.Position;
                    applicant.Salary = data.ApplicantProfile.Salary;
                    applicant.TypeEmployee = data.ApplicantProfile.TypeEmployee;

                    // ข้อมูลส่วนตัว
                    applicant.TitlenameTh = data.ApplicantProfile.TitelnameTh;
                    applicant.FirstnameTh = data.ApplicantProfile.FirstnameTh;
                    applicant.LastnameTh = data.ApplicantProfile.LastnameTh;
                    applicant.TitlenameEn = data.ApplicantProfile.TitelnameEn;
                    applicant.FirstnameEn = data.ApplicantProfile.FirstnameEn;
                    applicant.LastnameEn = data.ApplicantProfile.LastnameEn;
                    applicant.Birthday = data.ApplicantProfile.Birthday;
                    applicant.Age = data.ApplicantProfile.Age;
                    applicant.Gender = data.ApplicantProfile.Gender;
                    applicant.Status = data.ApplicantProfile.Status;
                    applicant.IdCard = data.ApplicantProfile.IdCard;
                    applicant.Religion = data.ApplicantProfile.Religion;
                    applicant.Nationality = data.ApplicantProfile.Nationality;
                    applicant.Height = data.ApplicantProfile.Height;
                    applicant.Weight = data.ApplicantProfile.Weight;

                    // ข้อมูลการติดต่อ
                    applicant.Tel = data.ApplicantProfile.Tel;
                    applicant.Email = data.ApplicantProfile.Email;
                    applicant.Lineid = data.ApplicantProfile.LineID;

                    // ข้อมูลที่อยู่ปัจจุบัน
                    applicant.Address = data.ApplicantProfile.Address;
                    applicant.Province = data.ApplicantProfile.Province;
                    applicant.District = data.ApplicantProfile.District;
                    applicant.SubDistrict = data.ApplicantProfile.SubDistrict;
                    applicant.PostalCode = data.ApplicantProfile.PostalCode.ToString();

                    // Status
                    applicant.StatusApplicant = "New";

                    applicant.CrBy = "Coop"; ;
                    applicant.CrDate = dateTime;
                    applicant.UpdBy = "Coop";
                    applicant.UpdDate = dateTime;

                    Context.ApplicantProfile.Add(applicant);
                    #endregion

                    #region // ########## Table APPLICANT_EDU_HISTORY ########## //
                    int eduNo = 0;
                    foreach (ApplicantEduHistoryDTO edu in data.ApplicantEduHistories)
                    {
                        ApplicantEduHistory applicantEdu = new ApplicantEduHistory();
                        eduNo++;

                        // EMPID
                        applicantEdu.Empid = empID;

                        // ประวัติการศึกษา
                        applicantEdu.No = eduNo;
                        applicantEdu.Education = edu.Education;
                        applicantEdu.SchoolName = edu.SchoolName;
                        applicantEdu.Faculty = edu.Faculty;
                        applicantEdu.Major = edu.Major;
                        applicantEdu.GradYear = edu.GradYear.Year.ToString();
                        applicantEdu.Gpa = edu.Gpa;

                        applicantEdu.CrBy = "Coop";
                        applicantEdu.CrDate = dateTime;
                        applicantEdu.UpdBy = "Coop";
                        applicantEdu.UpdDate = dateTime;

                        Context.ApplicantEduHistory.Add(applicantEdu);
                    }
                    #endregion

                    #region // ########## Table APPLICANT_WORKING_HISTORY ########## //
                    int workNo = 0;
                    foreach (ApplicantWorkingHistoryDTO work in data.ApplicantWorkingHistories)
                    {
                        ApplicantWorkingHistory applicantWork = new ApplicantWorkingHistory();
                        workNo++;

                        // EMPID
                        applicantWork.Empid = empID;

                        // ประวัติการทำงาน/ฝึกงาน
                        applicantWork.No = workNo;
                        applicantWork.StartDate = work.StartDate;
                        applicantWork.EndDate = work.EndDate;
                        applicantWork.CompanyName = work.CompanyName;
                        applicantWork.CompanyAddress = work.CompanyAddress;
                        applicantWork.Position = work.Position;
                        applicantWork.Salary = work.Salary;

                        applicantWork.CrBy = "Coop";
                        applicantWork.CrDate = dateTime;
                        applicantWork.UpdBy = "Coop";
                        applicantWork.UpdDate = dateTime;

                        Context.ApplicantWorkingHistory.Add(applicantWork);
                    }
                    #endregion

                    #region // ########## Table APPLICANT_TRAINING_HISTORY ########## //
                    int trainingNo = 0;
                    foreach (ApplicantTrainingHistoryDTO training in data.ApplicantTrainingHistories)
                    {
                        ApplicantTrainingHistory applicantTraining = new ApplicantTrainingHistory();
                        trainingNo++;

                        // EMPID
                        applicantTraining.Empid = empID;

                        // ประวัติการฝึกอบรม/ประกาศนียบัตร
                        applicantTraining.No = trainingNo;
                        applicantTraining.StartDate = training.StartDate;
                        applicantTraining.EndDate = training.EndDate;
                        applicantTraining.TrainingName = training.TrainingName;
                        applicantTraining.CourseName = training.CourseName;
                        applicantTraining.Certificate = training.Certificate;

                        applicantTraining.CrBy = "Coop";
                        applicantTraining.CrDate = dateTime;
                        applicantTraining.UpdBy = "Coop";
                        applicantTraining.UpdDate = dateTime;

                        Context.ApplicantTrainingHistory.Add(applicantTraining);
                    }
                    #endregion

                    #region // ########## Table APPLICANT_SKILL_LANGUAGE ########## //
                    int languageNo = 0;
                    foreach (ApplicantSkillLanguageDTO language in data.ApplicantSkillLanguages)
                    {
                        ApplicantSkillLanguage applicantLanguage = new ApplicantSkillLanguage();
                        languageNo++;

                        // EMPID
                        applicantLanguage.Empid = empID;

                        // ความสามารถทางภาษา
                        applicantLanguage.No = languageNo;
                        applicantLanguage.Language = language.Language;
                        applicantLanguage.LanguageSpeak = language.LanguageSpeak;
                        applicantLanguage.LanguageRead = language.LanguageRead;
                        applicantLanguage.LanguageWrite = language.LanguageWrite;

                        applicantLanguage.CrBy = "Coop";
                        applicantLanguage.CrDate = dateTime;
                        applicantLanguage.UpdBy = "Coop";
                        applicantLanguage.UpdDate = dateTime;

                        Context.ApplicantSkillLanguage.Add(applicantLanguage);
                    }
                    #endregion

                    #region // ########## Table APPLICANT_SKILL ########## //
                    ApplicantSkill applicantSkill = new ApplicantSkill();

                    // EMPID
                    applicantSkill.Empid = empID;

                    // พิมพ์ดีด
                    applicantSkill.TypingTh = data.ApplicantSkill.TypingTh;
                    applicantSkill.TypingEn = data.ApplicantSkill.TypingEn;

                    // กรุณาเรียงลำดับความสามารถด้านคอมพิวเตอร์ (เช่นภาษา/โปรแกรม/ระบบปฏิบัติการอื่นๆ)
                    applicantSkill.Special1 = data.ApplicantSkill.Special1;
                    applicantSkill.Special2 = data.ApplicantSkill.Special2;
                    applicantSkill.Special3 = data.ApplicantSkill.Special3;
                    applicantSkill.Special4 = data.ApplicantSkill.Special4;

                    applicantSkill.CrBy = "Coop";
                    applicantSkill.CrDate = dateTime;
                    applicantSkill.UpdBy = "Coop";
                    applicantSkill.UpdDate = dateTime;

                    Context.ApplicantSkill.Add(applicantSkill);
                    #endregion

                    #region // ########## Table APPLICANT_REF ########## //
                    int refNo = 0;
                    foreach (ApplicantRefDTO refs in data.ApplicantRef)
                    {
                        ApplicantRef applicantRef = new ApplicantRef();
                        refNo++;

                        // EMPID
                        applicantRef.Empid = empID;

                        // รายชื่อบุคคลอ้างอิง ซึ่งมิใช่ญาติหรือผู้ว่าจ้าง ซึ่งบริษัทฯ สามารถสอบประวัติท่านได้
                        applicantRef.No = refNo;
                        applicantRef.RefName = refs.RefName;
                        applicantRef.RefPosition = refs.RefPosition;
                        applicantRef.RefTel = refs.RefTel;

                        applicantRef.CrBy = "Coop";
                        applicantRef.CrDate = dateTime;
                        applicantRef.UpdBy = "Coop";
                        applicantRef.UpdDate = dateTime;

                        Context.ApplicantRef.Add(applicantRef);
                    }
                    #endregion

                    Context.SaveChanges();
                    dbContextTransaction.Commit();

                    return empID.ToString();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return "error";
                }
            }
        }

        public List<AddressDTO> GetAddress(string type, int value)
        {
            List<AddressDTO> address = new List<AddressDTO>();

            if (type == "Province")
            {
                address = Context.Province.Select(x => new AddressDTO() { Name = x.ProvinceTh, Value = x.ProvinceId }).ToList();
            }
            else if (type == "District")
            {
                address = Context.District.Where(x => x.ProvinceId == value).Select(x => new AddressDTO() { Name = x.DistrictTh, Value = x.DistrictId }).ToList();
            }
            else if (type == "Subdistrict")
            {
                address = Context.Subdistrict.Where(x => x.DistrictId == value).Select(x => new AddressDTO() { Name = x.SubdistrictTh, Value = x.SubdistrictId }).ToList();
            }
            else if (type == "Postcode")
            {
                address = (from subdistrict in Context.Subdistrict
                           join postcode in Context.Postcode
                           on subdistrict.SubdistrictCode equals postcode.PostcodeCode
                           where subdistrict.SubdistrictId == value
                           select new AddressDTO()
                           {
                               Name = postcode.Postcode1.ToString(),
                               Value = postcode.PostcodeId

                           }).ToList();
            }

            return address;
        }

        public string UpdateProfileStatus(UpdateStatusDTO status)
        {
            try
            {
                foreach (int empID in status.IDs)
                {
                    ApplicantProfile applicantProfile = new ApplicantProfile();
                    applicantProfile = Context.ApplicantProfile.Where(x => x.Empid == empID).FirstOrDefault();

                    applicantProfile.StatusApplicant = status.Status;
                    applicantProfile.UpdBy = status.UpdBy;
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

        public List<ApplicantProfile> GetDataProfileByHR(string name, string date, string type)
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

            string[] applicantType ;
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
                DateTime dateFromParse = Convert.ToDateTime(date);
                result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "New" && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName) )) && x.CrDate.Value.Date == dateFromParse && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.Empid).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "New" && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.Empid).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(date))
            {
                DateTime dateFromParse = Convert.ToDateTime(date);
                result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "New" && x.CrDate.Value.Date == dateFromParse && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.Empid).ToList();
            }
            else
            {
                result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "New" && applicantType.Contains(x.TypeEmployee)).OrderByDescending(x => x.Empid).ToList();
            }

            return result;
        }

        public List<ApplicantProfile> GetDataCheckProgress(string IDcard) //get check progress IDCard
        {
            List<ApplicantProfile> result;

            if (!string.IsNullOrWhiteSpace(IDcard))
            {
                result = Context.ApplicantProfile.Where(x => IDcard == x.IdCard).ToList();
            }
            else
            {
                result = Context.ApplicantProfile.Where(x => IDcard == "NULL").ToList();
            }

            return result;
        }

        public string updateStatus([FromBody] UpdateStatusDTO status)
        {
            try
            {
                ApplicantProfile applicantProfile = new ApplicantProfile();
                applicantProfile = Context.ApplicantProfile.Where(x => x.Empid == status.ID).FirstOrDefault();

                applicantProfile.StatusApplicant = status.Status;
                applicantProfile.UpdBy = status.UpdBy;
                applicantProfile.UpdDate = DateTime.Now;
                Context.ApplicantProfile.Update(applicantProfile);
                Context.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail";
            }
        }

        public string UploadFiles(string empID, IFormFileCollection files)
        {
            string fileName = string.Empty;
            string fullPath = string.Empty;
            string dbPath = string.Empty;
            string folderName = string.Empty;
            string pathToSave = string.Empty;
            int countComplete = 0;

            try
            {
                List<ApplicantProfile> profile = Context.ApplicantProfile.Where(i => i.Empid == int.Parse(empID)).ToList();
                DateTime crDate = (profile.Select(i => i.CrDate.Value)).Single();
                string firstNameTH = (profile.Select(i => i.FirstnameTh)).Single();
                string LastNameTH = (profile.Select(i => i.LastnameTh)).Single();
                string path = Context.ListOfValue.Where(i => i.GroupCode == "PATH" && i.SeqNo == 1).Select(i => i.Value).Single();

                folderName = Path.Combine("UploadFiles", crDate.ToString("yyyyMMdd") + "_" + firstNameTH + "_" + LastNameTH);
                pathToSave = Path.Combine(path, folderName);

                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }

                for (int i = 0; i < files.Count; i++)
                {
                    fileName = ContentDispositionHeaderValue.Parse(files[i].ContentDisposition).FileName.Trim('"');
                    fullPath = Path.Combine(pathToSave, fileName);

                    using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                    {
                        files[i].CopyTo(stream);
                    }

                    countComplete++;
                }

                return countComplete.ToString();
            }
            catch (Exception ex)
            {
                if (Directory.Exists(pathToSave))
                {
                    Directory.Delete(pathToSave, true);
                }

                return "error";
            }
        }

        public string[] GetFileName(string empID)
        {
            string[] fileName;

            try
            {
                List<ApplicantProfile> profile = Context.ApplicantProfile.Where(i => i.Empid == int.Parse(empID)).ToList();
                DateTime crDate = (profile.Select(i => i.CrDate.Value)).Single();
                string firstNameTH = (profile.Select(i => i.FirstnameTh)).Single();
                string LastNameTH = (profile.Select(i => i.LastnameTh)).Single();
                string pathFromDB = Context.ListOfValue.Where(i => i.GroupCode == "PATH" && i.SeqNo == 1).Select(i => i.Value).Single();

                string folderName = Path.Combine("UploadFiles", crDate.ToString("yyyyMMdd") + "_" + firstNameTH + "_" + LastNameTH);
                string path = Path.Combine(pathFromDB, folderName);

                if (!Directory.Exists(path))
                {
                    return fileName = null;
                }
                else
                {
                    return fileName = Directory.GetFiles(path).Select(Path.GetFileName).ToArray();
                }
            }
            catch (Exception ex)
            {
                return fileName = null;
            }
        }

        public MemoryStream GetFiles(string empID, string fileName, ref string contentType)
        {
            List<ApplicantProfile> profile = Context.ApplicantProfile.Where(i => i.Empid == int.Parse(empID)).ToList();
            DateTime crDate = (profile.Select(i => i.CrDate.Value)).Single();
            string firstNameTH = (profile.Select(i => i.FirstnameTh)).Single();
            string LastNameTH = (profile.Select(i => i.LastnameTh)).Single();
            string pathFromDB = Context.ListOfValue.Where(i => i.GroupCode == "PATH" && i.SeqNo == 1).Select(i => i.Value).Single();

            string folderName = Path.Combine("UploadFiles", crDate.ToString("yyyyMMdd") + "_" + firstNameTH + "_" + LastNameTH);
            string path = Path.Combine(pathFromDB, folderName, fileName);

            contentType = GetMimeType(path);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return memory;
        }

        private string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = Path.GetExtension(fileName).ToLower();
            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(ext);

            if (regKey != null && regKey.GetValue("Content Type") != null)
            {
                mimeType = regKey.GetValue("Content Type").ToString();
            }

            return mimeType;
        }
    }
}
