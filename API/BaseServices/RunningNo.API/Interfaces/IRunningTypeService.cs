using RunningNo.API.DTOs;
using RunningNo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningNo.API.Interfaces
{
    public interface IRunningTypeService
    {
        RuRunningType GetRunningType(string RunningTypeCode);
        string CreateRunningType(RuRunningType RunningType);

    }
}
