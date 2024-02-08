using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectIdPropertyToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProjectId", "SecurityStamp" },
                values: new object[] { "76323306-0bc8-46b1-8a70-7abf90be3edd", "AQAAAAIAAYagAAAAEOfJkYzf4k0oAsADEKubpdSItYueH8VIqva659VrDe4xw1EZwrtDnOsp1BgEBwUsCw==", new Guid("00000000-0000-0000-0000-000000000000"), "bbb6c1f1-75f0-4857-9089-05b852e8fe81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProjectId", "SecurityStamp" },
                values: new object[] { "586a5e59-dd36-4358-bdb8-a9aeb5f98bce", "AQAAAAIAAYagAAAAEOH+VK4wm0NkX/QMBoN6FlkwM9sHm9SUhszkhrDvnGcvHnHJ11rXL3OrSbiHOGr84Q==", new Guid("00000000-0000-0000-0000-000000000000"), "e477c940-f03f-4783-a9da-61e591c592eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProjectId", "SecurityStamp" },
                values: new object[] { "0afb6b09-776e-459d-931a-57ddfb362677", "AQAAAAIAAYagAAAAEAzADlHHxWQLoQTiMAyTOaQXY+JHCc93z0gh3IMBUi3sqic6/VW6XM5KdtFkfHxxuQ==", new Guid("00000000-0000-0000-0000-000000000000"), "48312ec2-c0e3-430b-a4d1-92690576b91e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "AspNetUsers");

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
    }
}
