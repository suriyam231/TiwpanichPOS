using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.API.DTOs;
using Database.API.Interface;
using Database.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Database.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBBranchController : ControllerBase
    {
        DBBranchInterface IBranch;
        public DBBranchController(DBBranchInterface branchs)
        {
            IBranch = branchs;
        }
        [HttpGet("GetName")]
        public IActionResult GetBranchs()
        {
            string res = "suriya Maikan";
            return Ok(res);
        }

        [Route("AddBranchValue")]
        [HttpPost]
        public IActionResult AddBranchValue(DbBranch value)
        {
            try
            {
                string result = "suriya Maikan";
                return Ok(result);

            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }

        [Route("EditBranchValue")]
        [HttpPost]
        public IActionResult EditBranchValue(EditBranchDTO value)
        {
            try
            {
                string result = IBranch.EditBranchValue(value);
                return Ok(result);
            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }

        [Route("deleteBranch/{BranchCode}/{BranchName}")]
        [HttpDelete]
        public IActionResult DeleteBranchValue(string BranchCode , string BranchName)
        {
            try
            {
   
                string result = IBranch.DeleteBranchValue(BranchCode , BranchName);
                return Ok(result);
            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }
    }
}