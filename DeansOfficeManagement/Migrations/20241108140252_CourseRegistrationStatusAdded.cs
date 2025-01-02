using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeansOfficeManagement.Migrations
{
    /// <inheritdoc />
    public partial class CourseRegistrationStatusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07f51e64-d648-4f29-8733-9bfa6a17ec9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55641f11-4ae9-49f3-b8cc-2382c1aea1fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3cf51f5-4cf8-4105-ae7f-438ce40fe880");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CourseRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4204d37c-4587-4bf3-b225-72160b04a77a", null, "ADMIN", "ADMIN" },
                    { "a9b7da40-891b-4004-9718-833bdb1a21ac", null, "LECTURER", "LECTURER" },
                    { "de55d240-bc7d-4f3a-acaf-9ddde2c15b26", null, "STUDENT", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "232c1f07-c254-4160-9f79-6216a3aeb456", "52ccedad-1fed-4a00-a400-989ab3ec4aba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5fefbc76-f638-4fda-b567-a0f94b406b07", "d6c00ed4-0be6-47d7-baed-5ab7e5845c54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "71a2e429-1aa4-4e29-9e52-a1e7e6164a53", "fc73d773-c75d-4e54-9821-7832921098f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b68c963d-f077-43eb-ad14-80c619ea063f", "68e9fb9f-38c7-43c9-a4d2-822111ece35b" });

            migrationBuilder.UpdateData(
                table: "CourseRegistrations",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3" },
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "CourseRegistrations",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4" },
                column: "Status",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4204d37c-4587-4bf3-b225-72160b04a77a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9b7da40-891b-4004-9718-833bdb1a21ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de55d240-bc7d-4f3a-acaf-9ddde2c15b26");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CourseRegistrations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07f51e64-d648-4f29-8733-9bfa6a17ec9e", null, "STUDENT", "STUDENT" },
                    { "55641f11-4ae9-49f3-b8cc-2382c1aea1fc", null, "LECTURER", "LECTURER" },
                    { "b3cf51f5-4cf8-4105-ae7f-438ce40fe880", null, "ADMIN", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "56beca82-e8d3-40ef-896b-69545859eee7", "1c88e8e9-7710-4b67-936d-16122947c81b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5766605b-c9b0-44a9-a3df-f950dd5f810d", "f848a68e-90e9-486b-ad15-734dcb8b52a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0993e1db-f501-42b8-9c67-d05887e261e0", "5ade19aa-5a76-49f1-a044-4a1b8398a88e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3b3271a9-713f-4690-b15c-0ade39088e2f", "d87143f1-6792-4d5b-b350-0e986183a6cd" });
        }
    }
}
