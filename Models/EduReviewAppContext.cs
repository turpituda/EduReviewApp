using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Models;

public partial class EduReviewAppContext : DbContext
{
    public EduReviewAppContext()
    {
    }

    public EduReviewAppContext(DbContextOptions<EduReviewAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Submission> Submissions { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("ConnString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__8F1EF7AE2063C0C5");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("course_id");
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("course_name");
            entity.Property(e => e.ProfessorId).HasColumnName("professor_id");

            entity.HasOne(d => d.Professor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course__professo__4222D4EF");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.ProfessorId).HasName("PK__Professo__7D9CA9A1FE5E0882");

            entity.ToTable("Professor");

            entity.Property(e => e.ProfessorId).HasColumnName("professor_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.user_id).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Professors)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Professor__user___3C69FB99");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__2A33069A9421C1AA");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("student_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.user_id).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__user_id__3F466844");

            entity.HasMany(d => d.Courses).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentCo__cours__45F365D3"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentCo__stude__44FF419A"),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseId").HasName("PK__StudentC__D2C2E9E0281312F5");
                        j.ToTable("StudentCourse");
                    });
        });

        modelBuilder.Entity<Submission>(entity =>
        {
            entity.HasKey(e => e.SubmissionId).HasName("PK__Submissi__9B535595139D3187");

            entity.ToTable("Submission");

            entity.Property(e => e.SubmissionId)
                .ValueGeneratedNever()
                .HasColumnName("submission_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.SubmissionComment)
                .IsUnicode(false)
                .HasColumnName("submission_comment");
            entity.Property(e => e.SubmissionDate)
                .HasColumnType("date")
                .HasColumnName("submission_date");
            entity.Property(e => e.SubmissionStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("submission_status");


            entity.HasOne(d => d.Student).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Submissio__stude__4F7CD00D");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.user_id).HasName("PK__Users__B9BE370F8D79C6E3");

            entity.Property(e => e.user_id).HasColumnName("user_id");
            entity.Property(e => e.email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.user_type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_type");
            entity.Property(e => e.username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
