using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class FinalizeBillingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 12, 12, 29, 584, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 12, 12, 29, 584, DateTimeKind.Local).AddTicks(8130));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 12, 6, 33, 634, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 12, 6, 33, 634, DateTimeKind.Local).AddTicks(9190));
        }
    }
}
