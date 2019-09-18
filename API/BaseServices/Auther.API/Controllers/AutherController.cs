using Auther.API.DTOs;
using Auther.API.Interfaces;
using Auther.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutherController : ControllerBase
    {
        IAutherService AutherService;

        public AutherController(IAutherService AutherService) {
            this.AutherService = AutherService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<EmployeeProfile>> Get()
        {
            return Ok(AutherService.GetAuther());
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login(Employee user)
        {
            if (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password))
            {
                try
                {
                    //Task<string> returns = AutherService.lo(user.Username,user.Password);
                    //string token = AutherService.Login(user.Username, user.Password);
                    TokenDTO data = AutherService.Login(user.Username, user.Password);

                    if (data.Message == "Login Success")
                    {
                        return Ok(data);
                    }
                    else
                    {
                        return BadRequest(data.Message);
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.ToString());
                }
            }
            else
            {
                return BadRequest("Username or Password is incorrect. Please Try again!!");
            }
        }
    }
}
