using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicantExamAnswer.API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;

namespace RegisterManange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantExamAnswerHistoryController : ControllerBase
    {
        ApplicantExamAnswerHistoryInterface IAEXAM;
        public ApplicantExamAnswerHistoryController (ApplicantExamAnswerHistoryInterface examanswer)
        {
            IAEXAM = examanswer;
        }

        [Route("addApplicentAnswer/{Empid}")]
        [HttpPost]
        public IActionResult AddSubmitAnswer(ApplicantExamAnswerHistoryDTO[] questions, int Empid)
        {
            try
            {
                string result = IAEXAM.AddSubmitAnswer(questions, Empid);
                return Ok(result);
            }
            catch (Exception e) { return Ok(e.InnerException.Message); }
        }
        [HttpGet("getExamtype/{empId}")]
        public IActionResult getgetExamtype(int empId)
        {
            return Ok(IAEXAM.getExamtype(empId));
        }

        [HttpGet("getAnswerApplicant/{empId}")]
        public IActionResult GetAnswerAppliont(int empId)
        {
            return Ok(IAEXAM.GetAnswerAppliont(empId));
        }
    }
}