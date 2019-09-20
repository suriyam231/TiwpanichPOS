using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.API.Interface;
using Microsoft.AspNetCore.Mvc;



namespace Database.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : Controller
    {
        AppInterface IApp;
        public AppController(AppInterface app)
        {
            IApp = app;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getProvine")]
        public IActionResult getProvice()
        {
            return Ok(IApp.GetProvinces());
        }
    }
}
