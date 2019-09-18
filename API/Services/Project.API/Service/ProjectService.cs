using Microsoft.EntityFrameworkCore;
using ProjectManagementService.DTOs;
using ProjectManagementService.Interface;
using ProjectManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementService.Service
{
    public class ProjectService : IProjectService
    {
        private IRunningNoService ProjectRunning;
        private readonly SRM_DEVContext Context;
        public ProjectService(SRM_DEVContext context, IRunningNoService projectRunning)
        {
            ProjectRunning = projectRunning;
            Context = context;
        }
        // card หน้าบ้านมาเรียก
        public ProjectDTO ProjectCard(string projectCode)
        {
            PjManageProject projectDB = Context.PjManageProject.Where(x => x.ProjectCode == projectCode && x.Active == true).FirstOrDefault();
            ProjectDTO project = new ProjectDTO();
            project.ProjectCode = projectDB.ProjectCode;
            project.ProjectName = projectDB.ProjectName;
            project.Deseription = projectDB.Deseription;
            project.StartDate = projectDB.StartDate;
            project.EndDate = projectDB.EndDate;
            project.PmManday = projectDB.PmManday;
            project.SaManday = projectDB.SaManday;
            project.SdManday = projectDB.SdManday;
            project.Active = projectDB.Active;
            project.Status = projectDB.Status;
            project.Company = GetCompany(projectDB.CompanyCode);
            project.Team = getEmployee(projectCode);
            return project;
        }
        // เรียก company มาจาก DB แค่ตัวเดียว
        public string GetCompany(string companyCode)
        {
            Company companyDB = Context.Company.Where(x => x.CompanyCode == companyCode).FirstOrDefault();
            return companyDB.CompanyName;
        }
        // เรียก employee มาจาด DB 
        public List<EmployeeDTO> getEmployee(string projectCode)
        {
            List<EmployeeDTO> listEmployee = new List<EmployeeDTO>();
            List<PjEmployee> Auther = Context.PjEmployee.Where(z => z.ProjectCode == projectCode).ToList();
            if (Auther != null)
            {
                foreach (PjEmployee team in Auther)
                {
                    EmployeeDTO employee = new EmployeeDTO();
                    employee.SystemCode = team.SystemCode;
                    employee.ProjectCode = team.ProjectCode;
                    employee.Firstname = team.Firstname;
                    employee.Lastname = team.Lastname;
                    employee.Leader = team.Leader;
                    employee.Role = team.Role;
                    employee.Department = team.Department;
                    listEmployee.Add(employee);
                }return listEmployee;
            }
            return listEmployee;
        }

        // get project จาก DB 
        public List<ProjectDTO> GetDataProject()
        {
            List<ProjectDTO> result = new List<ProjectDTO>();
            List<PjManageProject> DataProject = Context.PjManageProject.Where(x => x.Active == true).ToList();

            foreach (PjManageProject project in DataProject)
            {
                ProjectDTO list = new ProjectDTO();
                list.ProjectCode = project.ProjectCode;
                list.ProjectName = project.ProjectName;
                list.Company = GetCompany(project.CompanyCode);
                list.Active = project.Active;
                list.StartDate = project.StartDate;
                list.EndDate = project.EndDate;
                list.Deseription = project.Deseription;
                list.PmManday = project.PmManday;
                list.SaManday = project.SaManday;
                list.SdManday = project.SdManday;
                list.Status = project.Status;
                list.Team = getEmployee(project.ProjectCode);
                result.Add(list);
            }
            return result;
        }
        //เพิ่ม employee ลง DB
        public void CreateEmployee(List<EmployeeDTO> users, string projectCode)
        {
            foreach (EmployeeDTO team in users)
            {
                PjEmployee employee = new PjEmployee();

                employee.ProjectCode = projectCode;
                employee.SystemCode = team.SystemCode;
                employee.Firstname = team.Firstname;
                employee.Lastname = team.Lastname;
                employee.Leader = "SQL";
                employee.Role = "SA";
                employee.Department = ".NET";
                employee.CreatedBy = "SQL";
                employee.CreatedDate = DateTime.Now;
                employee.UpdatedBy = "SQL";
                employee.UpdatedDate = DateTime.Now;
                Context.PjEmployee.Add(employee);
                Context.SaveChanges();
            }
        }
        //เพิ่ม ข้อมูล project ลง DB
        public async Task<string> CreateProject(ProjectDTO addProject)
        {
            try
            {
                PjManageProject check = Context.PjManageProject.Where(x => x.ProjectName == addProject.ProjectName && x.Active == true).FirstOrDefault();
                if (addProject == null) throw new Exception("Please fill out the information.");
                if (check != null) throw new Exception("This project already exists.");
                PjManageProject newData = new PjManageProject();
                newData.ProjectCode = (await ProjectRunning.GenerateRunningNo("PJ")).Code;
                newData.ProjectName = addProject.ProjectName;
                newData.CompanyCode = addProject.Company;
                newData.Active = true;
                newData.Deseription = addProject.Deseription;
                newData.StartDate = addProject.StartDate;
                newData.EndDate = addProject.EndDate;
                newData.PmManday = addProject.PmManday;
                newData.SaManday = addProject.SaManday;
                newData.SdManday = addProject.SdManday;
                newData.Status = addProject.Status;
                newData.CreatedBy = null;
                newData.CreatedDate = DateTime.Now;
                newData.UpdatedBy = null;
                newData.UpdatedDate = DateTime.Now.AddYears(3);
                CreateEmployee(addProject.Team, newData.ProjectCode);// แยกไปใช้อีกฟังชัน
                Context.PjManageProject.Add(newData);
                Context.SaveChanges();

                return "success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUser(string code, List<EmployeeDTO> users)
        {
            List<PjEmployee> CheckUser = Context.PjEmployee.Where(x => x.ProjectCode == code).ToList();

            foreach (EmployeeDTO user in users)
            {
                PjEmployee result = CheckUser.Where(x => x.SystemCode == user.SystemCode).FirstOrDefault();
                if (result == null)
                {
                    result = new PjEmployee()
                    {
                        ProjectCode = code,
                        SystemCode = user.SystemCode,
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Leader = user.Leader,
                        Role = user.Role,
                        Department = user.Department,
                        CreatedBy = "SA",
                        CreatedDate = DateTime.Now,
                        UpdatedBy = "SA",
                        UpdatedDate = DateTime.Now,
                    };

                    Context.Entry(result).State = EntityState.Added;
                    Context.SaveChanges();
                }
            }
            foreach (PjEmployee user in CheckUser)
            {
                EmployeeDTO result = users.Where(x => x.SystemCode == user.SystemCode).FirstOrDefault();
                if (result == null)
                {
                    Context.Entry(user).State = EntityState.Deleted;
                    Context.SaveChanges();
                }
            }
        }

        public void UpdateProject(ProjectDTO dataedit)
        {
            try
            {
                PjManageProject CheckCode = Context.PjManageProject.Where(x => x.ProjectCode == dataedit.ProjectCode).FirstOrDefault();
                PjManageProject CheckName = Context.PjManageProject.Where(x => x.ProjectName == dataedit.ProjectName).FirstOrDefault();
                if (CheckCode.ProjectCode == null) throw new Exception("No data for this project");
                if (CheckName != null && CheckName.ProjectCode != dataedit.ProjectCode) throw new Exception("ProjectName is Duplicate");
                CheckCode.ProjectName = dataedit.ProjectName;
                CheckCode.CompanyCode = dataedit.Company;
                CheckCode.Active = dataedit.Active;
                CheckCode.Deseription = dataedit.Deseription;
                CheckCode.StartDate = dataedit.StartDate;
                CheckCode.EndDate = dataedit.EndDate;
                CheckCode.PmManday = dataedit.PmManday;
                CheckCode.SaManday = dataedit.SaManday;
                CheckCode.SdManday = dataedit.SdManday;
                CheckCode.Status = dataedit.Status;
                CheckCode.CreatedBy = "sql";
                CheckCode.CreatedDate = DateTime.Now;
                CheckCode.UpdatedBy = null;
                CheckCode.UpdatedDate = DateTime.Now.AddYears(3);
                UpdateUser(dataedit.ProjectCode, dataedit.Team);
                Context.PjManageProject.Update(CheckCode);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProject(string ProjectCode)
        {
            try
            {
                List<PjEmployee> Employee = Context.PjEmployee.Where(z => z.ProjectCode == ProjectCode).ToList();
                PjManageProject dataProject = Context.PjManageProject.Where(x => x.ProjectCode == ProjectCode).FirstOrDefault();
                if (dataProject == null) throw new Exception("No data for this project");
                if (Employee != null)
                {
                    foreach (PjEmployee project in Employee)
                    {
                        Context.PjEmployee.Remove(project);
                        Context.SaveChanges();
                    }
                }
                dataProject.Active = false;
                Context.PjManageProject.Update(dataProject);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
