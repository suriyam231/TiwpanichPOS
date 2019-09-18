using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.API.Interface
{
    public interface AgreementInterface
    {
        List<ApplicantInterviewerDTO> GetDatatoAgreement(string team);//get
        string AddDatatoAgreement(ApplicantAgreement data);
        List<ApplicantProfile> GetDataBySearch(string name, string date, string team,string type);
        ApplicantAgreement GetDatatoAgreementByEmpId(int empID);
    }

}
