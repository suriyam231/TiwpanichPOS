using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RunningNo.API.Models
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

        public virtual DbSet<RuRunningNo> RuRunningNo { get; set; }
        public virtual DbSet<RuRunningType> RuRunningType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=172.16.0.161\\sql2014_dev;Initial Catalog=SRM_DEV;Persist Security Info=True;User ID=sa;Password=P@$$w0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<RuRunningNo>(entity =>
            {
                entity.ToTable("RU_RunningNo");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Parameter1).HasMaxLength(50);

                entity.Property(e => e.Parameter10).HasMaxLength(50);

                entity.Property(e => e.Parameter2).HasMaxLength(50);

                entity.Property(e => e.Parameter3).HasMaxLength(50);

                entity.Property(e => e.Parameter4).HasMaxLength(50);

                entity.Property(e => e.Parameter5).HasMaxLength(50);

                entity.Property(e => e.Parameter6).HasMaxLength(50);

                entity.Property(e => e.Parameter7).HasMaxLength(50);

                entity.Property(e => e.Parameter8).HasMaxLength(50);

                entity.Property(e => e.Parameter9).HasMaxLength(50);

                entity.Property(e => e.RunningTypeCode).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.RunningTypeCodeNavigation)
                    .WithMany(p => p.RuRunningNo)
                    .HasForeignKey(d => d.RunningTypeCode)
                    .HasConstraintName("FK__SystemRun__Updat__59FA5E80");
            });

            modelBuilder.Entity<RuRunningType>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__RunningT__A25C5AA6E7DAE45D");

                entity.ToTable("RU_RunningType");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RunningNoFormat).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}