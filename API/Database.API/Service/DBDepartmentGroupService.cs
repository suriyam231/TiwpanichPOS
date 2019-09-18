using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.API.Interface;
using Database.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Database.API.Service
{
    public class DBDepartmentGroupService : DBDepartmentGroupInterface
    {
        private readonly SRM_DEVContext Context;

       
        public DBDepartmentGroupService(SRM_DEVContext context)
        {
            Context = context;
        }

        
        public List<DbDepartmentGroup> GetDepartments()
        {
            List<DbDepartmentGroup> result = (from Department in Context.DbDepartmentGroup
                                              select new DbDepartmentGroup

                                              {
                                                  DepartmentGroup = Department.DepartmentGroup,
                                                  DepartmentName = Department.DepartmentName,
                                                  CrBy = Department.CrBy,
                                                  CrDate = Department.CrDate,
                                                  UpdBy = Department.UpdBy,
                                                  UpdDate = Department.UpdDate
                                              }).ToList();
            return result;
        }

        public List<DbDepartmentGroup> GetGroups()
        {
            List<DbDepartmentGroup> result =(from Department in Context.DbDepartmentGroup
                                             select new DbDepartmentGroup
                                             {
                                                 DepartmentGroup = Department.DepartmentGroup,
                                                 DepartmentName = Department.DepartmentName
                                             }).ToList();
            return result;

        }

        public List<DbDepartmentGroup> GetDataOfValue (DbDepartmentGroup value)
        {
            List<DbDepartmentGroup> result = (from Department in Context.DbDepartmentGroup
                                     where (value.DepartmentGroup == null || Department.DepartmentGroup == value.DepartmentGroup)

                                     select new DbDepartmentGroup
                                     {
                                         DepartmentGroup = Department.DepartmentGroup,
                                         DepartmentName = Department.DepartmentName,
                                         CrBy = Department.CrBy,
                                         CrDate = Department.CrDate,
                                         UpdBy = Department.UpdBy,
                                         UpdDate = Department.UpdDate

                                     }).ToList();
            return result;
        }

        public string AddListOfValue(DbDepartmentGroup value)
        {
            Database.API.Models.DbDepartmentGroup ListOfValue = new Database.API.Models.DbDepartmentGroup ();

            ListOfValue.DepartmentGroup = value.DepartmentGroup;
            ListOfValue.DepartmentName = value.DepartmentName;
            ListOfValue.CrBy = value.CrBy;
            ListOfValue.CrDate = DateTime.Now;
            ListOfValue.UpdBy = value.CrBy;
            ListOfValue.UpdDate = DateTime.Now;
            

            Context.DbDepartmentGroup.Add(ListOfValue);
            Context.SaveChanges();

            return "success";
        }

        public string EditListOfValue(DbDepartmentGroup value, string OLDDEPARTMENTGROUP, string OLDDEPARTMENTNAME)
        {
            Database.API.Models.DbDepartmentGroup ListOfValue = new Database.API.Models.DbDepartmentGroup();

            ListOfValue = Context.DbDepartmentGroup.Where(x => x.DepartmentGroup == OLDDEPARTMENTGROUP || x.DepartmentName == OLDDEPARTMENTNAME).FirstOrDefault();

            ListOfValue.DepartmentName = value.DepartmentName;
            ListOfValue.CrBy = value.CrBy;
            ListOfValue.CrDate = DateTime.Now;
            ListOfValue.UpdBy = value.CrBy;
            ListOfValue.UpdDate = DateTime.Now;

            Context.DbDepartmentGroup.Update(ListOfValue);
            Context.SaveChanges();

            return "success";
        }

        public string DeleteOfValue(DbDepartmentGroup value)
        {
            Database.API.Models.DbDepartmentGroup ListOfValue = new Database.API.Models.DbDepartmentGroup();
            ListOfValue = Context.DbDepartmentGroup.Where(x => x.DepartmentGroup == value.DepartmentGroup || x.DepartmentName == value.DepartmentName).FirstOrDefault();

            Context.DbDepartmentGroup.Remove(ListOfValue);
            Context.SaveChanges();

            return "success";
        }




    }
}