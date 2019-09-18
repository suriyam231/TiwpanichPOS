using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Listapplicant.Models
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

        public virtual DbSet<EmpProfile> EmpProfile { get; set; }

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

            modelBuilder.Entity<EmpProfile>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Emp_Prof__AF2DBA7980B3A728");

                entity.ToTable("Emp_Profile");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.CrBy)
                    .HasColumnName("Cr_By")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("Cr_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.District)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Etc)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstNameEn)
                    .HasColumnName("FirstName_En")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstNameTh)
                    .HasColumnName("FirstName_Th")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HomeTown)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdcardNumber)
                    .HasColumnName("IDCardNumber")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.ImgPath)
                    .HasColumnName("Img_Path")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LastNameEn)
                    .HasColumnName("LastName_En")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastNameTh)
                    .HasColumnName("LastName_Th")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("Postal_Code")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Religion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartWorking)
                    .HasColumnName("Start_Working")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubDistrict)
                    .HasColumnName("Sub_District")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TitleName)
                    .HasColumnName("Title_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdBy)
                    .HasColumnName("Upd_By")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("Upd_Date")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}