using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BankAccountNumber", "DateOfJoining", "Email", "EmergencyContact", "EmployeeCode", "GovernmentId", "IFSCCode", "Phone" },
                values: new object[] { "123456789012", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "amit.sharma@eapro.in", "+91-9876543211", "EAP-2301-1001", "ABCDE1234F", "HDFC0001234", "+91-9876543210" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BankAccountNumber", "DateOfJoining", "Email", "EmergencyContact", "EmployeeCode", "GovernmentId", "IFSCCode", "Phone" },
                values: new object[] { "987654321098", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "priya.singh@eapro.in", "+91-8765432110", "EAP-2305-1002", "456789012345", "SBIN0005678", "+91-8765432109" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "BankAccountNumber", "DateOfJoining", "Email", "EmergencyContact", "EmployeeCode", "GovernmentId", "IFSCCode", "Phone" },
                values: new object[] { "112233445566", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ravi.verma@eapro.in", "+91-7654321099", "EAP-2408-1003", "FGHIJ5678K", "ICIC0009012", "+91-7654321098" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BankAccountNumber", "DateOfJoining", "Email", "EmergencyContact", "EmployeeCode", "GovernmentId", "IFSCCode", "Phone" },
                values: new object[] { "", new DateTime(2026, 2, 21, 18, 44, 40, 753, DateTimeKind.Local).AddTicks(7680), "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BankAccountNumber", "DateOfJoining", "Email", "EmergencyContact", "EmployeeCode", "GovernmentId", "IFSCCode", "Phone" },
                values: new object[] { "", new DateTime(2026, 2, 21, 18, 44, 40, 773, DateTimeKind.Local).AddTicks(4300), "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "BankAccountNumber", "DateOfJoining", "Email", "EmergencyContact", "EmployeeCode", "GovernmentId", "IFSCCode", "Phone" },
                values: new object[] { "", new DateTime(2026, 2, 21, 18, 44, 40, 773, DateTimeKind.Local).AddTicks(4320), "", "", "", "", "", "" });
        }
    }
}
