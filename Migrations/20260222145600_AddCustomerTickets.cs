using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTickets", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTickets");

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 14, 25, 24, 844, DateTimeKind.Local).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 14, 25, 24, 844, DateTimeKind.Local).AddTicks(7480));
        }
    }
}
