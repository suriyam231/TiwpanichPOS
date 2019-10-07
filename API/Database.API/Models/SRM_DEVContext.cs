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

        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Subdistricts> Subdistricts { get; set; }
        public virtual DbSet<UserId> UserId { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Districts>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UX_Districts_Code")
                    .IsUnique();

                entity.HasIndex(e => e.ProvinceId);

                entity.Property(e => e.NameInEnglish)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NameInThai)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Districts_Provinces");
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UX_Provinces_Code")
                    .IsUnique();

                entity.Property(e => e.NameInEnglish)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NameInThai)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Subdistricts>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UX_Subdistricts_Code")
                    .IsUnique();

                entity.HasIndex(e => e.DistrictId);

                entity.HasIndex(e => e.ZipCode)
                    .HasName("UX_Subdistricts_ZipCode");

                entity.Property(e => e.Latitude).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NameInEnglish).HasMaxLength(150);

                entity.Property(e => e.NameInThai)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Subdistricts)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subdistricts_Districts");
            });

            modelBuilder.Entity<UserId>(entity =>
            {
                entity.HasKey(e => e.UserId1)
                    .HasName("PK__UserID__1788CCAC02084FDA");

                entity.ToTable("UserID");

                entity.Property(e => e.UserId1)
                    .HasColumnName("UserID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CrDate).HasColumnType("datetime");

                entity.Property(e => e.PassWord)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}