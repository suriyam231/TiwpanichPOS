using Database.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.API.Interface
{
    public interface PageInterface
    {
        List<Provinces> GetProvinces();
        List<Districts> GetDistricts(string District);
        List<Subdistricts> GetSubdistricts(string Subdistricts);
    }
}
