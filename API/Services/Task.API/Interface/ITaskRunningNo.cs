using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.DTOs;

namespace TaskManagement.Interface
{
    public interface ITaskRunningNo
    {
        Task<RunningNoDTO> GenerateRunningNo();
    }
}
