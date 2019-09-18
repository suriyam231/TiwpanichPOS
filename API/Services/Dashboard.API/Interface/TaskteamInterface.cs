using Dashboard.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Interface
{
    public interface TaskteamInterface
    {
        List<TaskteamDTO> GetDataTaskteam();
    }
}