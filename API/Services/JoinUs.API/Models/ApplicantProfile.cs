using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantProfile
    {
        public ApplicantProfile()
        {
            ApplicantEduHistory = new HashSet<ApplicantEduHistory>();
            ApplicantExamAnswerHistory = new HashSet<ApplicantExamAnswerHistory>();
            ApplicantRef = new HashSet<ApplicantRef>();
            ApplicantSkillLanguage = new HashSet<ApplicantSkillLanguage>();
            ApplicantTrainingHistory = new HashSet<ApplicantTrainingHistory>();
            ApplicantWorkingHistory = new HashSet<ApplicantWorkingHistory>();
        }

        public int Empid { get; set; }
        public string FirstnameTh { get; set; }
        public string LastnameTh { get; set; }
        public string FirstnameEn { get; set; }
        public string LastnameEn { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
        public string IdCard { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string PostalCode { get; set; }
        public string ImgPath { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
        public string StatusApplicant { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string StatusContact { get; set; }
        public string Lineid { get; set; }
        public string Stay { get; set; }
        public string TitlenameTh { get; set; }
        public string TitlenameEn { get; set; }
        public string TypeEmployee { get; set; }
        public string BranchCode { get; set; }
        public string DepartmentGroup { get; set; }
        public string Department { get; set; }
        public string CompanyCode { get; set; }
        public string Team { get; set; }
        public string MilitaryStatus { get; set; }
        public string MilitaryDesc { get; set; }
        public string ActivityDesc { get; set; }
        public string Goal1 { get; set; }
        public string Goal2 { get; set; }
        public string Goal3 { get; set; }

        public virtual ApplicantSkill ApplicantSkill { get; set; }
        public virtual ICollection<ApplicantEduHistory> ApplicantEduHistory { get; set; }
        public virtual ICollection<ApplicantExamAnswerHistory> ApplicantExamAnswerHistory { get; set; }
        public virtual ICollection<ApplicantRef> ApplicantRef { get; set; }
        public virtual ICollection<ApplicantSkillLanguage> ApplicantSkillLanguage { get; set; }
        public virtual ICollection<ApplicantTrainingHistory> ApplicantTrainingHistory { get; set; }
        public virtual ICollection<ApplicantWorkingHistory> ApplicantWorkingHistory { get; set; }
    }
}