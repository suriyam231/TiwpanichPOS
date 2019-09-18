using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListApplicant.API.Interface
{
    public interface ListApplicantsInterface
    {
        List<ApplicantProfile> GetDataProfileByPM(string position);//get
        List<ApplicantProfile> GetDataProfileByPM(string name, string date,string type,string department); // get data profile by name and date.
        Task<string> SaveinterviewDate(ApplicantAppointmentDateDTO data, string team); //post
        List<ApplicantProfile> GetHistoryListApplicant(string role,string department, string team);//get
        List<ApplicantProfile> searchHistoryList(string role, string department, string team, string type, string name, string status,string date,string searchPosition);
    }
}
