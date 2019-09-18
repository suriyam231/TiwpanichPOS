using DashboardHr.API.Interface;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardHr.API.Service
{
    public class DashboardHrService : DashboardHrInterface
    {
        private readonly SRM_DEVContext Context;
        private object ctx;

        public DashboardHrService(SRM_DEVContext context)
        {
            Context = context;
        }

        public List<GraphDTO> GetDataGraph()
        {
            List<GraphDTO> total = new List<GraphDTO>();
            DateTime year = DateTime.Now;

            for (int month = 1; month <= 12; month++)
            {
                total.AddRange(from item in Context.ApplicantProfile
                               where Convert.ToDateTime(item.CrDate).Month.Equals(month) && Convert.ToDateTime(item.CrDate).Year.Equals(year.Year)
                               group item by Convert.ToDateTime(item.CrDate).Month into a
                               select new GraphDTO
                               {
                                   Month = month.ToString(),
                                   TotalApplicant = a.Count(),
                                   TotalPass = a.Where(b => b.StatusApplicant == "Interview_P").Count(),
                                   TotalNotPass = a.Where(b => b.StatusApplicant == "NPass_HR" && b.StatusApplicant == "NPass_PM").Count(),
                               });
            }

            return total;

        }

        public SummaryDashboardDTO GetSummaryDashboard()
        {
            SummaryDashboardDTO getSummary = new SummaryDashboardDTO();

            var grouped = Context.ApplicantProfile.GroupBy(i => i.StatusApplicant).Select(i => new { Word = i.Key, Count = i.Count() });

            foreach (var item in grouped)
            {
                if (item.Word == "New") // ผู้สมัครใหม่
                {
                    getSummary.Total_NewApplicant = item.Count;
                }
                if (item.Word == "Contact_Cnot" || item.Word == "Pass_PM") //ยังไม่ได้ติดต่อ
                {
                    getSummary.Total_WaitContact += item.Count;
                }
                if (item.Word == "Contact_Inte") //รอผลสัมภาษณ์
                {
                    getSummary.Total_WaitInterviewResult = item.Count;
                }
                if (item.Word == "Agreemented" || item.Word == "Interview_C" || item.Word == "Interview_N") //รอการแจ้งผล
                {
                    getSummary.Total_WaitResult += item.Count;
                }
            }

            return getSummary;
        }

        public SummaryDashboardDTO GetSummaryDashboardPM(string team, string Deartment)
        {
            SummaryDashboardDTO getSummary = new SummaryDashboardDTO();

            var countNewByDepartment = Context.ApplicantProfile.Where(x => x.Position == Deartment).GroupBy(i => i.StatusApplicant).Select(i => new { Word = i.Key, Count = i.Count() });
            foreach (var item in countNewByDepartment)
            {
                if (item.Word == "Pass_HR") // ผู้สมัครใหม่
                {
                    getSummary.Total_NewApplicantPM = item.Count;
                }
            }

            var grouped = Context.ApplicantProfile.Where(x => x.Team == team).GroupBy(i => i.StatusApplicant).Select(i => new { Word = i.Key, Count = i.Count() });

            foreach (var item in grouped)
            {
                if (item.Word == "Contact_Inte") //รอประเมิณการสัมภาษณ์
                {
                    getSummary.Total_waitInterview += item.Count;
                }
                if (item.Word == "Interview_P") //รอกำหนดข้อตกลง
                {
                    getSummary.Total_WaitaAgreement = item.Count;
                }
            }

            return getSummary;
        }

        public List<SummaryDashboardTableDTO> GetSummaryDashboardTable()
        {
            List<SummaryDashboardTableDTO> total = new List<SummaryDashboardTableDTO>();
            total.AddRange(from listofvalue in Context.ListOfValue
                           join applicantProfile in Context.ApplicantProfile on listofvalue.Value equals applicantProfile.Position into data
                           where listofvalue.GroupCode == "POS"
                           select new SummaryDashboardTableDTO
                           {
                               position = listofvalue.Value,
                               total_applicant = data.Count(),
                               total_pass = data.Where(x => x.StatusApplicant == "Agreemented").Count(),
                               total_fails = data.Where(
                                                        x => x.StatusApplicant == "Interview_N" ||
                                                        x.StatusApplicant == "Contact_Nint" ||
                                                        x.StatusApplicant == "Contact_Cnot" ||
                                                        x.StatusApplicant == "NPass_PM" ||
                                                        x.StatusApplicant == "Interview_N").Count(),
                           });
            return total;
        }
    }
}
