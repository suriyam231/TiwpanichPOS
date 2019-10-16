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
    public class PageController : ControllerBase
    {
        PageInterface IPage;
        public PageController(PageInterface page)
        {
            IPage = page;
        }

        [HttpGet("getProvine")]
        public IActionResult getProvice()
        {
            return Ok(IPage.GetProvinces());
        }

        [HttpGet("getDistrict/{District}")]
        public IActionResult getDistrict(string District)
        {
            return Ok(IPage.GetDistricts(District));
        }

        [HttpGet("getSubdistricts/{Subdistricts}")]
        public IActionResult getSubdistricts(string Subdistricts)
        {
            return Ok(IPage.GetSubdistricts(Subdistricts));
        }

        [HttpPost("addRegister/{data}")]
        public IActionResult addRegister(ProfileUser data)
        {
            return Ok(IPage.addRegister(data));
        }
    }
}