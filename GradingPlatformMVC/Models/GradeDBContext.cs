using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GradingPlatformMVC.Models;

public partial class GradeDBContext : DbContext
{
    public GradeDBContext()
    {
    }

    public GradeDBContext(DbContextOptions<GradeDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseHasStudent> CourseHasStudents { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Secretary> Secretaries { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HQ0D7N6;Database=gradeDB;Trusted_Connection=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.IdCourse).HasName("PK__courses__8982E30906C25AE0");

            entity.Property(e => e.IdCourse).ValueGeneratedNever();

            entity.HasOne(d => d.ProfessorsAfmNavigation).WithMany(p => p.Courses)
                .HasPrincipalKey(p => p.Afm)
                .HasConstraintName("FK__courses__profess__5629CD9C");
        });

        modelBuilder.Entity<CourseHasStudent>(entity =>
        {
            entity.HasKey(e => new { e.IdCourse, e.RegistrationNum }).HasName("PK__course_h__4453117B83B5C9CF");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.CourseHasStudents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__course_ha__idCou__59063A47");

            entity.HasOne(d => d.RegistrationNumNavigation).WithMany(p => p.CourseHasStudents)
                .HasPrincipalKey(p => p.RegistrationNum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__course_ha__regis__59FA5E80");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__professo__F3DBC57359A1F7CF");
        });

        modelBuilder.Entity<Secretary>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__secretar__F3DBC5731AFFC7C8");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__students__F3DBC5737FCC6FA6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
