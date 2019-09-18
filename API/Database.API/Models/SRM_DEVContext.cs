using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.API.Models
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

        public virtual DbSet<DbBranch> DbBranch { get; set; }
        public virtual DbSet<DbCompany> DbCompany { get; set; }
        public virtual DbSet<DbDepartmentGroup> DbDepartmentGroup { get; set; }
        public virtual DbSet<DbPosition> DbPosition { get; set; }
        public object BranchValue { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<DbBranch>(entity =>
            {
                entity.HasKey(e => e.BranchCode)
                    .HasName("PK__DB_BRANC__7CBC495987CC4B74");

                entity.ToTable("DB_BRANCH");

                entity.Property(e => e.BranchCode)
                    .HasColumnName("BRANCH_CODE")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasColumnName("BRANCH_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DbCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyCode)
                    .HasName("PK__DB_COMPA__BD25F02A9120F0F6");

                entity.ToTable("DB_COMPANY");

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyName)
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrBy)
                    .HasColumnName("CR_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrDate)
                    .HasColumnName("CR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdBy)
                    .HasColumnName("UPD_BY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("UPD_DATE")
                    .HasColumnType("datetime");
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

                entity.HasOne(d => d.DepartmentGroupNavigation)
                    .WithMany(p => p.DbPosition)
                    .HasForeignKey(d => d.DepartmentGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DB_POSITI__DEPAR__047AA831");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}