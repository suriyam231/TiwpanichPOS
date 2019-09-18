using RunningNo.API.DTOs;
using RunningNo.API.Interfaces;
using RunningNo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningNo.API.Services
{
    public class RunningNoService : IRunningNoService
    {
        private readonly ISRMContext Context;
        private IRunningTypeService RunningTypeService;
        public RunningNoService(ISRMContext _context, IRunningTypeService _runningTypeService)
        {
            Context = _context;
            RunningTypeService = _runningTypeService;
        }

        public RuRunningNo CheckParameter(int Count, string runningCode, params string[] parameter)
        {
            RuRunningNo Running = new RuRunningNo();
            if (Count >= 0 && Count <= parameter.Length)
            {
                if (Count == 0)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && string.IsNullOrWhiteSpace(x.Parameter1)).FirstOrDefault();
                }
                if (Count == 1)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && x.Parameter1 == parameter[0]).FirstOrDefault();
                }
                if (Count == 2)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && x.Parameter1 == parameter[0] && x.Parameter2 == parameter[1]).FirstOrDefault();
                }
                if (Count == 3)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && x.Parameter1 == parameter[0] && x.Parameter2 == parameter[1] && x.Parameter3 == parameter[2]).FirstOrDefault();
                }
                if (Count == 4)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && x.Parameter1 == parameter[0] && x.Parameter2 == parameter[1] && x.Parameter3 == parameter[2]
                    && x.Parameter4 == parameter[3]).FirstOrDefault();
                }
                if (Count == 5)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && x.Parameter1 == parameter[0] && x.Parameter2 == parameter[1] && x.Parameter3 == parameter[2]
                    && x.Parameter4 == parameter[3] && x.Parameter5 == parameter[4]).FirstOrDefault();
                }
                if (Count == 6)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && x.Parameter1 == parameter[0] && x.Parameter2 == parameter[1] && x.Parameter3 == parameter[2]
                    && x.Parameter4 == parameter[3] && x.Parameter5 == parameter[4] && x.Parameter6 == parameter[5]).FirstOrDefault();
                }
                if (Count == 7)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && x.Parameter1 == parameter[0] && x.Parameter2 == parameter[1] && x.Parameter3 == parameter[2]
                    && x.Parameter4 == parameter[3] && x.Parameter5 == parameter[4] && x.Parameter6 == parameter[5]
                    && x.Parameter7 == parameter[6]).FirstOrDefault();
                }
                if (Count == 8)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && x.Parameter1 == parameter[0] && x.Parameter2 == parameter[1] && x.Parameter3 == parameter[2]
                    && x.Parameter4 == parameter[3] && x.Parameter5 == parameter[4] && x.Parameter6 == parameter[5]
                    && x.Parameter7 == parameter[6] && x.Parameter8 == parameter[7]).FirstOrDefault();
                }
                if (Count == 9)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && x.Parameter1 == parameter[0] && x.Parameter2 == parameter[1] && x.Parameter3 == parameter[2]
                    && x.Parameter4 == parameter[3] && x.Parameter5 == parameter[4] && x.Parameter6 == parameter[5]
                    && x.Parameter7 == parameter[6] && x.Parameter8 == parameter[7] && x.Parameter9 == parameter[8]).FirstOrDefault();
                }
                if (Count == 10)
                {
                    Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode
                    && x.Parameter1 == parameter[0] && x.Parameter2 == parameter[1] && x.Parameter3 == parameter[2]
                    && x.Parameter4 == parameter[3] && x.Parameter5 == parameter[4] && x.Parameter6 == parameter[5]
                    && x.Parameter7 == parameter[6] && x.Parameter8 == parameter[7] && x.Parameter9 == parameter[8]
                    && x.Parameter10 == parameter[9]).FirstOrDefault();
                }
            }
            return Running;
        }

        public RuRunningNo CreateRunningNo(RuRunningType runningType, params string[] parameter)
        {
            int Count = parameter.Length;
            RuRunningNo CreateRunning = new RuRunningNo();
            CreateRunning.RunningTypeCode = runningType.Code;
            if (Count > 0 && Count <= parameter.Length)
            {
                if (Count >= 1)
                    if (!string.IsNullOrWhiteSpace(parameter[0]))
                        CreateRunning.Parameter1 = parameter[0];
                if (Count >= 2)
                    if (!string.IsNullOrWhiteSpace(parameter[1]))
                        CreateRunning.Parameter2 = parameter[1];
                if (Count >= 3)
                    if (!string.IsNullOrWhiteSpace(parameter[2]))
                        CreateRunning.Parameter3 = parameter[2];
                if (Count >= 4)
                    if (!string.IsNullOrWhiteSpace(parameter[3]))
                        CreateRunning.Parameter4 = parameter[3];
                if (Count >= 5)
                    if (!string.IsNullOrWhiteSpace(parameter[4]))
                        CreateRunning.Parameter5 = parameter[4];
                if (Count >= 6)
                    if (!string.IsNullOrWhiteSpace(parameter[5]))
                        CreateRunning.Parameter6 = parameter[5];
                if (Count >= 7)
                    if (!string.IsNullOrWhiteSpace(parameter[6]))
                        CreateRunning.Parameter7 = parameter[6];
                if (Count >= 8)
                    if (!string.IsNullOrWhiteSpace(parameter[7]))
                        CreateRunning.Parameter8 = parameter[7];
                if (Count >= 9)
                    if (!string.IsNullOrWhiteSpace(parameter[8]))
                        CreateRunning.Parameter9 = parameter[8];
                if (Count >= 10)
                    if (!string.IsNullOrWhiteSpace(parameter[9]))
                        CreateRunning.Parameter10 = parameter[9];
            }
            CreateRunning.RunningNo = 0;
            CreateRunning.Active = true;
            CreateRunning.CreatedBy = "Ru";
            CreateRunning.CreatedDate = DateTime.Now;
            Context.RuRunningNo.Add(CreateRunning);
            Context.SaveChanges();
            return CreateRunning;
        }

        public ReturnMessageDTO GenerateRunningNo(string runningCode, params string[] parameter)
        {
            ReturnMessageDTO returnMessageDTO = new ReturnMessageDTO();
            try
            {
                //get running type and check null and not null
                RuRunningType runningType = RunningTypeService.GetRunningType(runningCode);

                //check running no มันคือการ get ข้อมูมลจาก database
                if (runningType == null) throw new Exception("Not found running Tpye!!");
                RuRunningNo Running = Context.RuRunningNo.Where(x => x.RunningTypeCode == runningCode).FirstOrDefault();
                // ถ้ามัน ไม่มี วิ่งไป create แล้วส่งกลับมาเป็น RunningType
                Running = CheckParameter(parameter.Length, runningCode,parameter);
                if (Running == null)
                {
                    CreateRunningNo(runningType, parameter);
                    returnMessageDTO = GenerateRunningNo(runningCode, parameter);
                    return returnMessageDTO;
                }
                // ถ้าเจอ ก็ update ในนี้แหล่ะ
                else Running = CheckParameter(parameter.Length, runningCode,parameter);

                if (Running.Active == true && Running != null)
                {
                    //if (checkParameter(runningType, parameter) == true)
                    //{
                        Running.RunningNo++;
                        Running.UpdatedDate = DateTime.Now;
                        Running.UpdatedBy = "RunningNoService";
                        string runningDigit = Running.RunningNo.ToString().PadLeft(runningType.RunningNoDigit, '0');
                        string result = string.Format(runningType.RunningNoFormat
                            , Running.Parameter1
                            , Running.Parameter2
                            , Running.Parameter3
                            , Running.Parameter4
                            , Running.Parameter5
                            , Running.Parameter6
                            , Running.Parameter7
                            , Running.Parameter8
                            , Running.Parameter9
                            , Running.Parameter10
                            ).Replace("[RUNNING]", runningDigit);
                        Context.RuRunningNo.Update(Running);
                        Context.SaveChanges();
                        returnMessageDTO.Code = result;
                        returnMessageDTO.TypeCode = Running.RunningTypeCode;
                        returnMessageDTO.TypeName = runningType.Name;
                        returnMessageDTO.Digit = runningType.RunningNoDigit;
                        returnMessageDTO.Format = runningType.RunningNoFormat;
                        returnMessageDTO.CreatedDate = Running.UpdatedDate;
                    returnMessageDTO.Message = "RunningNo Created Success!!";
                        return returnMessageDTO;
                    //}
                    //else
                    //{
                    //    CreateRunningNo(runningType, parameter);
                    //    return returnMessageDTO;
                    //}
                }
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                returnMessageDTO.Message = e.Message;
                return returnMessageDTO;
                throw e;
            }
        }
    }
}
