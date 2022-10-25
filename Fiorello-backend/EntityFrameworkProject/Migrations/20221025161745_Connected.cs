using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkProject.Migrations
{
    public partial class Connected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 10, 25, 20, 17, 45, 193, DateTimeKind.Local).AddTicks(362));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 10, 25, 20, 17, 45, 193, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 10, 25, 20, 17, 45, 193, DateTimeKind.Local).AddTicks(7085));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 10, 24, 13, 6, 5, 189, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 10, 24, 13, 6, 5, 191, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 10, 24, 13, 6, 5, 192, DateTimeKind.Local).AddTicks(136));
        }
    }
}
