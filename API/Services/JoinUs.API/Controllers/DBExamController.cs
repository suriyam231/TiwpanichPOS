using Exam.API.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBExamController : ControllerBase
    {
        DBExamInterface IExam;
        public DBExamController(DBExamInterface exam)
        {
            IExam = exam;
        }

        [HttpGet("GetQuestion")]
        public IActionResult getallQuestion()
        {
            return Ok(IExam.getallQuestion());
        }

       

        [HttpGet("getallExamtype")]
        public IActionResult getallExamtype()
        {
            return Ok(IExam.getallExamtype());
        }

        [HttpGet("getallQuestiontype")]
        public IActionResult getallQuestiontype()
        {
            return Ok(IExam.getallQuestiontype());
        }

        [Route("addQuestionvalues")]
        [HttpPost]
        public IActionResult addQuestionvalues(DbExam value)
        {
            try
            {
                string result = IExam.addQuestionvalues(value);
                return Ok(result);

            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }

        [Route("editQuestionvalues")]
        [HttpPost]
        public IActionResult editQuestionvalues(DbExam value)
        {
            try
            {
                string result = IExam.editQuestionvalues(value);
                return Ok(result);
            }
            catch (Exception e) { return Ok(); }
        }

        [Route("deleteQuetion/{examType}/{questionType}/{question}")]
        [HttpDelete]
        public IActionResult deleteQuetionvalues(string examType,string questionType,string question)
        {
            try
            {

               string result = IExam.deleteQuetionvalues(examType,questionType,question);
                return Ok();
            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }

  
        [Route("TestUploadFiles")]
        [HttpPost]
        public IActionResult TestUploadFiles()
        {
            return Ok();
        }

        [Route("GetIdCard/{IdCard}")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetDataCheckIdCard(string IdCard)
        {
            return Ok(IExam.GetDataCheckIdCard(IdCard));
        }


        [Route("getDataQuestion")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetDataQuestion()
        {
        
            return Ok(IExam.GetDataQuestion());
        }

        [Route("Groupby")]
        [HttpGet]
        public IActionResult getGroupby()
        {
            return Ok(IExam.getGroupby());
        }

        [Route("getExamType")]
        [HttpGet]
        public IActionResult getExamType()
        {
            return Ok(IExam.getExamType());
        }

        [Route("getDepartmentName")]
        [HttpGet]
        public IActionResult getDepartmentName()
        {
            return Ok(IExam.getDepartmentName());
        }
        [HttpGet("getTable")]
        public IActionResult getTable()
        {
            return Ok(IExam.getTable());
        }
        [Route("addExamGroup")]
        [HttpPost]
        public IActionResult addExamGroupDepartmentGroup(DbExamType value)
        {
            try
            {
                string result = IExam.addExamGroupDepartmentGroup(value);
                return Ok(result);

            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }

        [Route("editExamGroup")]
        [HttpPost]
        public IActionResult editExamGroup(DbExamTypeDTO value)
        {
            try
            {
                string result = IExam.editExamGroup(value);
                return Ok(result);

            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }

        [HttpGet("getDepartmentGroup")]
        public IActionResult getDepartmentGroup()
        {
            return Ok(IExam.getDepartmentGroup());
        }

        [HttpGet("getExamTypeName")]
        public IActionResult getExamTypeName()
        {
            return Ok(IExam.getExamTypeName());
        }

        [HttpPost("addExamDepartmentGroup")]
        public IActionResult addExamDepartmentGroup(List<string> value)
        {
            try
            {
                string result = IExam.addExamDepartmentGroup(value);
                return Ok(result);

            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }



        [HttpPost("editExamGroupDepartmentGroup")]
        public IActionResult editExamGroupDepartmentGroup(List<string> value)
        {
            try
            {
                string result = IExam.editExamGroupDepartmentGroup(value);
                return Ok(result);

            }
            catch (Exception e)
            {
                return Ok(e.InnerException.Message);
            }
        }



    }
}