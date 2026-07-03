using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerTicketSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerTickets",
                columns: new[] { "Id", "CreatedAt", "CustomerName", "Description", "Email", "PhoneNumber", "ProductSerialNumber", "RequestType", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), "Rakesh Tiwari", "Inverter is showing error code E-04 during power cut.", "rakesh.t@gmail.com", "+91-9876512345", "TRON-3200-S04-005", "Complaint", "Open" },
                    { 2, new DateTime(2026, 2, 18, 14, 15, 0, 0, DateTimeKind.Unspecified), "Meera Joshi", "Need installation for 5KW solar panels at my residence in Dehradun.", "meera.j@yahoo.com", "+91-8765423456", "EAPRO-590W-PANEL-SET", "Installation", "Resolved" },
                    { 3, new DateTime(2026, 2, 21, 9, 45, 0, 0, DateTimeKind.Unspecified), "Suresh Kumar", "Registering newly purchased battery for standard 5-year warranty.", "suresh.k@outlook.com", "+91-7654334567", "ENERBATT-250AH-001", "Product Registration", "Open" }
                });

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 20, 31, 44, 112, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 20, 31, 44, 112, DateTimeKind.Local).AddTicks(8400));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerTickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerTickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomerTickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 20, 26, 0, 250, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 20, 26, 0, 250, DateTimeKind.Local).AddTicks(7770));
        }
    }
}
