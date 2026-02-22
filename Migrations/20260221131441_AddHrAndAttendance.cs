using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class AddHrAndAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateOfJoining",
                value: new DateTime(2026, 2, 21, 18, 44, 40, 753, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateOfJoining",
                value: new DateTime(2026, 2, 21, 18, 44, 40, 773, DateTimeKind.Local).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateOfJoining",
                value: new DateTime(2026, 2, 21, 18, 44, 40, 773, DateTimeKind.Local).AddTicks(4320));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateOfJoining",
                value: new DateTime(2026, 2, 21, 18, 43, 22, 394, DateTimeKind.Local).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateOfJoining",
                value: new DateTime(2026, 2, 21, 18, 43, 22, 411, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateOfJoining",
                value: new DateTime(2026, 2, 21, 18, 43, 22, 411, DateTimeKind.Local).AddTicks(6250));
        }
    }
}
