using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System.Collections.Generic;

namespace ListInteresting.API.Interface
{
    public interface ListInterestingInterface
    {
        List<ApplicantInterestingsDTO> getDataIntertings();//get
        List<ApplicantInterestingsDTO> getDataIntertingsss();//get
        string UpdateStatusInteresting(int[] id, string status);
        List<ApplicantInterestingsDTO> GetDataListinteresting(string name, string date, string status,string type); // get data profile by name and date.
        string UpdateAppointmentDate(List<UpdateApplicantInterestingsDTO> updatedata);

    }
}
