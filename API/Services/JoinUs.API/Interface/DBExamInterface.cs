using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Interface
{
    public interface DBExamInterface
    {
        List<ApplicantProfile> GetDataCheckIdCard(string IdCard);
        List<DbExam> GetDataQuestion();
        List<DbExam> getGroupby();
        object getExamType();
        List<DbDepartmentGroup> getDepartmentName();

        List<DbExam> getallQuestion();

        List<DbExamType> getallExamtype();
        List<DbExam> getallQuestiontype();
        string addQuestionvalues(DbExam value);
        string editQuestionvalues(DbExam value);
        string deleteQuetionvalues(string examType, string questionType ,string question);

        ArrayList getTable();

        string addExamGroupDepartmentGroup(DbExamType value);

        string editExamGroup(DbExamTypeDTO value);


        List<DbDepartmentGroup> getDepartmentGroup();

        List<DbExamType> getExamTypeName();

        string addExamDepartmentGroup(List<string> value);

        string editExamGroupDepartmentGroup(List<string> value);






    }
}
