using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeansOfficeManagement.Migrations
{
    /// <inheritdoc />
    public partial class CoursUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7255bc12-df27-4b40-9750-0ca5119b9b0d", null, "ADMIN", "ADMIN" },
                    { "cf7d1bab-74dc-4ff0-8b1e-e8aa5d57ee09", null, "STUDENT", "STUDENT" },
                    { "d44dc8a0-15fe-4981-8383-4cbdb2797d57", null, "LECTURER", "LECTURER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d0bf3bb7-29a9-4c3f-80b6-9e531f94dd6e", "a2060ba8-4e87-4d51-b6c3-0ab4719b3159" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "876d060e-3b49-40f9-b8ac-50b75fdb3d4d", "72099083-ea6a-4831-90a4-d8d91afe90e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e6a3852f-8769-4aa4-81de-3b62cfce8d46", "2b31bd8e-379c-4b83-8e80-76703762741b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dd3ec92e-3124-440b-96c9-da69986d9dbc", "a7e02a76-62d1-4549-b818-b178f7581da3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7255bc12-df27-4b40-9750-0ca5119b9b0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf7d1bab-74dc-4ff0-8b1e-e8aa5d57ee09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d44dc8a0-15fe-4981-8383-4cbdb2797d57");

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
        }
    }
}
