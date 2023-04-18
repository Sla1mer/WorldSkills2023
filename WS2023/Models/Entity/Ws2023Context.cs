using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WS2023.Models.Entity;

public partial class Ws2023Context : DbContext
{
    public Ws2023Context()
    {
    }

    public Ws2023Context(DbContextOptions<Ws2023Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<GroupVisit> GroupVisits { get; set; }

    public virtual DbSet<PersonalVisit> PersonalVisits { get; set; }

    public virtual DbSet<Purpose> Purposes { get; set; }

    public virtual DbSet<StatusesVisit> StatusesVisits { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-H39PTCV\\SQLEXPRESS; Initial Catalog=WS2023; TrustServerCertificate=Yes; Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departament>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        modelBuilder.Entity<GroupVisit>(entity =>
        {
            entity.ToTable("Group_visit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Email)
                .HasColumnType("text")
                .HasColumnName("email");
            entity.Property(e => e.Fio)
                .HasColumnType("text")
                .HasColumnName("fio");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.ParentVisit).HasColumnName("parent_visit");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("text")
                .HasColumnName("phone_number");

            entity.HasOne(d => d.ParentVisitNavigation).WithMany(p => p.GroupVisits)
                .HasForeignKey(d => d.ParentVisit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Group_visit_Personal_visit");
        });

        modelBuilder.Entity<PersonalVisit>(entity =>
        {
            entity.ToTable("Personal_visit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.DateFinish)
                .HasColumnType("date")
                .HasColumnName("date_finish");
            entity.Property(e => e.DateStart)
                .HasColumnType("date")
                .HasColumnName("date_start");
            entity.Property(e => e.DateSubmitted)
                .HasColumnType("date")
                .HasColumnName("date_submitted");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Division).HasColumnName("division");
            entity.Property(e => e.Email)
                .HasColumnType("text")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.NumberPassport)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("number_passport");
            entity.Property(e => e.Organization)
                .HasColumnType("text")
                .HasColumnName("organization");
            entity.Property(e => e.Patronymic)
                .HasColumnType("text")
                .HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("text")
                .HasColumnName("phone_number");
            entity.Property(e => e.Purpose).HasColumnName("purpose");
            entity.Property(e => e.ScanPassport).HasColumnName("scan_passport");
            entity.Property(e => e.SeriaPassport)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("seria_passport");
            entity.Property(e => e.Surname)
                .HasColumnType("text")
                .HasColumnName("surname");
            entity.Property(e => e.Visitor).HasColumnName("visitor");
            entity.Property(e => e.Worker).HasColumnName("worker");

            entity.HasOne(d => d.DivisionNavigation).WithMany(p => p.PersonalVisits)
                .HasForeignKey(d => d.Division)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personal_visit_Divisions");

            entity.HasOne(d => d.PurposeNavigation).WithMany(p => p.PersonalVisits)
                .HasForeignKey(d => d.Purpose)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personal_visit_Purpose");

            entity.HasOne(d => d.VisitorNavigation).WithMany(p => p.PersonalVisits)
                .HasForeignKey(d => d.Visitor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personal_visit_Users");

            entity.HasOne(d => d.WorkerNavigation).WithMany(p => p.PersonalVisits)
                .HasForeignKey(d => d.Worker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personal_visit_Workers");
        });

        modelBuilder.Entity<Purpose>(entity =>
        {
            entity.ToTable("Purpose");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        modelBuilder.Entity<StatusesVisit>(entity =>
        {
            entity.ToTable("Statuses_visit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.PersonalVisit).HasColumnName("personal_visit");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.PersonalVisitNavigation).WithMany(p => p.StatusesVisits)
                .HasForeignKey(d => d.PersonalVisit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Statuses_visit_Personal_visit");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodeUser).HasColumnName("code_user");
            entity.Property(e => e.Departament).HasColumnName("departament");
            entity.Property(e => e.Division).HasColumnName("division");
            entity.Property(e => e.Fio)
                .HasColumnType("text")
                .HasColumnName("fio");

            entity.HasOne(d => d.DepartamentNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.Departament)
                .HasConstraintName("FK_Workers_Divisions");

            entity.HasOne(d => d.DivisionNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.Division)
                .HasConstraintName("FK_Workers_Departaments");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
