using Dashboard.DTOs;
using Dashboard.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Service
{
    public class QuaterService : IQuater

    {
        public List<QuaterDTO> GetQuater()
        {
            List<QuaterDTO> Quater = new List<QuaterDTO>();
            QuaterDTO Quater1 = new QuaterDTO()
            {
                name = "Q1",
                quater = 1,
                pie = { 54, 10 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            Quater.Add(Quater1);
            QuaterDTO Quater2 = new QuaterDTO()
            {
                name = "Q2",
                quater = 2,
                pie = { 52, 12 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            Quater.Add(Quater2);
            QuaterDTO Quater3 = new QuaterDTO()
            {
                name = "Q3",
                quater = 3,
                pie = { 55, 9 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            Quater.Add(Quater3);
            QuaterDTO Quater4 = new QuaterDTO()
            {
                name = "Q4",
                quater = 4,
                pie = { 58, 6 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            Quater.Add(Quater4);

            return Quater;
        }
    }
}
