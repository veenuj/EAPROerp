using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class CompleteTitanModuleExpansion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103);

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
                keyValue: 10);

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

            migrationBuilder.DeleteData(
                table: "SolarProjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SolarProjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AmcContracts",
                columns: new[] { "Id", "ClientName", "ContractExpiryDate", "ContractStartDate", "ContractValue", "NextScheduledService", "ProjectSite", "ServiceFrequency" },
                values: new object[] { 1, "Pacific Mall Dehradun", new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120000m, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Main Roof B", "Quarterly" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AIPerformanceInsight", "BankAccountNumber", "EmergencyContact", "IFSCCode" },
                values: new object[] { null, "", "", "" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AIPerformanceInsight", "BankAccountNumber", "EmergencyContact", "IFSCCode" },
                values: new object[] { null, "", "", "" });

            migrationBuilder.InsertData(
                table: "ProjectEngines",
                columns: new[] { "Id", "ClientName", "CommencementDate", "ContractValue", "CurrentPhase", "ExecutionProgress", "ProjectName", "ProjectType", "RoofType", "ShadowAnalysisScore", "SiteLocation", "SystemCapacityKW" },
                values: new object[,]
                {
                    { 1, "UP Health Dept", new DateTime(2026, 2, 22, 11, 12, 44, 351, DateTimeKind.Local).AddTicks(7280), 12500000m, "Installation", 65, "Roorkee Medical College Solar Hub", "On-Grid", "RRC Slab", 0, "Roorkee, UK", 450.0 },
                    { 2, "Smart City Auth", new DateTime(2026, 2, 22, 11, 12, 44, 351, DateTimeKind.Local).AddTicks(8440), 4200000m, "Site Survey", 15, "Meerut IT Park Unit 4", "Hybrid", "RRC Slab", 0, "Meerut, UP", 120.5 }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Category", "CompanyName", "ContactPerson", "Email", "OutstandingBalance", "ReliabilityScore", "Status" },
                values: new object[,]
                {
                    { 1, "Electronics", "Silicon Tech Japan", "Kenji Sato", "sato@silicontech.jp", 4500000m, 98, "Active" },
                    { 2, "Logistics", "Delta Logistics Meerut", "Vikas Tyagi", "v.tyagi@deltalog.in", 125000m, 85, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Warranties",
                columns: new[] { "Id", "CustomerName", "IsRegistered", "ProductName", "PurchaseDate", "SerialNumber", "WarrantyPeriodMonths" },
                values: new object[] { 1, "Anuj Dhiman", true, "Tron 3200 PCU", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "TRON-3200-S04-001", 24 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AmcContracts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Warranties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "AnnualTurnover", "BusinessName", "ContactPerson", "IsServiceCenter", "Region", "Tier" },
                values: new object[,]
                {
                    { 1, 12000000m, "North Solar Hub", "Vikas Gupta", true, "North", "Platinum" },
                    { 2, 8500000m, "Southern Energy Solutions", "S. Rajesh", false, "South", "Gold" }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AIPerformanceInsight", "BankAccountNumber", "EmergencyContact", "IFSCCode" },
                values: new object[] { "", "123456789012", "+91-9876543211", "HDFC0001234" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AIPerformanceInsight", "BankAccountNumber", "EmergencyContact", "IFSCCode" },
                values: new object[] { "", "987654321098", "+91-8765432110", "SBIN0005678" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AIPerformanceInsight", "BankAccountNumber", "BaseSalary", "BiometricCredentialId", "BiometricPublicKey", "Bonus", "DateOfJoining", "Department", "Designation", "Email", "EmergencyContact", "EmployeeCode", "GovernmentId", "IFSCCode", "JobLocation", "Name", "Phone" },
                values: new object[] { 103, "", "112233445566", 38000m, null, null, 2000m, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Installation", "PV Technician", "ravi.verma@eapro.in", "+91-7654321099", "EAP-2408-1003", "FGHIJ5678K", "ICIC0009012", "Roorkee", "Ravi Verma", "+91-7654321098" });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "AIStockPrediction", "Category", "Name", "Price", "StockLevel" },
                values: new object[,]
                {
                    { 3, "", "Inverter", "EAPRO 5625VA 48V MPPT Solar Inverter", 51659m, 8 },
                    { 4, "", "Inverter", "EAPRO 11 kW Three-Phase On-Grid Inverter", 85000m, 5 },
                    { 6, "", "Solar Panel", "EAPRO 550W Mono Half-Cut Solar Panel", 15000m, 340 },
                    { 7, "", "Solar Panel", "EAPRO 445W Mono PERC Solar Panel", 12500m, 85 },
                    { 8, "", "Solar Panel", "EAPRO 170W Polycrystalline Solar Panel", 4500m, 15 },
                    { 10, "", "Battery", "EAPRO Hybrid Solar Tubular Battery 150Ah", 11000m, 110 }
                });

            migrationBuilder.InsertData(
                table: "ProductionLines",
                columns: new[] { "Id", "CurrentProduct", "DailyTarget", "LineName", "QualityScore", "Status", "UnitsCompleted" },
                values: new object[,]
                {
                    { 3, "Enerbatt 250Ah Tubular", 150, "Line Gamma-Storage", 92.4m, "Maintenance", 45 },
                    { 4, "11kW On-Grid Inverter", 100, "Line Delta-Grid", 100.0m, "Active", 100 },
                    { 5, "Core DSP Motherboards", 1200, "Line Epsilon-PCB", 99.9m, "Active", 850 },
                    { 6, "5kW Hybrid PCU", 120, "Line Zeta-Hybrid", 100.0m, "Offline", 0 },
                    { 7, "Prototype Smart-Grid Unit", 10, "Line Omega-R&D", 88.5m, "Active", 3 }
                });

            migrationBuilder.InsertData(
                table: "SolarProjects",
                columns: new[] { "Id", "CapacityKW", "ClientName", "ContractValue", "Location", "ProjectType", "Status" },
                values: new object[,]
                {
                    { 1, 150m, "Roorkee Industrial Complex", 4500000m, "Roorkee", "On-Grid", "Commissioned" },
                    { 2, 50m, "Delhi Green Housing", 1800000m, "Delhi", "Hybrid", "Installation" }
                });
        }
    }
}
