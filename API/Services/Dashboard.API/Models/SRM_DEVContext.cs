using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dashboard.API.Models
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

        public virtual DbSet<RpChartMonthPerson> RpChartMonthPerson { get; set; }
        public virtual DbSet<RpChartMonthTeam> RpChartMonthTeam { get; set; }
        public virtual DbSet<RpChartPerson> RpChartPerson { get; set; }
        public virtual DbSet<RpChartQuater> RpChartQuater { get; set; }
        public virtual DbSet<RpTaskSummary> RpTaskSummary { get; set; }
        public virtual DbSet<RpTeam> RpTeam { get; set; }
        public virtual DbSet<RpTeamSummary> RpTeamSummary { get; set; }

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

            modelBuilder.Entity<RpChartMonthPerson>(entity =>
            {
                entity.HasKey(e => new { e.PersonCode, e.MonthCode, e.QuaterCode })
                    .HasName("PK_RP_ChartMonthPerson_1");

                entity.ToTable("RP_ChartMonthPerson");

                entity.Property(e => e.PersonCode).HasMaxLength(30);

                entity.Property(e => e.MonthCode).HasMaxLength(10);

                entity.Property(e => e.QuaterCode).HasMaxLength(2);

                entity.Property(e => e.CreatedBy).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PersonId)
                    .IsRequired()
                    .HasColumnName("PersonID")
                    .HasMaxLength(30);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RpChartMonthTeam>(entity =>
            {
                entity.HasKey(e => e.MonthCode)
                    .HasName("PK__PieMonth__82D92811CA352B58");

                entity.ToTable("RP_ChartMonthTeam");

                entity.Property(e => e.MonthCode)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.QuaterCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.TeamCode).HasMaxLength(30);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RpChartPerson>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.QuaterCode });

                entity.ToTable("RP_ChartPerson");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasMaxLength(30);

                entity.Property(e => e.QuaterCode).HasMaxLength(2);

                entity.Property(e => e.CreatedBy).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PersonCode)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);
            });

            modelBuilder.Entity<RpChartQuater>(entity =>
            {
                entity.HasKey(e => e.QuaterCode)
                    .HasName("PK__PieQuate__CB2F270F60F884C6");

                entity.ToTable("RP_ChartQuater");

                entity.Property(e => e.QuaterCode)
                    .HasMaxLength(2)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.QuaterName)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.TeamCode).HasMaxLength(30);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RpTaskSummary>(entity =>
            {
                entity.HasKey(e => new { e.QuaterCode, e.PersonId })
                    .HasName("PK_RP_TaskSummary_1");

                entity.ToTable("RP_TaskSummary");

                entity.Property(e => e.QuaterCode).HasMaxLength(2);

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasMaxLength(30);

                entity.Property(e => e.CreatedBy).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PersonCode)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.TaskPersonCode)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.TeamCode).HasMaxLength(30);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RpTeam>(entity =>
            {
                entity.HasKey(e => e.TeamCode)
                    .HasName("PK__Team__55013509F7B7EEF6");

                entity.ToTable("RP_Team");

                entity.Property(e => e.TeamCode)
                    .HasMaxLength(30)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasMaxLength(30);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RpTeamSummary>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__TeamSumm__AA2FFB850ED9A33D");

                entity.ToTable("RP_TeamSummary");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasMaxLength(30)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PersonCode)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.QuaterCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}