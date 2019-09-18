using ApplicantExamAnswer.API.Interface;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApplicantExamAnswer.API.Service
{
    public class ApplicantExamAnswerHistoryService : ApplicantExamAnswerHistoryInterface
    {
        private readonly SRM_DEVContext Context;
        public ApplicantExamAnswerHistoryService(SRM_DEVContext context)
        {
            Context = context;
        }

        public string AddSubmitAnswer(ApplicantExamAnswerHistoryDTO[] questions, int Empid)
        {
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    int Seq = 0;
                    foreach (ApplicantExamAnswerHistoryDTO AppExam in questions)
                    {
                        ApplicantExamAnswerHistory examAnswer = new ApplicantExamAnswerHistory();
                        Seq++;
                        examAnswer.Seq = Seq;
                        examAnswer.Empid = Empid;
                        examAnswer.ExamType = AppExam.ExamType;
                        examAnswer.Question = AppExam.Question;
                        examAnswer.QuestionImage = AppExam.QuestionImage;
                        examAnswer.QuestionType = AppExam.QuestionType;
                        examAnswer.ChoiceType = AppExam.ChoiceType;
                        examAnswer.Choice1 = AppExam.Choice1;
                        examAnswer.Choice2 = AppExam.Choice2;
                        examAnswer.Choice3 = AppExam.Choice3;
                        examAnswer.Choice4 = AppExam.Choice4;
                        examAnswer.Choice5 = AppExam.Choice5;
                        examAnswer.Choice6 = AppExam.Choice6;
                        examAnswer.ApplicantAnswer = AppExam.ApplicantAnswer;
                        examAnswer.CorrectAnswer = AppExam.CorrectAnswer;
                        examAnswer.CrBy = AppExam.CrBy;
                        examAnswer.CrDate = DateTime.Now;
                        examAnswer.UdBy = AppExam.UdBy;
                        examAnswer.UdDate = AppExam.UdDate;
                        Context.ApplicantExamAnswerHistory.Add(examAnswer);
                    }
                    Context.SaveChanges();
                    dbContextTransaction.Commit();
                    return "success";
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return "error";
                }
            }
        }

        public List<ApplicantExamAnswerHistory> getExamtype(int empId)
        {
            List<ApplicantExamAnswerHistory> result = (from Examtype in Context.ApplicantExamAnswerHistory
                                                       where Examtype.Empid == empId
                                                       group Examtype by Examtype.ExamType into data
                                                       select new ApplicantExamAnswerHistory
                                                       {
                                                           ExamType = data.Key,
                                                        

                                                       }).ToList();
            return result;
        }

        public object GetAnswerAppliont(int empId)
        {
            var examAnswer = (from AppExam in Context.ApplicantExamAnswerHistory
                              where AppExam.Empid == empId
                              select new
                              {
                                  Empid = AppExam.Empid,
                                  ExamType = AppExam.ExamType,
                                  Question = AppExam.Question,
                                  QuestionImage = AppExam.QuestionImage,
                                  QuestionType = AppExam.QuestionType,
                                  ChoiceType = AppExam.ChoiceType,
                                  Choice1 = AppExam.Choice1,
                                  Choice2 = AppExam.Choice2,
                                  Choice3 = AppExam.Choice3,
                                  Choice4 = AppExam.Choice4,
                                  Choice5 = AppExam.Choice5,
                                  Choice6 = AppExam.Choice6,
                                  ApplicantAnswer = AppExam.ApplicantAnswer,
                                  CorrectAnswer = AppExam.CorrectAnswer,
                                  CrDate = AppExam.CrDate,

                              }).ToList();
            return examAnswer;
        }
    }
}
