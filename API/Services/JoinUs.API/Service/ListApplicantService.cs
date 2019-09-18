using ListApplicant.API.Interface;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListApplicant.API.Service
{
    public class ListApplicantService : ListApplicantsInterface
    {
        private readonly SRM_DEVContext Context;
        public ListApplicantService(SRM_DEVContext context)
        {
            Context = context;
        }

        public List<ApplicantProfile> GetDataProfileByPM(string position)
        {
            List<ApplicantProfile> result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "Pass_HR" && x.Position == position).OrderByDescending(x => x.UpdDate).ToList();

            return result;
        }

        public List<ApplicantProfile> GetDataProfileByPM(string name, string date, string type, string department)
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
                result = Context.ApplicantProfile.Where(x => (x.StatusApplicant == "Pass_HR") && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && (x.CrDate.Value.Date.ToString() == dateFromParse) && applicantType.Contains(x.TypeEmployee) && x.Position == department).OrderByDescending(x => x.UpdDate).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                result = Context.ApplicantProfile.Where(x => (x.StatusApplicant == "Pass_HR") && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && applicantType.Contains(x.TypeEmployee) && x.Position == department).OrderByDescending(x => x.UpdDate).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(date))
            {
                string dateFromParse = DateTime.Parse(date).ToString("yyyy-MM-dd");
                result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "Pass_HR" && x.CrDate.Value.Date.ToString() == dateFromParse && applicantType.Contains(x.TypeEmployee) && x.Position == department).OrderByDescending(x => x.UpdDate).ToList();
            }
            else
            {
                result = Context.ApplicantProfile.Where(x => x.StatusApplicant == "Pass_HR" && applicantType.Contains(x.TypeEmployee) && x.Position == department).OrderByDescending(x => x.UpdDate).ToList();
            }

            return result;
        }


        public async Task<string> SaveinterviewDate(ApplicantAppointmentDateDTO data, string team)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                ApplicantAppointmentDate saveinterviewdate = new ApplicantAppointmentDate();

                saveinterviewdate.Username = data.Username;
                saveinterviewdate.Empid = data.Empid;
                saveinterviewdate.Datetime1 = data.Datetime1;
                saveinterviewdate.Datetime2 = data.Datetime2;
                //saveinterviewdate.AppointmentDate = data.AppointmentDate;
                //saveinterviewdate.AppointmentStatus = data.AppointmentStatus;
                saveinterviewdate.CrBy = data.Username;
                saveinterviewdate.CrDate = DateTime.Now;

                Context.ApplicantAppointmentDate.Add(saveinterviewdate);
                Context.SaveChanges();


                ApplicantProfile applicantProfile = new ApplicantProfile();
                applicantProfile = Context.ApplicantProfile.Where(x => x.Empid == data.Empid).FirstOrDefault();

                applicantProfile.StatusApplicant = "Pass_PM";
                applicantProfile.Team = team;
                applicantProfile.UpdDate = dateTime;
                Context.ApplicantProfile.Update(applicantProfile);
                Context.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ApplicantProfile> GetHistoryListApplicant(string role, string department, string team)
        {
            string[] applicantStatusPM;
            List<ApplicantProfile> result = new List<ApplicantProfile>();
            if (role == "Project Manager")
            {
                applicantStatusPM = new string[] { "Pass_PM", "NPass_PM", "Interview_P", "Interview_C", "Interview_N", "Contact_Inte", "Contact_Nint", "Contact_Cnot", "Agreemented" };
                result = Context.ApplicantProfile.Where(x => applicantStatusPM.Contains(x.StatusApplicant) && x.Position == department && x.Team == team).ToList();
            }
            else
            {
                applicantStatusPM = new string[] { "Pass_HR ", "NPass_HR", "Pass_PM", "NPass_PM", "Interview_P", "Interview_C", "Interview_N", "Contact_Inte", "Contact_Nint", "Contact_Cnot", "Agreemented" };
                result = Context.ApplicantProfile.Where(x => applicantStatusPM.Contains(x.StatusApplicant)).ToList();
            }
            return result;
        }

        public List<ApplicantProfile> searchHistoryList(string role, string department, string team, string name, string status, string type, string date, string searchPosition)
        {
            List<ApplicantProfile> result = new List<ApplicantProfile>();

            if (searchPosition == "null")
            {
                searchPosition = string.Empty;
            }
            string firstName = string.Empty;
            string lastName = string.Empty;

            #region Split Name
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
            #endregion

            #region Map Status
            string[] statusApplicant;
            if (status == "Pass") // ผ่าน
            {
                statusApplicant = new string[] { "Interview_P", "Agreemented" };
            }
            else if (status == "NotPass") // ไม่ผ่านจาก
            {
                statusApplicant = new string[] { "NPass_PM", "Interview_N", "NPass_HR" };
            }
            //else if (status == "NotPassHR") // ไม่ผ่านจาก PM
            //{
            //    statusApplicant = new string[] { "NPass_HR" };
            //}
            else if (status == "Wait") //รอการติดต่อ
            {
                statusApplicant = new string[] { "Contact_Cnot", "Contact_Inte", "Pass_PM", "Pass_HR" };
            }
            else if (status == "Consider") //รับไว้พิจารณา
            {
                statusApplicant = new string[] { "Interview_C" };
            }
            else if (status == "dontCare") //ไม่สนใจนัดสัมภาษณ์
            {
                statusApplicant = new string[] { "Contact_Nint" };
            }
            else
            {
                statusApplicant = new string[] { "Pass_PM", "NPass_PM", "Interview_P", "Interview_C", "Interview_N", "Contact_Inte", "Contact_Nint", "Contact_Cnot", "Agreemented" };

                if (role == "Human Resource")
                {
                    statusApplicant = new string[] { "Pass_HR ", "NPass_HR", "Pass_PM", "NPass_PM", "Interview_P", "Interview_C", "Interview_N", "Contact_Inte", "Contact_Nint", "Contact_Cnot", "Agreemented" };
                }
            }
            #endregion

            #region Map ApplicantType
            string[] applicantType;
            if (type == "A")
            {
                applicantType = new string[] { "P", "T" };
            }
            else
            {
                applicantType = new String[] { type };
            }
            #endregion

            #region Condition Search case position is All
            if (searchPosition == "All")
            {
                #region Have name and date
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(date))
                {
                    DateTime praseDate = Convert.ToDateTime(date);
                    if (role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && x.Position == department && x.Team == team && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && x.CrDate.Value.Date == praseDate).ToList();
                    }
                    if (role == "Human Resource")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && x.CrDate.Value.Date == praseDate).ToList();
                    }
                }
                #endregion
                #region Have date only
                else if (!string.IsNullOrEmpty(date))
                {
                    DateTime praseDate = Convert.ToDateTime(date);
                    if (role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && x.Position == department && x.Team == team && applicantType.Contains(x.TypeEmployee) && x.CrDate.Value.Date == praseDate).ToList();
                    }
                    if (role == "Human Resource")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && x.CrDate.Value.Date == praseDate).ToList();
                    }
                }
                #endregion
                #region Have name only
                else if (!string.IsNullOrWhiteSpace(name))
                {
                    if (role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && x.Position == department && x.Team == team && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName)))).ToList();
                    }
                    else if (role == "Human Resource")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName)))).ToList();
                    }
                }
                #endregion
                #region Select All
                else
                {
                    if (role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && x.Position == department && x.Team == team && applicantType.Contains(x.TypeEmployee)).ToList();
                    }
                    else if (role == "Human Resource")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee)).ToList();
                    }
                }
                #endregion
            }

            #endregion

            #region Condition Search case position is not All
            if (searchPosition != "All")
            {
                #region name and date and searchposition
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(searchPosition))
                {
                    DateTime praseDate = Convert.ToDateTime(date);
                    if(role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && x.CrDate.Value.Date == praseDate && x.Position == searchPosition && x.Team == team).ToList();
                    }
                    else
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && x.CrDate.Value.Date == praseDate && x.Position == searchPosition).ToList();
                    }
                }
                #endregion
                #region name and Position
                else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(searchPosition))
                {
                    if(role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && x.Position == searchPosition && x.Team == team).ToList();
                    }
                    else
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && x.Position == searchPosition).ToList();
                    }
                }
                #endregion
                #region name and date
                else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(date))
                {
                    DateTime praseDate = Convert.ToDateTime(date);
                    if (role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && x.Position == department && x.Team == team && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && x.CrDate.Value.Date == praseDate && x.Team == team).ToList();
                    }
                    if (role == "Human Resource")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName))) && x.CrDate.Value.Date == praseDate).ToList();
                    }
                }
                #endregion
                #region position and date
                else if (!string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(searchPosition))
                {
                    DateTime praseDate = Convert.ToDateTime(date);
                    if(role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && x.CrDate.Value.Date == praseDate && x.Position == searchPosition && x.Team == team).ToList();
                    }
                    else
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && x.CrDate.Value.Date == praseDate && x.Position == searchPosition).ToList();
                    }
                }
                #endregion
                #region Position only
                else if (!string.IsNullOrEmpty(searchPosition))
                {
                    if (role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && x.Position == searchPosition && x.Team == team).ToList();
                    }
                    else
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && x.Position == searchPosition).ToList();
                    }

                }
                #endregion
                #region date only
                else if (!string.IsNullOrEmpty(date))
                {
                    DateTime praseDate = Convert.ToDateTime(date);
                    if (role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && x.Position == department && x.Team == team && applicantType.Contains(x.TypeEmployee) && x.CrDate.Value.Date == praseDate).ToList();
                    }
                    if (role == "Human Resource")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && x.CrDate.Value.Date == praseDate).ToList();
                    }
                }
                #endregion
                #region name only
                else if (!string.IsNullOrWhiteSpace(name))
                {
                    if (role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && x.Position == department && x.Team == team && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName)))).ToList();
                    }
                    else if (role == "Human Resource")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee) && (x.FirstnameEn.Contains(name) || x.LastnameEn.Contains(name) || x.FirstnameTh.Contains(name) || x.LastnameTh.Contains(name) || (x.FirstnameTh.Contains(firstName) && x.LastnameTh.Contains(lastName)))).ToList();
                    }
                }
                #endregion
                #region Select All
                else
                {
                    if (role == "Project Manager")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && x.Position == department && x.Team == team && applicantType.Contains(x.TypeEmployee)).ToList();
                    }
                    else if (role == "Human Resource")
                    {
                        result = Context.ApplicantProfile.Where(x => statusApplicant.Contains(x.StatusApplicant) && applicantType.Contains(x.TypeEmployee)).ToList();
                    }
                }
                #endregion
            }
            #endregion

            return result;
        }


    }

}
