using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.API.Interface;
using Database.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Database.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBDepartmentGroupController : ControllerBase
    {
        DBDepartmentGroupInterface IDepartment;

        public DBDepartmentGroupController(DBDepartmentGroupInterface department)
        {
            IDepartment = department;

        }


        [HttpGet("Get")]
        public IActionResult GetDepartments()
        {
            return Ok(IDepartment.GetDepartments());
        }

        [HttpGet("GetList")]
        public IActionResult GetGroups()
        {
            return Ok(IDepartment.GetGroups());
        }

        [Route("AddListOfValue")]
        [HttpPost]
        public IActionResult AddListOfValue(DbDepartmentGroup value)
        {
            try
            {
                string result = IDepartment.AddListOfValue(value);
                return Ok(result);

            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }

        [Route("EditListOfValue/{DEPARTMENTGROUP}/{DEPARTMENTNAME}/{OLDDEPARTMENTGROUP}/{OLDDEPARTMENTNAME}")]
        [HttpPost]
        public IActionResult EditListOfValue(DbDepartmentGroup value, string OLDDEPARTMENTGROUP, string OLDDEPARTMENTNAME)
        {
            try
            {
                string result = IDepartment.EditListOfValue(value,OLDDEPARTMENTGROUP, OLDDEPARTMENTNAME);
                return Ok(result);

            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }

        [Route("DeleteOfValue/{DEPARTMENTGROUP}/{DEPARTMENTNAME}")]
        [HttpDelete]
        public IActionResult DeleteOfValue(string DEPARTMENTGROUP, string DEPARTMENTNAME)
        {
            try
            {
                DbDepartmentGroup value = new DbDepartmentGroup
                {
                    DepartmentGroup = DEPARTMENTGROUP,
                    DepartmentName = DEPARTMENTNAME
                };
                string result = IDepartment.DeleteOfValue(value);
                return Ok(result);
            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }



    }
}