using Listapplicant.DTOs;
using Listapplicant.Interface;
using Listapplicant.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Listapplicant.Controllers
{
    [Route("api/list")]
    [ApiController]

    public class ListapplicantController : ControllerBase
    {
        private IListapplicant Listapplicant;
        // GET api/values
        public ListapplicantController(IListapplicant _Listapplicant) {
            Listapplicant = _Listapplicant;
        }
         [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<ListapplicantDTO> Datalist = Listapplicant.GetListapplicants();
            return Ok(Datalist);
        }
    }
}
