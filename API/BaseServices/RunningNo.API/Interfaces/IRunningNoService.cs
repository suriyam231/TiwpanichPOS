using RunningNo.API.DTOs;
using RunningNo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningNo.API.Interfaces
{
    public interface IRunningNoService
    {
        ReturnMessageDTO GenerateRunningNo(string runningCode, params string[] parameter);
        RuRunningNo CreateRunningNo(RuRunningType runningType, params string[] parameter);
        RuRunningNo CheckParameter (int Count, string runningCode, params string[] parameter);
    }
}
