using System.Collections.Generic;
using System.Threading.Tasks;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;

namespace AssessmentByPM.API.Interface
{
    public interface AssessmentInterface
    {
        List<ApplicantInterviewerDTO> GetDataAssessmenByPM(string team);//get

        ApplicantAssessmentDTO GetDataAssessmentPmByID(int empID); //get

        List<ApplicantInterviewerDTO> GetDataAssessmentByPM(string name, string date, string team,string type); // get data profile by name and date.

        Task<string> SaveAssessmentOnline(ApplicantAssessmentDTO data,string name); //post

        string UpdateStatus(int id, string status,string name);  //updateStatus
    }
}
