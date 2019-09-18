using RunningNo.API.DTOs;
using RunningNo.API.Interfaces;
using RunningNo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningNo.API.Services
{
    public class RunningTypeService : IRunningTypeService
    {
        private readonly ISRMContext Context;
        public RunningTypeService(ISRMContext _context)
        {
            Context = _context;
        }

        public string CreateRunningType(RuRunningType RunningType)
        {
            try
            {
                    RuRunningType runningType = new RuRunningType();
                    runningType.Code = RunningType.Code;
                    runningType.Name = RunningType.Name;
                    runningType.RunningNoFormat = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}[RUNNING]";
                    runningType.RunningNoDigit = RunningType.RunningNoDigit;
                    runningType.Active = true;
                    runningType.CreatedBy = "System";
                    runningType.CreatedDate = DateTime.Now;
                    Context.RuRunningType.Add(runningType);
                    Context.SaveChanges();
                    return runningType.Code;
               
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public RuRunningType GetRunningType(string RunningTypeCode)
        {
            try {
                RuRunningType runningType = Context.RuRunningType.Where(x => x.Code == RunningTypeCode).FirstOrDefault();
                if (runningType != null)
                {
                    return runningType;
                }
                else
                {
                    //CreateRunningType(runningType);
                    return runningType;
                }
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
