using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertiesToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmedProfile",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "IsConfirmedProfile", "PasswordHash", "Position", "SecurityStamp" },
                values: new object[] { "4a70eb09-141b-4889-ba66-b2d708878c3a", false, "AQAAAAIAAYagAAAAEARTqCfKKx8dH3InHxAmGm12RtzOh+B2jqZYNwcCgNDh/jlzUmzgxlkEx75sJTrcrQ==", 0, "c286fffa-d290-4afb-a47a-29514082ccac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "IsConfirmedProfile", "PasswordHash", "Position", "SecurityStamp" },
                values: new object[] { "1031c759-fc5d-436a-8ae1-389c44a97d8e", false, "AQAAAAIAAYagAAAAEK9aaNeJ5v4hMfqZHGZgb9uhzcwidTBDhmbWiieDYhUToJMROhsRHEYVAbxjpaYkhQ==", 0, "08ddfff6-2a5f-4cc0-8ef2-50aedc2e7ec5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "IsConfirmedProfile", "PasswordHash", "Position", "SecurityStamp" },
                values: new object[] { "17b607af-9cfa-47a9-9eba-931513d0df37", false, "AQAAAAIAAYagAAAAEIEXUN6ZaR3xUL0KxmgorEFlf8e/OcelKbsgDgOIAns/eyPvPw07CKRAfeD30xBCTQ==", 0, "5a0b5930-8eaf-4a3f-bd08-de467bab649a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmedProfile",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e44417c6-dbeb-4fd2-932d-a22fb8326241", "AQAAAAIAAYagAAAAEGorScV32Gp8Oiqj1H1p2XMQ1a2GDBMiXy747eERksK8djxIZnlBATGwHvgOpIfv/Q==", "b42eeab9-900a-4d92-ae57-b900f69e2008" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79aea351-62ce-474e-9277-d8fd40616bbe", "AQAAAAIAAYagAAAAEJ+089nYRtqwIBP4sda5ZEOlfW8yaPqnRIykk20330MiDEu/ywkIVWMrjKHXLFvAaA==", "99905543-670e-4dc8-9288-48ad65c1e312" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54646c0d-952d-4085-ab72-5c11162952c4", "AQAAAAIAAYagAAAAEBqSqvFs0CAUwHTNLhwZkZQ2sk4dRHSsaCN8y00Zd2thhAXn2nw0uTjpLIeXv2js+w==", "9bc4348d-76a0-4d4a-87b9-1e4ec6f939e1" });
        }
    }
}
