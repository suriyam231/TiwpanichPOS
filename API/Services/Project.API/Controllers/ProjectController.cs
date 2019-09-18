using ProjectManagementService.DTOs;
using ProjectManagementService.Interface;
using ProjectManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectService ProjectService;
        public ProjectController(IProjectService Project)
        {
            ProjectService = Project;
        }

        [HttpGet("{projectCode}")]
        [AllowAnonymous]
        public ActionResult<ProjectDTO> GetCard(string projectCode)
        {
            ProjectDTO data = ProjectService.ProjectCard(projectCode);
            return data;
        }



        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<ProjectDTO>> GetDataProject()
        {
            List<ProjectDTO> ProjectDTO = ProjectService.GetDataProject();
            return Ok(ProjectDTO);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<string>> CreateProject(ProjectDTO dataProject)
        {
            try
            {
                string result = await ProjectService.CreateProject(dataProject);
                return Ok();
            }
            catch (Exception ex) { return ex.Message; }

        }

        [HttpPut]
        [AllowAnonymous]
        public ActionResult UpdateProject(ProjectDTO dataedit)
        {
            try
            {
                ProjectService.UpdateProject(dataedit);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{code}")]
        [AllowAnonymous]

        public ActionResult DeleteProject(string code)
        {
            try
            {
                ProjectService.DeleteProject(code);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }



    }
}
