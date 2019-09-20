using Database.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.API.Interface
{
    public interface AppInterface
    {
        List<Provinces> GetProvinces();
    }
}
