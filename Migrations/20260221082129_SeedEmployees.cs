using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AIPerformanceInsight", "BaseSalary", "Bonus", "Department", "Designation", "Name" },
                values: new object[,]
                {
                    { 101, "", 45000m, 5000m, "Manufacturing", "Plant Supervisor", "Amit Sharma" },
                    { 102, "", 85000m, 18000m, "R&D", "DSP Solar Engineer", "Priya Singh" },
                    { 103, "", 38000m, 2000m, "Installation", "PV Technician", "Ravi Verma" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103);
        }
    }
}
