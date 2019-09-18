using Dashboard.DTOs;
using Dashboard.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Service
{
    public class TaskteamService: Taskteam
    {
        public List<TaskteamDTO> GetTaskteams()
        {
            List<TaskteamDTO> Taskteams = new List<TaskteamDTO>();
        TaskteamDTO Task1 = new TaskteamDTO();
            {
                // TaskPersonID = "create database";
                //string PersonID = "Chinya";
                //string Status = "Inprogress",
                //CreateBy = "Smurf",
                //CreateDate = DateTime.Now,
                //string UpdateBy = "Nuna";
                //DateTime UpdateDate = DateTime.Now.AddDays(1);
            };
            Taskteams.Add(Task1);
            return Taskteams;
        }

        
    }
}
