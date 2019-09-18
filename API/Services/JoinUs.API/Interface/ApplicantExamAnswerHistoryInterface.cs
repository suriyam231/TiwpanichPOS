using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantExamAnswer.API.Interface
{
    public interface ApplicantExamAnswerHistoryInterface
    {
        string AddSubmitAnswer(ApplicantExamAnswerHistoryDTO[] questions, int Empid);
        List<ApplicantExamAnswerHistory> getExamtype(int empId);
        object GetAnswerAppliont(int empId);


    }
}
