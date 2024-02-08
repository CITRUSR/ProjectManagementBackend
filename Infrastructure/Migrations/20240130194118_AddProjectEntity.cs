using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1ad7419-8392-49ab-b75b-4667c1f2a64f", "AQAAAAIAAYagAAAAEMVHWGuwjkaU+ezY6xRwFT4uC/meZB/tM+hVGvAEUE1etgnN7uKYafZhEGZt+VlWvQ==", "2aacce18-687f-4f33-8130-b1d84b6ed070" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2803e81b-d881-4604-a318-3f3bbc519034", "AQAAAAIAAYagAAAAEDA/dGmb00QN8Vk7zbS8AWe1b3FNiL0LiOOcBCsw+WGh7oNpSQ2OgnrwE4ogbV+T7Q==", "6b9f680f-e1cd-4d1d-8678-6cd69e4acbec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20461a26-6154-464f-a64c-051ecfccca2f", "AQAAAAIAAYagAAAAEPv/kABo/yxbKPEBUpJa+tcQ8Hk77sINFjQRSEcjEkrs8YGyUSCyZavjTAUqPLF1Bg==", "dea19ddd-a2b5-45d1-a399-fbc978b8d2bf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d057bdd-9312-4ea5-90dc-0b77bcca9827", "AQAAAAIAAYagAAAAEH6blNVMW3yoWhbOHjjCwZLX8jEYWwHB1c1XVIaF1lP/NyCR/sa4GTixVuJgBNsSpA==", "71af6d9a-c2b2-458c-b137-d42ff1ec8ac9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c70ce64-f394-4b4b-9dc6-156afc9c0668", "AQAAAAIAAYagAAAAEBtEqQ+L1TPX0lka0MXPfx95oqZ/gc6DGtFFAVQJ37R5nPq3tRIN09gSCQY2cd2cNg==", "f613cc05-e75f-4ad0-9bcb-eb601fffdfb2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6300383-2f59-4576-91ae-f1d9aa65ad41", "AQAAAAIAAYagAAAAEGhHBJbTE8mkx8VpMrNYAWPCKrNSXfbVAWquLIpKunfl4NhN6GDWFw+j3qCC4tiL+g==", "3bed8518-53ae-436a-9b67-38da0bd5b1b1" });
        }
    }
}
