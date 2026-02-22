using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "AIStockPrediction", "Category", "Name", "Price", "StockLevel" },
                values: new object[,]
                {
                    { 1, "", "Inverter", "EAPRO TRON-3200 3000VA 24V AI-MPPT Dual Battery PCU", 19349m, 45 },
                    { 2, "", "Inverter", "EAPRO 3500VA 48V MPPT Single Phase Pure Sine Wave", 31570m, 18 },
                    { 3, "", "Inverter", "EAPRO 5625VA 48V MPPT Solar Inverter", 51659m, 8 },
                    { 4, "", "Inverter", "EAPRO 11 kW Three-Phase On-Grid Inverter", 85000m, 5 },
                    { 5, "", "Solar Panel", "EAPRO 590W TOPCon Bifacial Solar Panel", 18500m, 120 },
                    { 6, "", "Solar Panel", "EAPRO 550W Mono Half-Cut Solar Panel", 15000m, 340 },
                    { 7, "", "Solar Panel", "EAPRO 445W Mono PERC Solar Panel", 12500m, 85 },
                    { 8, "", "Solar Panel", "EAPRO 170W Polycrystalline Solar Panel", 4500m, 15 },
                    { 9, "", "Battery", "EAPRO Enerbatt 250Ah Solar Battery", 16500m, 60 },
                    { 10, "", "Battery", "EAPRO Hybrid Solar Tubular Battery 150Ah", 11000m, 110 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
