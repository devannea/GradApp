using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GradApp.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseCode = table.Column<int>(nullable: false),
                    CourseSection = table.Column<int>(nullable: false),
                    CourseName = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(nullable: true),
                    ClockIn = table.Column<DateTime>(nullable: false),
                    ClockOut = table.Column<DateTime>(nullable: false),
                    Initials = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheets_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timesheets_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CourseName", "CourseSection", "Subject" },
                values: new object[] { 1, 1301, "MATH", 201, "College Algebra" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "StudentId" },
                values: new object[] { 1, "Jane", "Doe", 123456789 });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "Id", "ClockIn", "ClockOut", "CourseId", "Initials", "StudentId" },
                values: new object[] { 1, new DateTime(2019, 9, 4, 13, 32, 2, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 4, 14, 17, 41, 0, DateTimeKind.Unspecified), null, "HK", null });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "Id", "ClockIn", "ClockOut", "CourseId", "Initials", "StudentId" },
                values: new object[] { 2, new DateTime(2019, 9, 6, 12, 17, 37, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 6, 13, 11, 21, 0, DateTimeKind.Unspecified), null, "SW", null });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "Id", "ClockIn", "ClockOut", "CourseId", "Initials", "StudentId" },
                values: new object[] { 3, new DateTime(2019, 9, 9, 14, 3, 56, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 9, 14, 47, 28, 0, DateTimeKind.Unspecified), null, "DA", null });

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_CourseId",
                table: "Timesheets",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_StudentId",
                table: "Timesheets",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
