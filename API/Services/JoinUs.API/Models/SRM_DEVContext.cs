using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegisterManange.API.Models
{
    public partial class SRM_DEVContext : DbContext
    {
        public SRM_DEVContext()
        {
        }

        public SRM_DEVContext(DbContextOptions<SRM_DEVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicantAgreement> ApplicantAgreement { get; set; }
        public virtual DbSet<ApplicantAppointmentDate> ApplicantAppointmentDate { get; set; }
        public virtual DbSet<ApplicantAssetment> ApplicantAssetment { get; set; }
        public virtual DbSet<ApplicantEduHistory> ApplicantEduHistory { get; set; }
        public virtual DbSet<ApplicantExamAnswerHistory> ApplicantExamAnswerHistory { get; set; }
        public virtual DbSet<ApplicantProfile> ApplicantProfile { get; set; }
        public virtual DbSet<ApplicantRef> ApplicantRef { get; set; }
        public virtual DbSet<ApplicantSkill> ApplicantSkill { get; set; }
        public virtual DbSet<ApplicantSkillLanguage> ApplicantSkillLanguage { get; set; }
        public virtual DbSet<ApplicantTrainingHistory> ApplicantTrainingHistory { get; set; }
        public virtual DbSet<ApplicantWorkingHistory> ApplicantWorkingHistory { get; set; }
        public virtual DbSet<DbDepartmentGroup> DbDepartmentGroup { get; set; }
        public virtual DbSet<DbExam> DbExam { get; set; }
        public virtual DbSet<DbExamDepartmentGroup> DbExamDepartmentGroup { get; set; }
        public virtual DbSet<DbExamType> DbExamType { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<ListOfValue> ListOfValue { get; set; }
        public virtual DbSet<ListOfValueGroups> ListOfValueGroups { get; set; }
        public virtual DbSet<ManageRegisterPosition> ManageRegisterPosition { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Postcode> Postcode { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Subdistrict> Subdistrict { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=172.16.0.249;Initial Catalog=SRM_DEV;User ID=sa;Password=p@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<ApplicantAgreement>(entity =>
            {
                entity.HasKey(e => e.Empid);

                entity.ToTable("APPLICANT_AGREEMENT");

                entity.Property(e => e.Empid)
                    .HasColumnName("EMPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Company)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Other)
                    .HasColumnName("OTHER")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ApplicantAppointmentDate>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.Empid })
                    .HasName("XPKAPPLICANT_APPOINTMENT_DATE");

                entity.ToTable("APPLICANT_APPOINTMENT_DATE");

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnName("APPOINTMENT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AppointmentStatus)
                    .HasColumnName("APPOINTMENT_STATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datetime1)
                    .HasColumnName("DATETIME_1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datetime2)
                    .HasColumnName("DATETIME_2")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ApplicantAssetment>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("PK__APPLICAN__14CCD97D14675DC6");

                entity.ToTable("APPLICANT_ASSETMENT");

                entity.Property(e => e.Empid)
                    .HasColumnName("EMPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Edu01)
                    .HasColumnName("EDU_01")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Edu02)
                    .HasColumnName("EDU_02")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Edu03)
                    .HasColumnName("EDU_03")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Edu04)
                    .HasColumnName("EDU_04")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Oth01)
                    .HasColumnName("OTH_01")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Oth02)
                    .HasColumnName("OTH_02")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Per01)
                    .HasColumnName("PER_01")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Per02)
                    .HasColumnName("PER_02")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Per03)
                    .HasColumnName("PER_03")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Per04)
                    .HasColumnName("PER_04")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Recomment)
                    .HasColumnName("RECOMMENT")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.SummAss)
                    .HasColumnName("SUMM_ASS")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicantEduHistory>(entity =>
            {
                entity.HasKey(e => new { e.Empid, e.No });

                entity.ToTable("APPLICANT_EDU_HISTORY");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.No).HasColumnName("NO");

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Education)
                    .HasColumnName("EDUCATION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Faculty)
                    .HasColumnName("FACULTY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gpa)
                    .HasColumnName("GPA")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.GradYear)
                    .HasColumnName("GRAD_YEAR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Major)
                    .HasColumnName("MAJOR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasColumnName("SCHOOL_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ApplicantEduHistory)
                    .HasForeignKey(d => d.Empid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPLICANT_EDU_HISTORY");
            });

            modelBuilder.Entity<ApplicantExamAnswerHistory>(entity =>
            {
                entity.HasKey(e => new { e.Empid, e.ExamType, e.Seq })
                    .HasName("PK__APPLICAN__2A66E2BCB9E925F1");

                entity.ToTable("APPLICANT_EXAM_ANSWER_HISTORY");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.ExamType)
                    .HasColumnName("EXAM_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Seq).HasColumnName("SEQ");

                entity.Property(e => e.ApplicantAnswer)
                    .HasColumnName("APPLICANT_ANSWER")
                    .IsUnicode(false);

                entity.Property(e => e.Choice1)
                    .HasColumnName("CHOICE1")
                    .IsUnicode(false);

                entity.Property(e => e.Choice2)
                    .HasColumnName("CHOICE2")
                    .IsUnicode(false);

                entity.Property(e => e.Choice3)
                    .HasColumnName("CHOICE3")
                    .IsUnicode(false);

                entity.Property(e => e.Choice4)
                    .HasColumnName("CHOICE4")
                    .IsUnicode(false);

                entity.Property(e => e.Choice5)
                    .HasColumnName("CHOICE5")
                    .IsUnicode(false);

                entity.Property(e => e.Choice6)
                    .HasColumnName("CHOICE6")
                    .IsUnicode(false);

                entity.Property(e => e.ChoiceType)
                    .HasColumnName("CHOICE_TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CorrectAnswer)
                    .HasColumnName("CORRECT_ANSWER")
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Question)
                    .HasColumnName("QUESTION")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionImage)
                    .HasColumnName("QUESTION_IMAGE")
                    .IsUnicode(false);

                entity.Property(e => e.QuestionType)
                    .HasColumnName("QUESTION_TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UdBy)
                    .HasColumnName("UD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UdDate)
                    .HasColumnName("UD_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ApplicantExamAnswerHistory)
                    .HasForeignKey(d => d.Empid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPLICANT__EMPID__64CCF2AE");
            });

            modelBuilder.Entity<ApplicantProfile>(entity =>
            {
                entity.HasKey(e => e.Empid);

                entity.ToTable("APPLICANT_PROFILE");

                entity.Property(e => e.Empid)
                    .HasColumnName("EMPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityDesc)
                    .HasColumnName("ACTIVITY_DESC")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.Birthday)
                    .HasColumnName("BIRTHDAY")
                    .HasColumnType("datetime");

                entity.Property(e => e.BranchCode)
                    .HasColumnName("BRANCH_CODE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .HasColumnName("DEPARTMENT")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentGroup)
                    .HasColumnName("DEPARTMENT_GROUP")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasColumnName("DISTRICT")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstnameEn)
                    .HasColumnName("FIRSTNAME_EN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstnameTh)
                    .HasColumnName("FIRSTNAME_TH")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Goal1)
                    .HasColumnName("GOAL_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Goal2)
                    .HasColumnName("GOAL_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Goal3)
                    .HasColumnName("GOAL_3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Height).HasColumnName("HEIGHT");

                entity.Property(e => e.IdCard)
                    .HasColumnName("ID_CARD")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.ImgPath)
                    .HasColumnName("IMG_PATH")
                    .IsUnicode(false);

                entity.Property(e => e.LastnameEn)
                    .HasColumnName("LASTNAME_EN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastnameTh)
                    .HasColumnName("LASTNAME_TH")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lineid)
                    .HasColumnName("LINEID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MilitaryDesc)
                    .HasColumnName("MILITARY_DESC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MilitaryStatus)
                    .HasColumnName("MILITARY_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasColumnName("NATIONALITY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("POSITION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("POSTAL_CODE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasColumnName("PROVINCE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Religion)
                    .HasColumnName("RELIGION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusApplicant)
                    .HasColumnName("STATUS_APPLICANT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusContact)
                    .HasColumnName("STATUS_CONTACT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Stay)
                    .HasColumnName("STAY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubDistrict)
                    .HasColumnName("SUB_DISTRICT")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Team)
                    .HasColumnName("TEAM")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasColumnName("TEL")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TitlenameEn)
                    .HasColumnName("TITLENAME_EN")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TitlenameTh)
                    .HasColumnName("TITLENAME_TH")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TypeEmployee)
                    .HasColumnName("TYPE_EMPLOYEE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Weight).HasColumnName("WEIGHT");
            });

            modelBuilder.Entity<ApplicantRef>(entity =>
            {
                entity.HasKey(e => new { e.Empid, e.No });

                entity.ToTable("APPLICANT_REF");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.No).HasColumnName("NO");

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RefName)
                    .HasColumnName("REF_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RefPosition)
                    .HasColumnName("REF_POSITION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RefTel)
                    .HasColumnName("REF_TEL")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ApplicantRef)
                    .HasForeignKey(d => d.Empid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPLICANT_REF");
            });

            modelBuilder.Entity<ApplicantSkill>(entity =>
            {
                entity.HasKey(e => e.Empid);

                entity.ToTable("APPLICANT_SKILL");

                entity.Property(e => e.Empid)
                    .HasColumnName("EMPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Special1)
                    .HasColumnName("SPECIAL_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Special2)
                    .HasColumnName("SPECIAL_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Special3)
                    .HasColumnName("SPECIAL_3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Special4)
                    .HasColumnName("SPECIAL_4")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypingEn).HasColumnName("TYPING_EN");

                entity.Property(e => e.TypingTh).HasColumnName("TYPING_TH");

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithOne(p => p.ApplicantSkill)
                    .HasForeignKey<ApplicantSkill>(d => d.Empid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPLICANT_SKILL");
            });

            modelBuilder.Entity<ApplicantSkillLanguage>(entity =>
            {
                entity.HasKey(e => new { e.Empid, e.No });

                entity.ToTable("APPLICANT_SKILL_LANGUAGE");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.No).HasColumnName("NO");

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Language)
                    .HasColumnName("LANGUAGE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageRead)
                    .HasColumnName("LANGUAGE_READ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageSpeak)
                    .HasColumnName("LANGUAGE_SPEAK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageWrite)
                    .HasColumnName("LANGUAGE_WRITE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ApplicantSkillLanguage)
                    .HasForeignKey(d => d.Empid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPLICANT_SKILL_LANGUAGE");
            });

            modelBuilder.Entity<ApplicantTrainingHistory>(entity =>
            {
                entity.HasKey(e => new { e.Empid, e.No });

                entity.ToTable("APPLICANT_TRAINING_HISTORY");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.No).HasColumnName("NO");

                entity.Property(e => e.Certificate)
                    .HasColumnName("CERTIFICATE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CourseName)
                    .HasColumnName("COURSE_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("END_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrainingName)
                    .HasColumnName("TRAINING_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ApplicantTrainingHistory)
                    .HasForeignKey(d => d.Empid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPLICANT_TRAINING_HISTORY");
            });

            modelBuilder.Entity<ApplicantWorkingHistory>(entity =>
            {
                entity.HasKey(e => new { e.Empid, e.No });

                entity.ToTable("APPLICANT_WORKING_HISTORY");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.No).HasColumnName("NO");

                entity.Property(e => e.CompanyAddress)
                    .HasColumnName("COMPANY_ADDRESS")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("END_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Position)
                    .HasColumnName("POSITION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.WorkDesc)
                    .HasColumnName("WORK_DESC")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ApplicantWorkingHistory)
                    .HasForeignKey(d => d.Empid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPLICANT_WORKING_HISTORY");
            });

            modelBuilder.Entity<DbDepartmentGroup>(entity =>
            {
                entity.HasKey(e => e.DepartmentGroup)
                    .HasName("PK__DB_DEPAR__6584298A092A9332");

                entity.ToTable("DB_DEPARTMENT_GROUP");

                entity.Property(e => e.DepartmentGroup)
                    .HasColumnName("DEPARTMENT_GROUP")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("DEPARTMENT_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DbExam>(entity =>
            {
                entity.HasKey(e => new { e.ExamType, e.Seq })
                    .HasName("PK__DB_EXAM__EAA3BC1257C73FAF");

                entity.ToTable("DB_EXAM");

                entity.Property(e => e.ExamType)
                    .HasColumnName("EXAM_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Seq).HasColumnName("SEQ");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Choice1)
                    .HasColumnName("CHOICE1")
                    .IsUnicode(false);

                entity.Property(e => e.Choice2)
                    .HasColumnName("CHOICE2")
                    .IsUnicode(false);

                entity.Property(e => e.Choice3)
                    .HasColumnName("CHOICE3")
                    .IsUnicode(false);

                entity.Property(e => e.Choice4)
                    .HasColumnName("CHOICE4")
                    .IsUnicode(false);

                entity.Property(e => e.Choice5)
                    .HasColumnName("CHOICE5")
                    .IsUnicode(false);

                entity.Property(e => e.Choice6)
                    .HasColumnName("CHOICE6")
                    .IsUnicode(false);

                entity.Property(e => e.ChoiceType)
                    .HasColumnName("CHOICE_TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CorrectAnswer)
                    .HasColumnName("CORRECT_ANSWER")
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Question)
                    .HasColumnName("QUESTION")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionImage)
                    .HasColumnName("QUESTION_IMAGE")
                    .IsUnicode(false);

                entity.Property(e => e.QuestionType)
                    .HasColumnName("QUESTION_TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ExamTypeNavigation)
                    .WithMany(p => p.DbExam)
                    .HasForeignKey(d => d.ExamType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DB_EXAM__EXAM_TY__76EBA2E9");
            });

            modelBuilder.Entity<DbExamDepartmentGroup>(entity =>
            {
                entity.HasKey(e => new { e.ExamType, e.DepartmentGroup })
                    .HasName("PK__DB_EXAM___405A6D065E5AC4BB");

                entity.ToTable("DB_EXAM_DEPARTMENT_GROUP");

                entity.Property(e => e.ExamType)
                    .HasColumnName("EXAM_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentGroup)
                    .HasColumnName("DEPARTMENT_GROUP")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("DEPARTMENT_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.DepartmentGroupNavigation)
                    .WithMany(p => p.DbExamDepartmentGroup)
                    .HasForeignKey(d => d.DepartmentGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DB_EXAM_D__DEPAR__7E8CC4B1");

                entity.HasOne(d => d.ExamTypeNavigation)
                    .WithMany(p => p.DbExamDepartmentGroup)
                    .HasForeignKey(d => d.ExamType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DB_EXAM_D__EXAM___6F4A8121");
            });

            modelBuilder.Entity<DbExamType>(entity =>
            {
                entity.HasKey(e => e.ExamType)
                    .HasName("PK__DB_EXAM___F6022F9EF9BEF52E");

                entity.ToTable("DB_EXAM_TYPE");

                entity.Property(e => e.ExamType)
                    .HasColumnName("EXAM_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExamTypeName)
                    .HasColumnName("EXAM_TYPE_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ExamTypeSort).HasColumnName("EXAM_TYPE_SORT");

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("DISTRICT");

                entity.Property(e => e.DistrictId)
                    .HasColumnName("DISTRICT_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DistrictCode).HasColumnName("DISTRICT_CODE");

                entity.Property(e => e.DistrictEn)
                    .HasColumnName("DISTRICT_EN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictTh)
                    .HasColumnName("DISTRICT_TH")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceId).HasColumnName("PROVINCE_ID");
            });

            modelBuilder.Entity<ListOfValue>(entity =>
            {
                entity.HasKey(e => new { e.GroupCode, e.SeqNo })
                    .HasName("XPKLIST_OF_VALUE");

                entity.ToTable("LIST_OF_VALUE");

                entity.Property(e => e.GroupCode)
                    .HasColumnName("GROUP_CODE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SeqNo).HasColumnName("SEQ_NO");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnName("VALUE");
            });

            modelBuilder.Entity<ListOfValueGroups>(entity =>
            {
                entity.HasKey(e => e.GroupCode)
                    .HasName("PK__LIST_OF___05AF4D1441989FCE");

                entity.ToTable("LIST_OF_VALUE_GROUPS");

                entity.Property(e => e.GroupCode)
                    .HasColumnName("GROUP_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnName("VALUE");
            });

            modelBuilder.Entity<ManageRegisterPosition>(entity =>
            {
                entity.ToTable("MANAGE_REGISTER_POSITION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumberOfPosition).HasColumnName("NUMBER_OF_POSITION");

                entity.Property(e => e.PositionId).HasColumnName("POSITION_ID");

                entity.Property(e => e.TypeEmployee)
                    .HasColumnName("TYPE_EMPLOYEE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("POSITION");

                entity.Property(e => e.PositionId)
                    .HasColumnName("POSITION_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IconPosition)
                    .HasColumnName("ICON_POSITION")
                    .HasColumnType("text");

                entity.Property(e => e.Position1)
                    .HasColumnName("POSITION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Postcode>(entity =>
            {
                entity.ToTable("POSTCODE");

                entity.Property(e => e.PostcodeId)
                    .HasColumnName("POSTCODE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Postcode1).HasColumnName("POSTCODE");

                entity.Property(e => e.PostcodeCode).HasColumnName("POSTCODE_CODE");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("PROVINCE");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("PROVINCE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProvinceCode).HasColumnName("PROVINCE_CODE");

                entity.Property(e => e.ProvinceEn)
                    .HasColumnName("PROVINCE_EN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceTh)
                    .HasColumnName("PROVINCE_TH")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subdistrict>(entity =>
            {
                entity.ToTable("SUBDISTRICT");

                entity.Property(e => e.SubdistrictId)
                    .HasColumnName("SUBDISTRICT_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DistrictId).HasColumnName("DISTRICT_ID");

                entity.Property(e => e.ProvinceId).HasColumnName("PROVINCE_ID");

                entity.Property(e => e.SubdistrictCode).HasColumnName("SUBDISTRICT_CODE");

                entity.Property(e => e.SubdistrictEn)
                    .HasColumnName("SUBDISTRICT_EN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubdistrictTh)
                    .HasColumnName("SUBDISTRICT_TH")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}