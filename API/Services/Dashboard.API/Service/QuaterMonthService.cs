using Dashboard.DTOs;
using Dashboard.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Service
{
    public class QuaterMonthService : IQuaterMonth
    {
        public List<QuaterMonthDTO> GetQuaterMonth()
        {
            List<QuaterMonthDTO> QuaterMonth = new List<QuaterMonthDTO>();
            QuaterMonthDTO QuaterMonth1 = new QuaterMonthDTO()
            {
                name = "January",
                quater = 1,
                pie = { 22, 3 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth1);
            QuaterMonthDTO QuaterMonth2 = new QuaterMonthDTO()
            {
                name = "February",
                quater = 1,
                pie = { 10, 7 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth2);
            QuaterMonthDTO QuaterMonth3 = new QuaterMonthDTO()
            {
                name = "March",
                quater = 1,
                pie = { 18, 4 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth3);
            QuaterMonthDTO QuaterMonth4 = new QuaterMonthDTO()
            {
                name = "April",
                quater = 2,
                pie = { 25, 3 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth4);
            QuaterMonthDTO QuaterMonth5 = new QuaterMonthDTO()
            {
                name = "May",
                quater = 2,
                pie = { 14, 3 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth5);
            QuaterMonthDTO QuaterMonth6 = new QuaterMonthDTO()
            {
                name = "June",
                quater = 2,
                pie = { 14, 8 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth6);
            QuaterMonthDTO QuaterMonth7 = new QuaterMonthDTO()
            {
                name = "July",
                quater = 3,
                pie = { 28, 3 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth7);
            QuaterMonthDTO QuaterMonth8 = new QuaterMonthDTO()
            {
                name = "August",
                quater = 3,
                pie = { 19, 3 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth8);
            QuaterMonthDTO QuaterMonth9 = new QuaterMonthDTO()
            {
                name = "September",
                quater = 3,
                pie = { 12, 10 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth9);
            QuaterMonthDTO QuaterMonth10 = new QuaterMonthDTO()
            {
                name = "October",
                quater = 4,
                pie = { 22, 3 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth10);
            QuaterMonthDTO QuaterMonth11 = new QuaterMonthDTO()
            {
                name = "November",
                quater = 4,
                pie = { 7, 9 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth11);
            QuaterMonthDTO QuaterMonth12 = new QuaterMonthDTO()
            {
                name = "December",
                quater = 4,
                pie = { 18, 4 },
                nameOfPie = { "Points Actual", "Points Available" }
            };
            QuaterMonth.Add(QuaterMonth12);

            return QuaterMonth;
        }
    }
}
