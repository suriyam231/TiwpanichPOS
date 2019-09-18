using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskManagement.Models
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

        public virtual DbSet<PjManageProject> PjManageProject { get; set; }
        public virtual DbSet<TmTaskManagement> TmTaskManagement { get; set; }

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

            modelBuilder.Entity<TmTaskManagement>(entity =>
            {
                entity.HasKey(e => e.TaskCode)
                    .HasName("PK_dbo.ManageTask");

                entity.ToTable("TM_TaskManagement");

                entity.Property(e => e.TaskCode)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.CreatedBy).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectCode).HasMaxLength(10);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.SystemCode).HasMaxLength(100);

                entity.Property(e => e.TaskName).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}