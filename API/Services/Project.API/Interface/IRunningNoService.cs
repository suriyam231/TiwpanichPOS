using ProjectManagementService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementService.Interface
{
    public interface IRunningNoService
    {
        Task<RunningNoDTO> GenerateRunningNo(string param);
    }
}
