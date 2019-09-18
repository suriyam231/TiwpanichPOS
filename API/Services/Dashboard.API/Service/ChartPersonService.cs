using Dashboard.DTOs;
using Dashboard.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Service
{
    public class ChartPersonService : IChartPerson
    {
        public List<ChartPersonDTO> GetChartPerson()
        {
            List<ChartPersonDTO> ChartPerson = new List<ChartPersonDTO>();
            ChartPersonDTO ChartPerson1 = new ChartPersonDTO()
            {
                name = "Chinya",
                quater = 1,
                pie = { 50, 14 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 1
            };
            ChartPerson.Add(ChartPerson1);
            ChartPersonDTO ChartPerson2 = new ChartPersonDTO()
            {
                name = "Top",
                quater = 1,
                pie = { 48, 16 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 2
            };
            ChartPerson.Add(ChartPerson2);
            ChartPersonDTO ChartPerson3 = new ChartPersonDTO()
            {
                name = "Nuna",
                quater = 1,
                pie = { 51, 14 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 3
            }; ChartPerson.Add(ChartPerson3);
            ChartPersonDTO ChartPerson4 = new ChartPersonDTO()
            {
                name = "Smurf",
                quater = 1,
                pie = { 49, 16 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 4
            };
            ChartPerson.Add(ChartPerson4);
            ChartPersonDTO ChartPerson5 = new ChartPersonDTO()
            {
                name = "Chinya",
                quater = 2,
                pie = { 55, 23 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 1
            };
            ChartPerson.Add(ChartPerson5);
            ChartPersonDTO ChartPerson6 = new ChartPersonDTO()
            {
                name = "Top",
                quater = 2,
                pie = { 49, 15 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 2
            };
            ChartPerson.Add(ChartPerson6);
            ChartPersonDTO ChartPerson7 = new ChartPersonDTO()
            {
                name = "Nuna",
                quater = 2,
                pie = { 50, 14 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 3
            };
            ChartPerson.Add(ChartPerson7);
            ChartPersonDTO ChartPerson8 = new ChartPersonDTO()
            {
                name = "Smurf",
                quater = 2,
                pie = { 51, 13 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 4
            };
            ChartPerson.Add(ChartPerson8);
            ChartPersonDTO ChartPerson9 = new ChartPersonDTO()
            {
                name = "Chinya",
                quater = 3,
                pie = { 48, 16 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 1
            };
            ChartPerson.Add(ChartPerson9);
            ChartPersonDTO ChartPerson10 = new ChartPersonDTO()
            {
                name = "Top",
                quater = 3,
                pie = { 52, 12 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 2
            };
            ChartPerson.Add(ChartPerson10);
            ChartPersonDTO ChartPerson11 = new ChartPersonDTO()
            {
                name = "Nuna",
                quater = 3,
                pie = { 54, 10 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 3
            };
            ChartPerson.Add(ChartPerson11);
            ChartPersonDTO ChartPerson12 = new ChartPersonDTO()
            {
                name = "Smurf",
                quater = 3,
                pie = { 50, 14 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 4
            };
            ChartPerson.Add(ChartPerson12);
            ChartPersonDTO ChartPerson13 = new ChartPersonDTO()
            {
                name = "Chinya",
                quater = 4,
                pie = { 55, 9 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 1
            };
            ChartPerson.Add(ChartPerson13);
            ChartPersonDTO ChartPerson14 = new ChartPersonDTO()
            {
                name = "Top",
                quater = 4,
                pie = { 51, 13 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 2
            };
            ChartPerson.Add(ChartPerson14);
            ChartPersonDTO ChartPerson15 = new ChartPersonDTO()
            {
                name = "Nuna",
                quater = 4,
                pie = { 49, 15 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 3
            };
            ChartPerson.Add(ChartPerson15);
            ChartPersonDTO ChartPerson16 = new ChartPersonDTO()
            {
                name = "Smurf",
                quater = 4,
                pie = { 52, 12 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 4
            };
            ChartPerson.Add(ChartPerson16);
            ChartPersonDTO ChartPerson17 = new ChartPersonDTO()
            {
                name = "AA",
                quater = 4,
                pie = { 52, 12 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 5
            };
            ChartPerson.Add(ChartPerson17);
            ChartPersonDTO ChartPerson18 = new ChartPersonDTO()
            {
                name = "BB",
                quater = 4,
                pie = { 50, 18 },
                nameOfPie = { "Points Actual", "Points Available" },
                names = 6
            };
            ChartPerson.Add(ChartPerson18);
            return ChartPerson;
        }
    }
}
