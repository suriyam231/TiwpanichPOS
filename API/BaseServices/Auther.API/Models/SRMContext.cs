using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Auther.API.Models
{
    public partial class SRMContext : DbContext
    {
        public SRMContext()
        {
        }

        public SRMContext(DbContextOptions<SRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DbPosition> DbPosition { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeProfile> EmployeeProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=172.16.0.249;Initial Catalog=SRM_DEV;Persist Security Info=True;User ID=sa;Password=p@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<DbPosition>(entity =>
            {
                entity.HasKey(e => e.PositionNo);

                entity.ToTable("DB_POSITION");

                entity.Property(e => e.PositionNo).HasColumnName("POSITION_NO");

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentGroup)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_GROUP")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PositionName)
                    .HasColumnName("POSITION_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositonCode)
                    .IsRequired()
                    .HasColumnName("POSITON_CODE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SeqNo).HasColumnName("SEQ_NO");

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Empcode)
                    .HasName("PK__EMPLOYEE__21EDEE6DCE170AA2");

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Failtime).HasColumnName("FAILTIME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255);

                entity.Property(e => e.Passwordexpirydate)
                    .HasColumnName("PASSWORDEXPIRYDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Passwordsalt)
                    .IsRequired()
                    .HasColumnName("PASSWORDSALT")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeProfile>(entity =>
            {
                entity.HasKey(e => e.Empcode)
                    .HasName("PK_Employee");

                entity.ToTable("EMPLOYEE_PROFILE");

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCODE")
                    .HasMaxLength(15)
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(300);

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.Birthday)
                    .HasColumnName("BIRTHDAY")
                    .HasColumnType("datetime");

                entity.Property(e => e.Branch)
                    .HasColumnName("BRANCH")
                    .HasMaxLength(100);

                entity.Property(e => e.BranchCode)
                    .HasColumnName("BRANCH_CODE")
                    .HasMaxLength(100);

                entity.Property(e => e.Company)
                    .HasColumnName("COMPANY")
                    .HasMaxLength(100);

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(100);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .HasColumnName("DEPARTMENT")
                    .HasMaxLength(100);

                entity.Property(e => e.DepartmentGroup)
                    .HasColumnName("DEPARTMENT_GROUP")
                    .HasMaxLength(100);

                entity.Property(e => e.District)
                    .HasColumnName("DISTRICT")
                    .HasMaxLength(30);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstnameEn)
                    .HasColumnName("FIRSTNAME_EN")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstnameTh)
                    .HasColumnName("FIRSTNAME_TH")
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(20);

                entity.Property(e => e.IdCard)
                    .HasColumnName("ID_CARD")
                    .HasMaxLength(13);

                entity.Property(e => e.ImgPath).HasColumnName("IMG_PATH");

                entity.Property(e => e.LastnameEn)
                    .HasColumnName("LASTNAME_EN")
                    .HasMaxLength(100);

                entity.Property(e => e.LastnameTh)
                    .HasColumnName("LASTNAME_TH")
                    .HasMaxLength(100);

                entity.Property(e => e.Nationality)
                    .HasColumnName("NATIONALITY")
                    .HasMaxLength(100);

                entity.Property(e => e.NickName)
                    .HasColumnName("NICK_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Position)
                    .HasColumnName("POSITION")
                    .HasMaxLength(100);

                entity.Property(e => e.PositionCode)
                    .HasColumnName("POSITION_CODE")
                    .HasMaxLength(100);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("POSTAL_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.Province)
                    .HasColumnName("PROVINCE")
                    .HasMaxLength(30);

                entity.Property(e => e.Religion)
                    .HasColumnName("RELIGION")
                    .HasMaxLength(100);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasMaxLength(20);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(20);

                entity.Property(e => e.SubDistrict)
                    .HasColumnName("SUB_DISTRICT")
                    .HasMaxLength(30);

                entity.Property(e => e.Tel)
                    .HasColumnName("TEL")
                    .HasMaxLength(15);

                entity.Property(e => e.TitlenameEn)
                    .HasColumnName("TITLENAME_EN")
                    .HasMaxLength(15);

                entity.Property(e => e.TitlenameTh)
                    .HasColumnName("TITLENAME_TH")
                    .HasMaxLength(15);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}