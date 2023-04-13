﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApp.Models;

#nullable disable

namespace MyApp.Migrations
{
    [DbContext(typeof(EduReviewAppContext))]
    partial class EduReviewAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyApp.Models.Assignment", b =>
                {
                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("assignment_id");

                    b.Property<string>("AssignmentName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("assignment_name");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("course_id");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("description");

                    b.HasKey("AssignmentId")
                        .HasName("PK__Assignme__DA891814F07ABDCE");

                    b.HasIndex("CourseId");

                    b.ToTable("Assignment", (string)null);
                });

            modelBuilder.Entity("MyApp.Models.Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("course_id");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("course_name");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("professor_id");

                    b.HasKey("CourseId")
                        .HasName("PK__Course__8F1EF7AE2063C0C5");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("MyApp.Models.File", b =>
                {
                    b.Property<int>("FileId")
                        .HasColumnType("int")
                        .HasColumnName("file_id");

                    b.Property<string>("FileName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("file_name");

                    b.Property<Guid?>("SubmissionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("submission_id");

                    b.HasKey("FileId")
                        .HasName("PK__Files__07D884C647EF9E2D");

                    b.HasIndex("SubmissionId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("MyApp.Models.Professor", b =>
                {
                    b.Property<Guid>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("professor_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("ProfessorId")
                        .HasName("PK__Professo__7D9CA9A1FE5E0882");

                    b.HasIndex("user_id");

                    b.ToTable("Professor", (string)null);
                });

            modelBuilder.Entity("MyApp.Models.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("student_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("StudentId")
                        .HasName("PK__Student__2A33069A9421C1AA");

                    b.HasIndex("user_id");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("MyApp.Models.Submission", b =>
                {
                    b.Property<Guid>("SubmissionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("submission_id");

                    b.Property<Guid?>("AssignmentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("assignment_id");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("student_id");

                    b.Property<string>("SubmissionComment")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("submission_comment");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("date")
                        .HasColumnName("submission_date");

                    b.Property<string>("SubmissionStatus")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("submission_status");

                    b.HasKey("SubmissionId")
                        .HasName("PK__Submissi__9B535595139D3187");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Submission", (string)null);
                });

            modelBuilder.Entity("MyApp.Models.Users", b =>
                {
                    b.Property<Guid>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("user_type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("user_type");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("username");

                    b.HasKey("user_id")
                        .HasName("PK__Users__B9BE370F8D79C6E3");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentCourse", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId", "CourseId")
                        .HasName("PK__StudentC__D2C2E9E0281312F5");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourse", (string)null);
                });

            modelBuilder.Entity("MyApp.Models.Assignment", b =>
                {
                    b.HasOne("MyApp.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK__Assignmen__cours__4AB81AF0");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("MyApp.Models.Course", b =>
                {
                    b.HasOne("MyApp.Models.Professor", "Professor")
                        .WithMany("Courses")
                        .HasForeignKey("ProfessorId")
                        .IsRequired()
                        .HasConstraintName("FK__Course__professo__4222D4EF");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("MyApp.Models.File", b =>
                {
                    b.HasOne("MyApp.Models.Submission", "Submission")
                        .WithMany("Files")
                        .HasForeignKey("SubmissionId")
                        .HasConstraintName("FK__Files__submissio__52593CB8");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("MyApp.Models.Professor", b =>
                {
                    b.HasOne("MyApp.Models.Users", "User")
                        .WithMany("Professors")
                        .HasForeignKey("user_id")
                        .IsRequired()
                        .HasConstraintName("FK__Professor__user___3C69FB99");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyApp.Models.Student", b =>
                {
                    b.HasOne("MyApp.Models.Users", "User")
                        .WithMany("Students")
                        .HasForeignKey("user_id")
                        .IsRequired()
                        .HasConstraintName("FK__Student__user_id__3F466844");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyApp.Models.Submission", b =>
                {
                    b.HasOne("MyApp.Models.Assignment", "Assignment")
                        .WithMany("Submissions")
                        .HasForeignKey("AssignmentId")
                        .HasConstraintName("FK__Submissio__assig__4E88ABD4");

                    b.HasOne("MyApp.Models.Student", "Student")
                        .WithMany("Submissions")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK__Submissio__stude__4F7CD00D");

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentCourse", b =>
                {
                    b.HasOne("MyApp.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK__StudentCo__cours__45F365D3");

                    b.HasOne("MyApp.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK__StudentCo__stude__44FF419A");
                });

            modelBuilder.Entity("MyApp.Models.Assignment", b =>
                {
                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("MyApp.Models.Course", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("MyApp.Models.Professor", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("MyApp.Models.Student", b =>
                {
                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("MyApp.Models.Submission", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("MyApp.Models.Users", b =>
                {
                    b.Navigation("Professors");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
