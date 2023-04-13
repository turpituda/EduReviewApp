using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userid = table.Column<Guid>(name: "user_id", type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    usertype = table.Column<string>(name: "user_type", type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__B9BE370F8D79C6E3", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    professorid = table.Column<Guid>(name: "professor_id", type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Professo__7D9CA9A1FE5E0882", x => x.professorid);
                    table.ForeignKey(
                        name: "FK__Professor__user___3C69FB99",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentid = table.Column<Guid>(name: "student_id", type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__2A33069A9421C1AA", x => x.studentid);
                    table.ForeignKey(
                        name: "FK__Student__user_id__3F466844",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    courseid = table.Column<Guid>(name: "course_id", type: "uniqueidentifier", nullable: false),
                    coursename = table.Column<string>(name: "course_name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    professorid = table.Column<Guid>(name: "professor_id", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__8F1EF7AE2063C0C5", x => x.courseid);
                    table.ForeignKey(
                        name: "FK__Course__professo__4222D4EF",
                        column: x => x.professorid,
                        principalTable: "Professor",
                        principalColumn: "professor_id");
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    assignmentid = table.Column<Guid>(name: "assignment_id", type: "uniqueidentifier", nullable: false),
                    assignmentname = table.Column<string>(name: "assignment_name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    courseid = table.Column<Guid>(name: "course_id", type: "uniqueidentifier", nullable: true),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assignme__DA891814F07ABDCE", x => x.assignmentid);
                    table.ForeignKey(
                        name: "FK__Assignmen__cours__4AB81AF0",
                        column: x => x.courseid,
                        principalTable: "Course",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentC__D2C2E9E0281312F5", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK__StudentCo__cours__45F365D3",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK__StudentCo__stude__44FF419A",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "student_id");
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    submissionid = table.Column<Guid>(name: "submission_id", type: "uniqueidentifier", nullable: false),
                    submissiondate = table.Column<DateTime>(name: "submission_date", type: "date", nullable: true),
                    submissionstatus = table.Column<string>(name: "submission_status", type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    submissioncomment = table.Column<string>(name: "submission_comment", type: "varchar(max)", unicode: false, nullable: true),
                    assignmentid = table.Column<Guid>(name: "assignment_id", type: "uniqueidentifier", nullable: true),
                    studentid = table.Column<Guid>(name: "student_id", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Submissi__9B535595139D3187", x => x.submissionid);
                    table.ForeignKey(
                        name: "FK__Submissio__assig__4E88ABD4",
                        column: x => x.assignmentid,
                        principalTable: "Assignment",
                        principalColumn: "assignment_id");
                    table.ForeignKey(
                        name: "FK__Submissio__stude__4F7CD00D",
                        column: x => x.studentid,
                        principalTable: "Student",
                        principalColumn: "student_id");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    fileid = table.Column<int>(name: "file_id", type: "int", nullable: false),
                    filename = table.Column<string>(name: "file_name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    submissionid = table.Column<Guid>(name: "submission_id", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Files__07D884C647EF9E2D", x => x.fileid);
                    table.ForeignKey(
                        name: "FK__Files__submissio__52593CB8",
                        column: x => x.submissionid,
                        principalTable: "Submission",
                        principalColumn: "submission_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_course_id",
                table: "Assignment",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_professor_id",
                table: "Course",
                column: "professor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Files_submission_id",
                table: "Files",
                column: "submission_id");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_user_id",
                table: "Professor",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_user_id",
                table: "Student",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_assignment_id",
                table: "Submission",
                column: "assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_student_id",
                table: "Submission",
                column: "student_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Submission");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
