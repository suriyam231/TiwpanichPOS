using Dashboard.DTOs;
using Dashboard.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Service
{
    public class PieChartService : IPieChart
    {
        public List<PieChartDTO> GetPieCharts()
        {
            List<PieChartDTO> PieChart = new List<PieChartDTO>();
            PieChartDTO PieChart1 = new PieChartDTO()
            {
                name = "January",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = {20, 5},
                names = 1
            };
            PieChart.Add(PieChart1);
            PieChartDTO PieChart2 = new PieChartDTO()
            {
                name = "February",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 11, 6 },
                names = 1
            };
            PieChart.Add(PieChart2);
            PieChartDTO PieChart3 = new PieChartDTO()
            {
                name = "March",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 17, 3 },
                names = 1
            };
            PieChart.Add(PieChart3);
            PieChartDTO PieChart4 = new PieChartDTO()
            {
                name = "April",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = {18, 7 },
                names = 1
            };
            PieChart.Add(PieChart4);
            PieChartDTO PieChart5 = new PieChartDTO()
            {
                name = "May",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = {9, 8},
                names = 1
            };
            PieChart.Add(PieChart5);
            PieChartDTO PieChart6 = new PieChartDTO()
            {
                name = "June",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = {15, 5},
                names = 1
            };
            PieChart.Add(PieChart6);
            PieChartDTO PieChart7 = new PieChartDTO()
            {
                name = "July",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 18, 7 },
                names = 1
            };
            PieChart.Add(PieChart7);
            PieChartDTO PieChart8 = new PieChartDTO()
            {
                name = "August",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 9, 8 },
                names = 1
            };
            PieChart.Add(PieChart8);
            PieChartDTO PieChart9 = new PieChartDTO()
            {
                name = "September",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 15, 5 },
                names = 1
            };
            PieChart.Add(PieChart9);
            PieChartDTO PieChart10 = new PieChartDTO()
            {
                name = "October",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 22, 10 },
                names = 1
            };
            PieChart.Add(PieChart10);
            PieChartDTO PieChart11 = new PieChartDTO()
            {
                name = "November",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 12, 16 },
                names = 1
            };
            PieChart.Add(PieChart11);
            PieChartDTO PieChart12 = new PieChartDTO()
            {
                name = "December",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 14, 11 },
                names = 1
            };
            PieChart.Add(PieChart12);
            PieChartDTO PieChart13 = new PieChartDTO()
            {
            name = "January",
                quater = 1, 
            nameOfPie = { "Points Actual", "Points Available" },
                pie = { 16, 19 }, 
            names = 2
            };
            PieChart.Add(PieChart13);
            PieChartDTO PieChart14 = new PieChartDTO()
            {
                name = "February",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 29, 13 },
                names = 2
            };
            PieChart.Add(PieChart14);
            PieChartDTO PieChart15 = new PieChartDTO()
            {
                name = "March",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 28, 14 },
                names = 2
            };
            PieChart.Add(PieChart15);
            PieChartDTO PieChart16 = new PieChartDTO()
            {
                name = "April",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 36, 21 },
                names = 2
            };
            PieChart.Add(PieChart16);
            PieChartDTO PieChart17 = new PieChartDTO()
            {
                name = "May",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 18, 16 },
                names = 2
            };
            PieChart.Add(PieChart17);
            PieChartDTO PieChart18 = new PieChartDTO()
            {
                name = "June",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 26, 13 },
                names = 2
            };
            PieChart.Add(PieChart18);
            PieChartDTO PieChart19 = new PieChartDTO()
            {
                name = "July",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 30, 5 },
                names = 2
            };
            PieChart.Add(PieChart19);
            PieChartDTO PieChart20 = new PieChartDTO()
            {
                name = "August",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 25, 18 },
                names = 2
            };
            PieChart.Add(PieChart20);
            PieChartDTO PieChart21 = new PieChartDTO()
            {
                name = "September",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 30, 5 },
                names = 2
            };
            PieChart.Add(PieChart21);
            PieChartDTO PieChart22 = new PieChartDTO()
            {
                name = "October",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 45, 15 },
                names = 2
            };
            PieChart.Add(PieChart22);
            PieChartDTO PieChart23 = new PieChartDTO()
            {
                name = "November",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 32, 25 },
                names = 2
            };
            PieChart.Add(PieChart23);
            PieChartDTO PieChart24 = new PieChartDTO()
            {
                name = "December",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 47, 18 },
                names = 2
            };
            PieChart.Add(PieChart24);
            PieChartDTO PieChart25 = new PieChartDTO()
            {
                name = "January",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 30, 5 },
                names = 3
            };
            PieChart.Add(PieChart25);
            PieChartDTO PieChart26 = new PieChartDTO()
            {
                name = "February",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 42, 24 },
                names = 3
            };
            PieChart.Add(PieChart26);
            PieChartDTO PieChart27 = new PieChartDTO()
            {
                name = "March",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 38, 13 },
                names = 3
            };
            PieChart.Add(PieChart27);
            PieChartDTO PieChart28 = new PieChartDTO()
            {
                name = "April",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 16, 18 },
                names = 3
            };
            PieChart.Add(PieChart28);
            PieChartDTO PieChart29 = new PieChartDTO()
            {
                name = "May",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 25, 19 },
                names = 3
            };
            PieChart.Add(PieChart29);
            PieChartDTO PieChart30 = new PieChartDTO()
            {
                name = "June",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 30, 5 },
                names = 3
            };
            PieChart.Add(PieChart30);
            PieChartDTO PieChart31 = new PieChartDTO()
            {
                name = "July",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 26, 15 },
                names = 3
            };
            PieChart.Add(PieChart31);
            PieChartDTO PieChart32 = new PieChartDTO()
            {
                name = "August",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 26, 12 },
                names = 3
            };
            PieChart.Add(PieChart32);
            PieChartDTO PieChart33 = new PieChartDTO()
            {
                name = "September",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 36, 23 },
                names = 3
            };
            PieChart.Add(PieChart33);
            PieChartDTO PieChart34 = new PieChartDTO()
            {
                name = "October",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 28, 16 },
                names = 3
            };
            PieChart.Add(PieChart34);
            PieChartDTO PieChart35 = new PieChartDTO()
            {
                name = "November",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 34, 13 },
                names = 3
            };
            PieChart.Add(PieChart35);
            PieChartDTO PieChart36 = new PieChartDTO()
            {
                name = "December",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 32, 11 },
                names = 3
            };
            PieChart.Add(PieChart36);
            PieChartDTO PieChart37 = new PieChartDTO()
            {
                name = "January",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 44, 16 },
                names = 4
            };
            PieChart.Add(PieChart37);
            PieChartDTO PieChart38 = new PieChartDTO()
            {
                name = "February",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 28, 16 },
                names = 4
            };
            PieChart.Add(PieChart38);
            PieChartDTO PieChart39 = new PieChartDTO()
            {
                name = "March",
                quater = 1,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 31, 15 },
                names = 4
            };
            PieChart.Add(PieChart39);
            PieChartDTO PieChart40 = new PieChartDTO()
            {
                name = "April",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 42, 21 },
                names = 4
            };
            PieChart.Add(PieChart40);
            PieChartDTO PieChart41 = new PieChartDTO()
            {
                name = "May",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 33, 16 },
                names = 4
            };
            PieChart.Add(PieChart41);
            PieChartDTO PieChart42 = new PieChartDTO()
            {
                name = "June",
                quater = 2,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 26, 12 },
                names = 4
            };
            PieChart.Add(PieChart42);
            PieChartDTO PieChart43 = new PieChartDTO()
            {
                name = "July",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 36, 24 },
                names = 4
            };
            PieChart.Add(PieChart43);
            PieChartDTO PieChart44 = new PieChartDTO()
            {
                name = "August",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 24, 18 },
                names = 4
            };
            PieChart.Add(PieChart44);
            PieChartDTO PieChart45 = new PieChartDTO()
            {
                name = "September",
                quater = 3,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 32, 23 },
                names = 4
            };
            PieChart.Add(PieChart45);
            PieChartDTO PieChart46 = new PieChartDTO()
            {
                name = "October",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 27, 12 },
                names = 4
            };
            PieChart.Add(PieChart46);
            PieChartDTO PieChart47 = new PieChartDTO()
            {
                name = "November",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 16, 23 },
                names = 4
            };
            PieChart.Add(PieChart47);
            PieChartDTO PieChart48 = new PieChartDTO()
            {
                name = "December",
                quater = 4,
                nameOfPie = { "Points Actual", "Points Available" },
                pie = { 32, 15 },
                names = 4
            };
            PieChart.Add(PieChart48);

            return PieChart;
        }
    }
}
