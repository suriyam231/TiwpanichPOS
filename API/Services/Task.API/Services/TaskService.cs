using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.DTOs;
using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly SRM_DEVContext Context;
        private ITaskRunningNo TaskRuningNo;

        public TaskService(SRM_DEVContext _Context, ITaskRunningNo _TaskRuningNo)
        {
            Context = _Context;
            TaskRuningNo = _TaskRuningNo;
        }


        public string Deletecode(string code)
        {
            string result;
            TmTaskManagement DeleteTaskCode = Context.TmTaskManagement.Where(x => x.TaskCode == code).FirstOrDefault();
            if (DeleteTaskCode != null)
            {
                Context.TmTaskManagement.Remove(DeleteTaskCode);
                Context.SaveChanges();
                result = "Delete Success!!";
            }
            else
            {
                result = "Error!!";
            }
            return result;
        }


        public void AddTasks(TaskDTO addsTask)
        {
            TmTaskManagement insert = new TmTaskManagement();
            if (insert == null)
            {

            }
            else
            {
                insert.TaskCode = TaskRuningNo.GenerateRunningNo().Result.Code;
                insert.TaskName = addsTask.TaskName;
                insert.ProjectCode = addsTask.ProjectCode;
                insert.Comment = addsTask.Comment;
                insert.Manday = addsTask.Manday;
                insert.Status = addsTask.Status;
                insert.CreatedBy = "Test";
                insert.CreatedDate = DateTime.Now;

                var InsertSystemCode = Context.TmTaskManagement.Where(x => x.SystemCode == addsTask.SystemCode && x.Active == false && x.SystemCode == null).FirstOrDefault();
                if (InsertSystemCode != null)
                {
                    insert.Active = false;
                    Context.TmTaskManagement.Add(insert);
                    Context.SaveChanges();
                }
                else
                {
                    insert.Active = true;
                    insert.SystemCode = addsTask.SystemCode;
                    insert.StartDate = addsTask.StartDate.ToLocalTime();
                    insert.EndDate = addsTask.EndDate.ToLocalTime();
                    var countDup = Context.TmTaskManagement.Count(x => (x.StartDate >= insert.StartDate && x.EndDate <= insert.EndDate));
                    if (countDup > 0)
                    {
                        return;
                    }
                    Context.TmTaskManagement.Add(insert);
                    Context.SaveChanges();
                }
               // insert.Active = false;
                // insert.Comment = addsTask.Comment;
                // insert.Manday = addsTask.Manday;
                // insert.Status = addsTask.Status;
                // //insert.StartDate = addsTask.StartDate.ToLocalTime();
                // //insert.EndDate = addsTask.EndDate.ToLocalTime();
                // insert.CreatedBy = "Test";
                // insert.CreatedDate = DateTime.Now;

                // Context.TmTaskManagement.Add(insert);
                // Context.SaveChanges();
                // return insert;
            }
        }



        public TmTaskManagement EditTask(TmTaskManagement EditTasks)
        {
            TmTaskManagement EditTaskCode = Context.TmTaskManagement.Where(x => x.TaskCode == EditTasks.TaskCode).FirstOrDefault();
            if (EditTaskCode == null)
            {
                return EditTaskCode;
            }
            else
            {

                EditTaskCode.TaskName = EditTasks.TaskName;
                EditTaskCode.SystemCode = EditTasks.SystemCode;
                EditTaskCode.ProjectCode = EditTasks.ProjectCode;
                EditTaskCode.Comment = EditTasks.Comment;
                EditTaskCode.Active = true;
                EditTaskCode.Manday = EditTasks.Manday;
                EditTaskCode.Status = EditTasks.Status;
                EditTaskCode.StartDate = EditTasks.StartDate;
                EditTaskCode.EndDate = EditTasks.EndDate;
                EditTaskCode.UpdatedBy = "TEST";
                EditTaskCode.UpdatedDate = DateTime.Now;

                Context.TmTaskManagement.Update(EditTaskCode);
                Context.SaveChanges();
                return EditTaskCode;
            }
        }



        public List<TmTaskManagement> GetTask()
        {
            List<TmTaskManagement> result = Context.TmTaskManagement.ToList();

            return result;
        }



        public List<TmTaskManagement> GetTaskTable()
        {
            List<TmTaskManagement> result = Context.TmTaskManagement.ToList();

            return result;
        }

        public string AddTassk(TaskDTO addsTask)
        {
            throw new NotImplementedException();
        }

        public List<TmTaskManagement> GetTaskProject(string codeProject)
        {
            List<TmTaskManagement> result = Context.TmTaskManagement.Where(x => x.ProjectCode == codeProject).ToList();
            return result;
        }

        public List<TmTaskManagement> TaskSelect()
        {
            List<TmTaskManagement> DataTask = Context.TmTaskManagement.ToList();
            return DataTask;
        }


        public List<TaskPublicDTO> GetTaskPublic()
        {
            IQueryable<TaskPublicDTO> result = from data in Context.TmTaskManagement.Where(x => x.Active == false)
                                               group data by data.ProjectCode into g
                                               select new TaskPublicDTO()
                                               {
                                                   TaskCode = g.Key,
                                                   ProjectCode = g.Select(x => x.ProjectCode).FirstOrDefault(),
                                                   TaskName = g.Select(x => x.TaskName).ToList()
                                               };
            List<TaskPublicDTO> lastResult = new List<TaskPublicDTO>();
            foreach (TaskPublicDTO a in result)
            {
                lastResult.Add(a);
            }
            return lastResult;
        }


        public TmTaskManagement GetTaskCode(string DateGetTaskCode)
        {
            TmTaskManagement GetTaskCode = Context.TmTaskManagement.Where(x => x.TaskName == DateGetTaskCode).FirstOrDefault();
            if (GetTaskCode == null)
            {
                return null;
            }
            else
            {
                return GetTaskCode;
            }
        }
    }
}
