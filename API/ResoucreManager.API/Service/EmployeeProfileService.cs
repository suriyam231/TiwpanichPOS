using ResoucreManager.API.DTOs;
using ResoucreManager.API.Interface;
using ResoucreManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResoucreManager.API.Service
{
    public class EmployeeProfileService : EmployeeProfileInterface
    {
        private readonly SRM_DEVContext Context;

        public EmployeeProfileService(SRM_DEVContext context)
        {
            Context = context;
        }


        public EmployeeDTO getEmployeeProfile(string empCode)
        {
            EmployeeDTO employeeData = new EmployeeDTO();
            EmployeeProfile employeeProfile = new EmployeeProfile();

            employeeProfile = Context.EmployeeProfile.Where(x => x.Empcode == empCode).FirstOrDefault();

            employeeData.EmployeeProfile = employeeProfile;

            return employeeData;
        }

        public async Task<string> saveEmployeeProfile(EmployeeDTO data)
        {
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    #region // ########## Table APPLICANT_PROFILE ########## //
                    EmployeeProfile employeeProfile = new EmployeeProfile();
                    employeeProfile = Context.EmployeeProfile.Where(x => x.Empcode == data.EmployeeProfile.Empcode).FirstOrDefault();

                    // รูปโปรไฟล์
                    employeeProfile.ImgPath = data.EmployeeProfile.ImgPath;

                    // ข้อมูล
                    employeeProfile.Empcode = data.EmployeeProfile.Empcode;
                    //employeeProfile.Username = data.EmployeeProfile.Username;
                    //employeeProfile.Password = data.EmployeeProfile.Password;
                    //employeeProfile.Passwordsalt = data.EmployeeProfile.Passwordsalt;
                    employeeProfile.Position  = data.EmployeeProfile.Position;
                    employeeProfile.Company = data.EmployeeProfile.Company;
                    employeeProfile.Department = data.EmployeeProfile.Department;
                    //employeeProfile.Team = data.EmployeeProfile.Team;
                    employeeProfile.Salary = data.EmployeeProfile.Salary;
                    employeeProfile.Active = data.EmployeeProfile.Active;

                    // ข้อมูลส่วนตัว
                    employeeProfile.FirstnameTh = data.EmployeeProfile.FirstnameTh;
                    employeeProfile.LastnameTh = data.EmployeeProfile.LastnameTh;
                    employeeProfile.FirstnameEn = data.EmployeeProfile.FirstnameEn;
                    employeeProfile.LastnameEn = data.EmployeeProfile.LastnameEn;
                    employeeProfile.Birthday = data.EmployeeProfile.Birthday;
                    employeeProfile.Age = data.EmployeeProfile.Age;
                    employeeProfile.Birthday = data.EmployeeProfile.Birthday;
                    employeeProfile.IdCard = data.EmployeeProfile.IdCard;
                    employeeProfile.Gender = data.EmployeeProfile.Gender;
                    employeeProfile.Status = data.EmployeeProfile.Status;
                    employeeProfile.Nationality = data.EmployeeProfile.Nationality;
                    employeeProfile.Religion = data.EmployeeProfile.Religion;

                    // ข้อมูลการติดต่อ
                    employeeProfile.Tel = data.EmployeeProfile.Tel;
                    employeeProfile.Email = data.EmployeeProfile.Email;

                    // ข้อมูลที่อยู่
                    employeeProfile.Address = data.EmployeeProfile.Address;
                    employeeProfile.Province = data.EmployeeProfile.Province;
                    employeeProfile.District = data.EmployeeProfile.District;
                    employeeProfile.SubDistrict = data.EmployeeProfile.SubDistrict;
                    employeeProfile.PostalCode = data.EmployeeProfile.PostalCode;

                    employeeProfile.UpdBy = data.EmployeeProfile.FirstnameEn;
                    employeeProfile.UpdDate = DateTime.Now;

                    Context.EmployeeProfile.Update(employeeProfile);
                    Context.SaveChanges();
                    dbContextTransaction.Commit();
                    #endregion
                    return "Save Success";
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return "error";
                }
            }
        }
    }
}
