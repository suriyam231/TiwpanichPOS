using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2
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

        public virtual DbSet<EmployeeProfile> EmployeeProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=172.16.0.161\\sql2014_dev;Initial Catalog=SRM_DEV;User ID=sa;Password=P@$$w0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<EmployeeProfile>(entity =>
            {
                entity.HasKey(e => new { e.Empcode, e.Username })
                    .HasName("PK_Employee");

                entity.ToTable("EMPLOYEE_PROFILE");

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCODE")
                    .HasMaxLength(15);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(300);

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.Birthday)
                    .HasColumnName("BIRTHDAY")
                    .HasColumnType("datetime");

                entity.Property(e => e.Company)
                    .HasColumnName("COMPANY")
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

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Position)
                    .HasColumnName("POSITION")
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

                entity.Property(e => e.Team)
                    .HasColumnName("TEAM")
                    .HasMaxLength(100);

                entity.Property(e => e.Tel)
                    .HasColumnName("TEL")
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