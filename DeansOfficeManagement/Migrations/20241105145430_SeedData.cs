using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeansOfficeManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GradeLetter",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "StudentNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "9182ce0a-5197-4e5f-9dbb-4f422373d5af", "admin@deanoffice.com", true, null, null, false, null, null, null, "hashed_password_for_admin", null, false, null, "2bd16258-08ab-4429-b519-24d6651fdfc3", null, false, "admin@deanoffice.com" },
                    { "2", 0, "941efe93-8172-42b1-bfe7-5bd5a3caa611", "lecturer@deanoffice.com", true, null, null, false, null, null, null, "hashed_password_for_lecturer", null, false, null, "56f9bd9e-36c6-48da-a14c-fd8fc36cd25a", null, false, "lecturer@deanoffice.com" },
                    { "3", 0, "90827c04-d190-4491-9d29-20b8031e2a2d", "student1@deanoffice.com", true, null, null, false, null, null, null, "hashed_password_for_student1", null, false, null, "7a6393b6-6f37-475a-9d3f-5ef15e7809f0", null, false, "student1@deanoffice.com" },
                    { "4", 0, "3ba0e64f-d9d7-48a3-9ebc-e543ec5cd1cc", "student2@deanoffice.com", true, null, null, false, null, null, null, "hashed_password_for_student2", null, false, null, "c4dafce5-248c-4861-bac4-cb966eee58e1", null, false, "student2@deanoffice.com" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Credits", "LecturerId" },
                values: new object[,]
                {
                    { 1, "Mathematics 101", 3, "2" },
                    { 2, "Physics 101", 4, "2" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "DateSubmitted", "Description", "RequestType", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student requested for a transcript.", "Request for Transcript", "Pending", "3" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student requested to change course.", "Request for Course Change", "Approved", "4" }
                });

            migrationBuilder.InsertData(
                table: "CourseRegistrations",
                columns: new[] { "CourseId", "StudentId", "ApplicationUserId", "CourseRegistrationId" },
                values: new object[,]
                {
                    { 1, "3", null, 0 },
                    { 2, "4", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "CourseId", "GradeLetter", "Score", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, null, 85, "3" },
                    { 2, 2, null, 90, "4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "CourseRegistrations",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3" });

            migrationBuilder.DeleteData(
                table: "CourseRegistrations",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4" });

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.AlterColumn<string>(
                name: "GradeLetter",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
