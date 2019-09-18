using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.DTOs;
using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService TaskService;
        public TaskController(ITaskService _TaskService)
        {
            TaskService = _TaskService;
        }
        [HttpGet("Get")]
        public ActionResult<List<TmTaskManagement>> GetTasks()
        {
            return Ok(TaskService.GetTask());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Selectfilter")]
        public ActionResult<List<TaskPublicDTO>> GetTaskPublic()
        {
            //List<TaskPublicDTO> Select = TaskService.GetTaskPublic();
            return Ok(); //get ข้อมูลของงานทุกหมด
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("DateGetTaskCode")]
        public ActionResult<TmTaskManagement> GetTaskCode(string DateGetTaskCode)
        {
            //TmTaskManagement Get = TaskService.GetTaskCode(DateGetTaskCode);

            return Ok();
        }

        [HttpGet("GetTaskTable")]
        public ActionResult<List<PjManageProject>> GetTaskclass()
        {
            return Ok(TaskService.GetTaskTable());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Select")]
        public ActionResult<List<TmTaskManagement>> TaskSelect()
        {
            List<TmTaskManagement> Tasks = TaskService.TaskSelect();
            return Ok(Tasks); //get ข้อมูลของงานทุกหมด
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetTaskProject")]
        public ActionResult<List<TmTaskManagement>> GetTaskProject(string codeProject)
        {
            List<TmTaskManagement> result = TaskService.GetTaskProject(codeProject);
            return Ok(result);
        }

        //[HttpGet]
        //[AllowAnonymous]
        //[Route("Selectadd")]
        //public ActionResult<List<TaskDTO>> SelectSelect()
        //{
        //    //List<TaskDTO> Tasks = TaskService.SelectSelect();
        //    //return Ok(Tasks); //get ข้อมูลของงานทุกหมด
        //}
        [HttpPost]
        [AllowAnonymous]
        [Route("AddTask")]
        public ActionResult AddTask(TaskDTO addsTask) //addข้อมุลไปยัง  sql
        {
            TaskService.AddTasks(addsTask);
            return Ok();
        }


        [HttpPut("Update")]
        [AllowAnonymous]
        public ActionResult<string> PutEditTask(TmTaskManagement classTask)
        {
            TaskService.EditTask(classTask);
            return Ok(classTask);
        }

        [HttpDelete("{code}")]
        [AllowAnonymous]
        public ActionResult<dynamic> Delete(string code)
        {
            string result = TaskService.Deletecode(code);
            if (result == null)
                return BadRequest();
            return Ok(new { result });
        }
    }
}
