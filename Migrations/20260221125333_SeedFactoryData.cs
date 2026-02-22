using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class SeedFactoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "QualityScore",
                table: "ProductionLines",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "ProductionLines",
                columns: new[] { "Id", "CurrentProduct", "DailyTarget", "LineName", "QualityScore", "Status", "UnitsCompleted" },
                values: new object[,]
                {
                    { 1, "TRON-3200 AI-MPPT", 250, "Line Alpha-1", 99.5m, "Active", 180 },
                    { 2, "590W TOPCon Bifacial", 500, "Line Beta-Sigma", 98.8m, "Active", 410 },
                    { 3, "Enerbatt 250Ah Tubular", 150, "Line Gamma-Storage", 92.4m, "Maintenance", 45 },
                    { 4, "11kW On-Grid Inverter", 100, "Line Delta-Grid", 100.0m, "Active", 100 },
                    { 5, "Core DSP Motherboards", 1200, "Line Epsilon-PCB", 99.9m, "Active", 850 },
                    { 6, "5kW Hybrid PCU", 120, "Line Zeta-Hybrid", 100.0m, "Offline", 0 },
                    { 7, "Prototype Smart-Grid Unit", 10, "Line Omega-R&D", 88.5m, "Active", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductionLines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductionLines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductionLines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductionLines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductionLines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductionLines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductionLines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<decimal>(
                name: "QualityScore",
                table: "ProductionLines",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);
        }
    }
}
