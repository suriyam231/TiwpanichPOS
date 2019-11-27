﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
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
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Subdistricts> Subdistricts { get; set; }
        public virtual DbSet<TypeProduct> TypeProduct { get; set; }
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

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductDetail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_TypeID");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Profile__206D9190114A936A");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StoreOwner)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Profile__StoreID__2CF2ADDF");
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

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Onwer)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OperatorNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StoreFront).IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
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

            modelBuilder.Entity<TypeProduct>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__TypeProd__516F0395151B244E");

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
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