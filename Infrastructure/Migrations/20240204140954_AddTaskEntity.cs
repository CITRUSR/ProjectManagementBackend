using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76323306-0bc8-46b1-8a70-7abf90be3edd", "AQAAAAIAAYagAAAAEOfJkYzf4k0oAsADEKubpdSItYueH8VIqva659VrDe4xw1EZwrtDnOsp1BgEBwUsCw==", "bbb6c1f1-75f0-4857-9089-05b852e8fe81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "586a5e59-dd36-4358-bdb8-a9aeb5f98bce", "AQAAAAIAAYagAAAAEOH+VK4wm0NkX/QMBoN6FlkwM9sHm9SUhszkhrDvnGcvHnHJ11rXL3OrSbiHOGr84Q==", "e477c940-f03f-4783-a9da-61e591c592eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0afb6b09-776e-459d-931a-57ddfb362677", "AQAAAAIAAYagAAAAEAzADlHHxWQLoQTiMAyTOaQXY+JHCc93z0gh3IMBUi3sqic6/VW6XM5KdtFkfHxxuQ==", "48312ec2-c0e3-430b-a4d1-92690576b91e" });
        }
    }
}
