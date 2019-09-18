using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.DTOs;
using TaskManagement.Models;

namespace TaskManagement.Interface
{
    public interface ITaskService
    {
        List<TmTaskManagement> TaskSelect();
        void AddTasks(TaskDTO addsTask);
        TmTaskManagement EditTask(TmTaskManagement EditTasks);
        string Deletecode(string code);
        List<TmTaskManagement> GetTask();
        List<TmTaskManagement> GetTaskTable();
        string AddTassk(TaskDTO addsTask);
        //List<TaskDTO> SelectSelect();
        List<TmTaskManagement> GetTaskProject(string codeProject);
    }
}
