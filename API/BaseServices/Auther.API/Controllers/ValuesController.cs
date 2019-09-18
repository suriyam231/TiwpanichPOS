using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auther.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //[HttpGet]
        //[AllowAnonymous]
        ////[Authorize]
        //public ActionResult<string> Get()
        //{
        //    return "Auth";
        //}

        [Route("veriify")]
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            var response = request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
