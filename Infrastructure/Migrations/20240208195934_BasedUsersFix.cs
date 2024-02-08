using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BasedUsersFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsConfirmedProfile", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "ProjectId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2B0542C9-472E-4C6D-BD50-02611A0738FE", 0, "dbcecc10-b28e-45a3-a15d-73dfd62f1c64", null, false, true, false, null, null, "CITRUSADMIN", "AQAAAAIAAYagAAAAEOl+YQXQp1l3V8K0DaRD2tSDdW0oezq/XqRoZhgRZP3wRy4ivMzXMrJPTUR5HMKh/Q==", null, false, 0, new Guid("00000000-0000-0000-0000-000000000000"), "e96faaf5-a3c9-4b37-8dd3-f77f8563653b", false, "CitrusAdmin" },
                    { "AEC05A0F-B6AA-4EE6-AE54-5761C7EF79C9", 0, "5efd4d12-3a7e-4333-ace3-8fe33a6908ee", null, false, true, false, null, null, "CITRUSPROJECTMANAGER", "AQAAAAIAAYagAAAAEIqrWS+j5OvFkchbAXCrqnIRspzKCKz//SAaPC8LilktP0hwsY6nBJuXaMc/XNqfmw==", null, false, 0, new Guid("00000000-0000-0000-0000-000000000000"), "d23624e8-0843-4cb8-82ba-3f05f329a65c", false, "CitrusProjectManager" },
                    { "E21345E0-0C23-4043-AFFA-190E960F45DB", 0, "da4320cb-fdc1-4f40-b720-944fb10bef76", null, false, true, false, null, null, "CITRUSUSER", "AQAAAAIAAYagAAAAEDJJjZR61z40w52uc5A15Y7zA5hV5l1lkX48j2/lHU4SnTpVaz97BOF/oFxDMclu4A==", null, false, 0, new Guid("00000000-0000-0000-0000-000000000000"), "169c5613-00ba-44d4-bb84-40f5d77209b2", false, "CitrusUser" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "2B0542C9-472E-4C6D-BD50-02611A0738FE" },
                    { "2", "AEC05A0F-B6AA-4EE6-AE54-5761C7EF79C9" },
                    { "3", "E21345E0-0C23-4043-AFFA-190E960F45DB" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2B0542C9-472E-4C6D-BD50-02611A0738FE" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "AEC05A0F-B6AA-4EE6-AE54-5761C7EF79C9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "E21345E0-0C23-4043-AFFA-190E960F45DB" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2B0542C9-472E-4C6D-BD50-02611A0738FE");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "AEC05A0F-B6AA-4EE6-AE54-5761C7EF79C9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E21345E0-0C23-4043-AFFA-190E960F45DB");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsConfirmedProfile", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "ProjectId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "4a70eb09-141b-4889-ba66-b2d708878c3a", null, false, false, false, null, null, "CITRUSADMIN", "AQAAAAIAAYagAAAAEARTqCfKKx8dH3InHxAmGm12RtzOh+B2jqZYNwcCgNDh/jlzUmzgxlkEx75sJTrcrQ==", null, false, 0, new Guid("00000000-0000-0000-0000-000000000000"), "c286fffa-d290-4afb-a47a-29514082ccac", false, "CitrusAdmin" },
                    { "2", 0, "1031c759-fc5d-436a-8ae1-389c44a97d8e", null, false, false, false, null, null, "CITRUSPROJECTMANAGER", "AQAAAAIAAYagAAAAEK9aaNeJ5v4hMfqZHGZgb9uhzcwidTBDhmbWiieDYhUToJMROhsRHEYVAbxjpaYkhQ==", null, false, 0, new Guid("00000000-0000-0000-0000-000000000000"), "08ddfff6-2a5f-4cc0-8ef2-50aedc2e7ec5", false, "CitrusProjectManager" },
                    { "3", 0, "17b607af-9cfa-47a9-9eba-931513d0df37", null, false, false, false, null, null, "CITRUSUSER", "AQAAAAIAAYagAAAAEIEXUN6ZaR3xUL0KxmgorEFlf8e/OcelKbsgDgOIAns/eyPvPw07CKRAfeD30xBCTQ==", null, false, 0, new Guid("00000000-0000-0000-0000-000000000000"), "5a0b5930-8eaf-4a3f-bd08-de467bab649a", false, "CitrusUser" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" }
                });
        }
    }
}
