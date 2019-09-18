using Listapplicant.DTOs;
using Listapplicant.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Listapplicant.Service
{
    public class ListapplicantService  : IListapplicant
    {
        public List<ListapplicantDTO> GetListapplicants()
        {
            List<ListapplicantDTO> DataList = new List<ListapplicantDTO>();
            ListapplicantDTO DataList1 = new ListapplicantDTO()
            {
                Name = "Sunaree",
                Lastname = "Saeker",
                Telephone = "0845768093",
                Position = "Software Developer"
            };
            DataList.Add(DataList1);
            ListapplicantDTO DataList2 = new ListapplicantDTO()
            {
                Name = "Varunee",
                Lastname = "kmonpranee",
                Telephone = "1234567890",
                Position = "Software Developer"
            };
            DataList.Add(DataList2);
            return DataList;
        }
    }
}
