using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReportInfrastructure.Models;

public partial class ReportDbContext : DbContext
{
    public ReportDbContext()
    {
    }

    public ReportDbContext(DbContextOptions<ReportDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Premise> Premises { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Premise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("premises_pkey");

            entity.ToTable("premises");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PremiseName)
                .HasMaxLength(100)
                .HasColumnName("premise_name");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reports_pkey");

            entity.ToTable("reports");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PremiseId)
                .ValueGeneratedOnAdd()
                .HasColumnName("premise_id");
            entity.Property(e => e.ReportDateTime).HasColumnName("report_date_time");
            entity.Property(e => e.ReportName)
                .HasMaxLength(150)
                .HasColumnName("report_name");
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("user_id");

            entity.HasOne(d => d.Premise).WithMany(p => p.Reports)
                .HasForeignKey(d => d.PremiseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("report_premise_id");

            entity.HasOne(d => d.User).WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("report_user_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("uesr_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('uesr_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.UserName)
                .HasMaxLength(80)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
