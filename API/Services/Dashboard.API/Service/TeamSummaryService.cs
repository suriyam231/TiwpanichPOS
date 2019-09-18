using Dashboard.DTOs;
using Dashboard.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Service
{
    public class TeamSummaryService : TeamSummaryInterface
    {
        public List<TeamSummaryDTO> GetDataTeamSummary()
        {
            List<TeamSummaryDTO> TeamSummary = new List<TeamSummaryDTO>();
            TeamSummaryDTO TeamSummary1 = new TeamSummaryDTO()
            {
                PersonID = "Chinya",
                PointsActual = 52,
                PointsAvailable = 62,
                Quater = 1,
                Number = 1,
                CreateBy = "Smurf",
                CreateDate = DateTime.Now,
                UpdateBy = "Nuna",
                UpdateDate = DateTime.Now
            };
            TeamSummary.Add(TeamSummary1);
            TeamSummaryDTO TeamSummary2 = new TeamSummaryDTO()
            {
                PersonID = "Top",
                PointsActual = 48,
                PointsAvailable = 82,
                Quater = 1,
                Number = 2,
                CreateBy = "Nuna",
                CreateDate = DateTime.Now,
                UpdateBy = "Smurf",
                UpdateDate = DateTime.Now
            };
            TeamSummary.Add(TeamSummary2);
            TeamSummaryDTO TeamSummary3 = new TeamSummaryDTO()
            {
                PersonID = "Nuna",
                PointsActual = 35,
                PointsAvailable = 75,
                Quater = 1,
                Number = 3,
                CreateBy = "Top",
                CreateDate = DateTime.Now,
                UpdateBy = "Chinya",
                UpdateDate = DateTime.Now
            };
            TeamSummary.Add(TeamSummary3);
            TeamSummaryDTO TeamSummary4 = new TeamSummaryDTO()
            {
                PersonID = "Smurf",
                PointsActual = 26,
                PointsAvailable = 65,
                Quater = 1,
                Number = 4,
                CreateBy = "Nuna",
                CreateDate = DateTime.Now,
                UpdateBy = "Top",
                UpdateDate = DateTime.Now
            };
            TeamSummary.Add(TeamSummary4);
            TeamSummaryDTO TeamSummary5 = new TeamSummaryDTO()
            {
                PersonID = "Chinya",
                PointsActual = 26,
                PointsAvailable = 65,
                Quater = 2,
                Number = 1,
                CreateBy = "Nuna",
                CreateDate = DateTime.Now,
                UpdateBy = "Top",
                UpdateDate = DateTime.Now
            };
            TeamSummary.Add(TeamSummary5);
            TeamSummaryDTO TeamSummary6 = new TeamSummaryDTO()
            {
                PersonID = "Smurf",
                PointsActual = 26,
                PointsAvailable = 65,
                Quater = 2,
                Number = 2,
                CreateBy = "Nuna",
                CreateDate = DateTime.Now,
                UpdateBy = "Top",
                UpdateDate = DateTime.Now
            };
            TeamSummary.Add(TeamSummary6);
            TeamSummaryDTO TeamSummary7 = new TeamSummaryDTO()
            {
                PersonID = "Smurf",
                PointsActual = 26,
                PointsAvailable = 65,
                Quater = 3,
                Number = 4,
                CreateBy = "Nuna",
                CreateDate = DateTime.Now,
                UpdateBy = "Top",
                UpdateDate = DateTime.Now
            };
            TeamSummary.Add(TeamSummary7);
            TeamSummaryDTO TeamSummary8 = new TeamSummaryDTO()
            {
                PersonID = "Nuna",
                PointsActual = 26,
                PointsAvailable = 65,
                Quater = 3,
                Number = 3,
                CreateBy = "Smurf",
                CreateDate = DateTime.Now,
                UpdateBy = "Top",
                UpdateDate = DateTime.Now
            };
            TeamSummary.Add(TeamSummary8);
            TeamSummaryDTO TeamSummary9 = new TeamSummaryDTO()
            {
                PersonID = "Chinya",
                PointsActual = 26,
                PointsAvailable = 65,
                Quater = 4,
                Number = 1,
                CreateBy = "Nuna",
                CreateDate = DateTime.Now,
                UpdateBy = "Top",
                UpdateDate = DateTime.Now
            };
            TeamSummary.Add(TeamSummary9);
            TeamSummaryDTO TeamSummary10 = new TeamSummaryDTO()
            {
                PersonID = "Nuna",
                PointsActual = 26,
                PointsAvailable = 65,
                Quater = 4,
                Number = 3,
                CreateBy = "Chinya",
                CreateDate = DateTime.Now,
                UpdateBy = "Top",
                UpdateDate = DateTime.Now
            };
            TeamSummary.Add(TeamSummary10);

            return TeamSummary;
        }

    }
}
