using Listapplicant.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Listapplicant.Interface
{
    public interface IListapplicant
    {
        List<ListapplicantDTO> GetListapplicants();
    }
}
