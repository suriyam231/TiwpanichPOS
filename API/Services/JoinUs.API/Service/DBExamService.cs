using Exam.API.Interface;
using Microsoft.AspNetCore.Mvc;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Service
{
    public class DBExamService : DBExamInterface
    {
        private readonly SRM_DEVContext Context;
        public DBExamService(SRM_DEVContext context)
        {
            Context = context;
        }

        public List<DbExam> getallQuestion()
        {
            var result = (from Exam in Context.DbExam
                          select new DbExam
                          {
                              ExamType = Exam.ExamType,
                              Seq = Exam.Seq,
                              Question = Exam.Question,
                              QuestionType = Exam.QuestionType,
                              QuestionImage = Exam.QuestionImage,
                              CorrectAnswer = Exam.CorrectAnswer,
                              ChoiceType = Exam.ChoiceType,
                              Choice1 = Exam.Choice1,
                              Choice2 = Exam.Choice2,
                              Choice3 = Exam.Choice3,
                              Choice4 = Exam.Choice4,
                              Choice5 = Exam.Choice5,
                              Choice6 = Exam.Choice6,
                              Active = Exam.Active




                          }).ToList();

            return result;
        }

        public List<DbExamType> getallExamtype()
        {
            List<DbExamType> result = (from Exam in Context.DbExamType
                                       select new DbExamType
                                       {
                                           ExamType = Exam.ExamType,
                                           Active = Exam.Active
                                       }).ToList();
                                   
            return result;
        }
        public List<DbExam> getallQuestiontype()
        {
            List<DbExam> result = (from Exam in Context.DbExam
                                   group Exam by Exam.QuestionType into data
                                   select new DbExam
                                   {
                                       QuestionType = data.Key
                                   }).ToList();
            return result;

        }

        public string addQuestionvalues(DbExam value)
        {

            DbExam data = new DbExam();
            int Seq;

            try
            {
                Seq = Context.DbExam.Where(i => i.ExamType == value.ExamType).Max(i => i.Seq) + 1;
            }
            catch {

                Seq = 1;
            }

            data.Seq = Seq;
            data.ExamType = value.ExamType;
            data.QuestionType = value.QuestionType;
            data.Question = value.Question;
            data.QuestionImage = value.QuestionImage;
            data.CorrectAnswer = value.CorrectAnswer;
            data.ChoiceType = value.ChoiceType;
            data.Choice1 = value.Choice1;
            data.Choice2 = value.Choice2;
            data.Choice3 = value.Choice3;
            data.Choice4 = value.Choice4;
            data.Choice5 = value.Choice5;
            data.Choice6 = value.Choice6;
            data.Active = value.Active;

            Context.DbExam.Add(data);

            Context.SaveChanges();

            return "success";
        }

        public string editQuestionvalues(DbExam value)
        {


            DbExam editQuestion = Context.DbExam.Where(x => x.ExamType == value.ExamType && x.Seq == value.Seq).FirstOrDefault();
            editQuestion.ExamType = value.ExamType;
            editQuestion.QuestionType = value.QuestionType;
            editQuestion.Question = value.Question;
            editQuestion.QuestionImage = value.QuestionImage;
            editQuestion.CorrectAnswer = value.CorrectAnswer;
            editQuestion.ChoiceType = value.ChoiceType;
            editQuestion.Choice1 = value.Choice1;
            editQuestion.Choice2 = value.Choice2;
            editQuestion.Choice3 = value.Choice3;
            editQuestion.Choice4 = value.Choice4;
            editQuestion.Choice5 = value.Choice5;
            editQuestion.Choice6 = value.Choice6;
            editQuestion.Active = value.Active;

            Context.DbExam.Update(editQuestion);
            Context.SaveChanges();

            return "success";

        }

        
        public string deleteQuetionvalues(string examType, string questionType, string question)
        {
            DbExam data = new DbExam();
            data = Context.DbExam.Where(x => x.ExamType == examType && x.QuestionType == questionType && x.Question == question).FirstOrDefault();



            Context.DbExam.Remove(data);
            Context.SaveChanges();

            return "success";
        }


        public List<ApplicantProfile> GetDataCheckIdCard(string IdCard)
        {
            List<ApplicantProfile> result;

            if (!string.IsNullOrWhiteSpace(IdCard))
            {
                result = Context.ApplicantProfile.Where(x => IdCard == x.IdCard).ToList();
            }
            else
            {
                result = Context.ApplicantProfile.Where(x => IdCard == "NULL").ToList();
            }

            return result;
        }

        public List<DbExam> getGroupby()
        {
            List<DbExam> result = (from Exam in Context.DbExam
                                   group Exam by Exam.ExamType into data
                                   select new DbExam
                                   {
                                       ExamType = data.Key
                                   }).ToList();

            return result;
        }
        public List<DbExam> GetDataQuestion()
        {
            List<DbExam> Qusetion = (from data in Context.DbExam
                                     select new DbExam
                                     {
                                         ExamType = data.ExamType,
                                         Question = data.Question,
                                         QuestionImage = data.QuestionImage,
                                         QuestionType = data.QuestionType,
                                         ChoiceType = data.ChoiceType,
                                         Choice1 = data.Choice1,
                                         Choice2 = data.Choice2,
                                         Choice3 = data.Choice3,
                                         Choice4 = data.Choice4,
                                         Choice5 = data.Choice5,
                                         Choice6 = data.Choice6,
          
                                         CorrectAnswer = data.CorrectAnswer


                                     }).ToList();

            List<DbExam> qusetionRandom = new List<DbExam>();
            
            Random random = new Random();
            List<int> randomNumbers = Enumerable.Range(0, Qusetion.Count).OrderBy(x => random.Next()).Take(Qusetion.Count).ToList();

            foreach (int value in randomNumbers)
            {
                List<string> ChoiceStak = new List<string>();
                ChoiceStak.Add(Qusetion[value].Choice1);
                ChoiceStak.Add(Qusetion[value].Choice2);
                ChoiceStak.Add(Qusetion[value].Choice3);
                ChoiceStak.Add(Qusetion[value].Choice4);
                if(Qusetion[value].Choice5  != null)
                {
                    ChoiceStak.Add(Qusetion[value].Choice5);
                }
                if (Qusetion[value].Choice6 != null)
                {
                    ChoiceStak.Add(Qusetion[value].Choice6);
                }

                List<int> randomChoice = Enumerable.Range(0, ChoiceStak.Count).OrderBy(x => random.Next()).Take(ChoiceStak.Count).ToList();
                int i = 0;
                foreach (int data in randomChoice)
                {
                    
                    if( i == 0)
                    {
                        Qusetion[value].Choice1 = ChoiceStak[data];
                        i++;
                    }else if( i == 1)
                    {
                        Qusetion[value].Choice2 = ChoiceStak[data];
                        i++;
                    }
                    else if (i == 2)
                    {
                        Qusetion[value].Choice3 = ChoiceStak[data];
                        i++;
                    }
                    else if (i == 3)
                    {
                        Qusetion[value].Choice4 = ChoiceStak[data];
                        i++;
                    }
                    else if (i == 4)
                    {
                        Qusetion[value].Choice5 = ChoiceStak[data];
                        i++;
                    }
                    else if (i == 5)
                    {
                        Qusetion[value].Choice6 = ChoiceStak[data];
                        i++;
                    }


                }
                qusetionRandom.Add(Qusetion[value]);
            }

            return qusetionRandom;
        }


        public object getExamType()
        {
            var ExamType = (from data1 in Context.DbExamDepartmentGroup 
                            join data2 in Context.DbExamType on data1.ExamType equals data2.ExamType
                            orderby data2.ExamTypeSort

                            select new
                            {
                                ExamType = data1.ExamType,
                                DepartmentGroup = data1.DepartmentGroup,
                                ExamTypeName = data2.ExamTypeName,
                                ExamTypeSort = data2.ExamTypeSort

                            }).ToList();
            return ExamType;
        }

        public List<DbDepartmentGroup> getDepartmentName()
        {
            List<DbDepartmentGroup> Name = (from data in Context.DbDepartmentGroup
                                            select new DbDepartmentGroup
                                            {
                                                DepartmentGroup = data.DepartmentGroup,
                                                DepartmentName = data.DepartmentName,
                                            }).ToList();
            return Name;
        }

        public ArrayList getTable()
        {
            ArrayList dataList = new ArrayList();

            List<DbExamType> dbExamType = Context.DbExamType.Select(i => i).Where(w => w.Active == "Y").OrderBy(o => o.ExamTypeSort).ToList();
            List<DbExamDepartmentGroup> dbExamDepartmentGroupAll = Context.DbExamDepartmentGroup.Select(i => i).ToList();
            List<DbExamDepartmentGroup> dbExamDepartmentGroup = (from a in Context.DbExamDepartmentGroup
                                                         
                                                                 group a by a.DepartmentName into b
                                                                 select new DbExamDepartmentGroup
                                                                 {
                                                                     DepartmentName = b.Key,
                                                                     ExamType = b.Select(i => i.ExamType).FirstOrDefault()
                                                                 }).ToList();

            string[] column = new string[dbExamType.Count];

            for (int i = 0; i < dbExamType.Count; i++)
            {
                column[i] = dbExamType[i].ExamTypeName;
            }

            dataList.Add(column);
            ArrayList dataArray;

            for (int i = 0; i < dbExamDepartmentGroup.Count; i++)
            {
                dataArray = new ArrayList();
                dataArray.Add(dbExamDepartmentGroup[i].DepartmentName.ToString());

                for (int j = 0; j < dbExamType.Count; j++)
                {
                    List<DbExamDepartmentGroup> result = dbExamDepartmentGroupAll.Where(a => a.ExamType == dbExamType[j].ExamType && a.DepartmentName == dbExamDepartmentGroup[i].DepartmentName).Select(b => b).ToList();
                    dataArray.Add(result.Count > 0 ? true : false);
                }

                dataList.Add(dataArray);
            }

            return dataList;
        }

        public string addExamGroupDepartmentGroup(DbExamType value)

        {
            DbExamType data = new DbExamType();
            data.ExamType = value.ExamType;
            data.ExamTypeName = value.ExamTypeName;
            data.ExamTypeSort = value.ExamTypeSort;
            data.Active = value.Active;
           
           

            Context.DbExamType.Add(data);
            Context.SaveChanges();
            return "success"; 

        }

        public string editExamGroup(DbExamTypeDTO value)

        {
            DbExamType data = Context.DbExamType.Where(x => x.ExamTypeName == value.ExamTypecolumn).FirstOrDefault();
           
            data.ExamTypeName = value.ExamTypeName;
            data.ExamTypeSort = value.ExamTypeSort;
            data.Active = value.Active;
            data.UpdDate = DateTime.Now;



            Context.DbExamType.Update(data);
            Context.SaveChanges();
            return "success";

        }


        public List<DbDepartmentGroup> getDepartmentGroup()
        {
            List<DbDepartmentGroup> result = (from Department in Context.DbDepartmentGroup
                                              select new DbDepartmentGroup
                                              {
                                                  DepartmentGroup = Department.DepartmentGroup,
                                                  DepartmentName = Department.DepartmentName
                                              }).ToList();
            return result;

        }

        public List<DbExamType> getExamTypeName()
        {
            List<DbExamType> result = (from ExamType in Context.DbExamType
                                       orderby ExamType.ExamTypeSort
                                       select new DbExamType
                                       {
                                           ExamType = ExamType.ExamType,
                                           ExamTypeName = ExamType.ExamTypeName,
                                           ExamTypeSort = ExamType.ExamTypeSort,
                                           Active = ExamType.Active
                                       }).ToList();

            return result;
                
        }

        public string addExamDepartmentGroup(List<string> value)
        {

            DbExamDepartmentGroup data = new DbExamDepartmentGroup();
            DbDepartmentGroup departmentGroup = Context.DbDepartmentGroup.Where(x => x.DepartmentName  == value[0]).FirstOrDefault();
            for (int i = 0; i < value.Count; i++)
            {
                if (i+1 < value.Count)
                {
                    DbExamType Examname = Context.DbExamType.Where(x => x.ExamTypeName == value[i + 1]).FirstOrDefault();

                    data.DepartmentGroup = departmentGroup.DepartmentGroup;
                    data.DepartmentName = value[0];
                    data.ExamType = Examname.ExamType;
                    data.CrDate = DateTime.Now;
                    Context.DbExamDepartmentGroup.Add(data);
                    Context.SaveChanges();
                }
                else
                {
                    break;
                }
   

            }

            return "success";


        }

        public string editExamGroupDepartmentGroup(List<string> value)
        {
            DbExamDepartmentGroup dataDelete = new DbExamDepartmentGroup();

            for (int i = 0; i < 10; i++)
            {
                
                dataDelete = Context.DbExamDepartmentGroup.Where(x => x.DepartmentName == value[0]).FirstOrDefault();
                if(dataDelete != null)
                {
                    Context.DbExamDepartmentGroup.Remove(dataDelete);
                    Context.SaveChanges();
                }
                else
                {
                    break;
                }
            }

            DbExamDepartmentGroup data = new DbExamDepartmentGroup();
          DbDepartmentGroup departmentGroup = Context.DbDepartmentGroup.Where(x => x.DepartmentName == value[0]).FirstOrDefault();
            for (int i = 0; i < value.Count; i++)
            {
                if (i + 1 < value.Count)
                {
                    DbExamType Examname = Context.DbExamType.Where(x => x.ExamTypeName == value[i + 1]).FirstOrDefault();
                    data.DepartmentGroup = departmentGroup.DepartmentGroup;
                    data.DepartmentName = value[0];
                    data.ExamType = Examname.ExamType;
                    data.CrDate = DateTime.Now;
                    Context.DbExamDepartmentGroup.Add(data);
                    Context.SaveChanges();
                }
                else
                {
                    break;
                }

            }

            return "success";


        }

    }
}
