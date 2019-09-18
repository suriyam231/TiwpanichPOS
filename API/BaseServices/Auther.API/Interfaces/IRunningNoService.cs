using Auther.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.Interfaces
{
    public interface IRunningNoService
    {
         Task<RunningNoDTO> GenerateRunningNo();
    }
}
