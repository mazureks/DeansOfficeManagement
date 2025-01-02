using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeansOfficeManagement.Migrations
{
    /// <inheritdoc />
    public partial class CourseRegistrationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LecturerId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d326dc5-f9d8-4ab8-af93-8d466290e03c", null, "LECTURER", "LECTURER" },
                    { "6b03ff8d-e6f3-405e-a16e-01a512ffa323", null, "ADMIN", "ADMIN" },
                    { "dfe6dd0c-374b-4963-b617-464d25f0df24", null, "STUDENT", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "166a967f-1de2-42ad-84e3-bb2b4f6797a1", "14984652-add1-4456-9848-cbb136d39922" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c68a73f7-93cd-4632-8e2a-21e94badb9e0", "66abfea0-8f9e-4f9b-b159-fdc0a3a7e026" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "88f9b16d-834c-473c-bf95-177a9e0b137d", "31c3ec09-cb4a-4477-ab2a-3f05cfdca6c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c29b2e35-6096-42ee-9a64-b45a2b328a15", "a1370439-5c7f-4904-9c00-e2c901be8522" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d326dc5-f9d8-4ab8-af93-8d466290e03c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b03ff8d-e6f3-405e-a16e-01a512ffa323");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfe6dd0c-374b-4963-b617-464d25f0df24");

            migrationBuilder.AlterColumn<string>(
                name: "LecturerId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
