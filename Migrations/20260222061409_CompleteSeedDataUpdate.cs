using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class CompleteSeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "AnnualTurnover", "BusinessName", "ContactPerson", "IsServiceCenter", "Region", "Tier" },
                values: new object[,]
                {
                    { 1, 12500000m, "North Solar Hub Meerut", "Vikas Gupta", true, "North", "Platinum" },
                    { 2, 8500000m, "Roorkee Energy Solutions", "Anil Tyagi", true, "North", "Gold" },
                    { 3, 25000000m, "Delhi Solar Power Systems", "Sandeep Malhotra", false, "North", "Platinum" },
                    { 4, 4500000m, "Southern Energy Chennai", "K. Ramakrishnan", true, "South", "Silver" },
                    { 5, 9800000m, "Western Solar Pune", "Rahul Deshmukh", false, "West", "Gold" }
                });

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 11, 44, 8, 607, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 11, 44, 8, 607, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.InsertData(
                table: "TrustLedger",
                columns: new[] { "Index", "Data", "Hash", "PreviousHash", "ProductId", "Timestamp" },
                values: new object[,]
                {
                    { 1, "GENESIS: Manufacturing Started (Roorkee Unit 4)", "816E2247E11695CBA365930039E1C2E1", "0", "TRON-3200-S04-001", new DateTime(2026, 2, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "QC Passed: Pure Sine Wave Efficiency 98.5%", "2C8C3886A26B5061B465228D7017A44F", "816E2247E11695CBA365930039E1C2E1", "TRON-3200-S04-001", new DateTime(2026, 2, 20, 14, 30, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrustLedger",
                keyColumn: "Index",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrustLedger",
                keyColumn: "Index",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 11, 39, 21, 871, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 11, 39, 21, 871, DateTimeKind.Local).AddTicks(9560));
        }
    }
}
