using System;
using System.Threading.Tasks;
using JoinUs.API.Interface;
using Microsoft.AspNetCore.Authorization;
using ListApplicant.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net;
using System.IO;
using RegisterManange.API.DTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JoinUs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinUsController : ControllerBase
    {

        JoinUsInterface IJoinUs;
        public JoinUsController(JoinUsInterface joinUs)
        {
            IJoinUs = joinUs;
        }

        [Route("Applicant")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(ApplicantDTO data)
        {
            return Ok(await IJoinUs.SaveApplicant(data));
        }

        [Route("Address")]
        [HttpGet]
        public IActionResult GetAddress([FromQuery(Name = "value")] int value, [FromQuery(Name = "type")] string type)
        {
            return Ok(IJoinUs.GetAddress(type, value));
        }

        [HttpGet("Get")]
        public IActionResult GetProfile()
        {
            return Ok(IJoinUs.GetDataProfile());
        }

        [HttpGet("GetProfileByID/{id}")]
        [AllowAnonymous]
        public ApplicantDTO GetDataProfile(int id)
        {
            ApplicantDTO applicantProfile = IJoinUs.GetDataProfileByID(id);
            return applicantProfile;
        }

        [Route("UpdateStatusApplicant")]
        [HttpPut]
        public IActionResult UpdateStatusApplicant([FromBody] UpdateStatusDTO status)
        {
            string result = IJoinUs.UpdateProfileStatus(status);
            return Ok();
        }

        [Route("SearchByHR")]
        [HttpGet]
        public IActionResult GetDataProfileByHR([FromQuery(Name = "name")] string name, [FromQuery(Name = "date")] string date, [FromQuery(Name = "type")] string type)
        {
            return Ok(IJoinUs.GetDataProfileByHR(name, date, type));
        }

        [HttpGet("SearchCheckProgress/{IdCard}")]
        [AllowAnonymous]
        public IActionResult GetDataCheckProgress(string IDcard)
        {
            return Ok(IJoinUs.GetDataCheckProgress(IDcard));
        }

        [Route("updateStatus")]
        [HttpPut]
        public IActionResult UpdateStatus([FromBody] UpdateStatusDTO status)
        {
            string result = IJoinUs.updateStatus(status);
            return Ok();
        }

        [Route("TestUploadFiles")]
        [HttpPost]
        public IActionResult TestUploadFiles()
        {
            return Ok();
        }

        [Route("UploadFiles/{empID}")]
        [HttpPost]
        public IActionResult UploadFiles(string empID)
        {
            string result = string.Empty;
            IFormFileCollection files = Request.Form.Files;

            if (files.Count > 0)
            {
                result = IJoinUs.UploadFiles(empID, files);
            }

            return Ok(result);
        }

        [Route("GetFileName/{empID}")]
        [HttpGet]
        public string[] GetFileName(string empID)
        {
            return IJoinUs.GetFileName(empID);
        }

        [Route("DownloadFile")]
        [HttpGet]
        public IActionResult DownloadFile([FromQuery(Name = "empID")] string empID, [FromQuery(Name = "fileName")] string fileName)
        {
            try
            {
                string contentType = string.Empty;
                var memory = IJoinUs.GetFiles(empID, fileName, ref contentType);
                return File(memory, contentType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
