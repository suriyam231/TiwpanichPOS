using Database.API.Interface;
using Database.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.API.Service
{
    public class AppService : AppInterface
    {
        private readonly SRM_DEVContext Context;
        public AppService(SRM_DEVContext context)
        {
            Context = context;
        }

        public List<Provinces> GetProvinces()
        {
            List<Provinces> res = (from data in Context.Provinces
                                   select new Provinces
                                   {
                                       NameInThai = data.NameInThai,
                                       Id = data.Id
                                   }).ToList();
            return res;
        }


    }
}
