using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectManagementService.Models
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

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<PjEmployee> PjEmployee { get; set; }
        public virtual DbSet<PjManageProject> PjManageProject { get; set; }

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

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyCode);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.Leader).HasMaxLength(10);

                entity.Property(e => e.Team).HasMaxLength(10);

                entity.Property(e => e.Tel).HasMaxLength(10);
            });

            modelBuilder.Entity<PjEmployee>(entity =>
            {
                entity.HasKey(e => new { e.SystemCode, e.ProjectCode })
                    .HasName("PK_ProjectAuthentication_1");

                entity.ToTable("PJ_Employee");

                entity.Property(e => e.SystemCode).HasMaxLength(10);

                entity.Property(e => e.ProjectCode).HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(10);

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Leader).HasMaxLength(10);

                entity.Property(e => e.Role).HasMaxLength(10);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PjManageProject>(entity =>
            {
                entity.HasKey(e => e.ProjectCode)
                    .HasName("PK_ManageProject");

                entity.ToTable("PJ_ManageProject");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Deseription).HasMaxLength(255);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}