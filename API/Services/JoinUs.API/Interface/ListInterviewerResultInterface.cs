using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System.Collections.Generic;

namespace ListInterviewerResult.API.Interface
{
    public interface IListInterviewerResultInterface
    {

        List<ApplicantProfile> GetAssessment(); //get

        ApplicantAssessmentDTO GetDataAssessmentByID(int empID);

        List<ApplicantProfile> GetDataSearchListInterviewerResult(string name,string position,string type); // get 
    }
}
