using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectsAndDealers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualTurnover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsServiceCenter = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolarProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityKW = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarProjects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "AnnualTurnover", "BusinessName", "ContactPerson", "IsServiceCenter", "Region", "Tier" },
                values: new object[,]
                {
                    { 1, 12000000m, "North Solar Hub", "Vikas Gupta", true, "North", "Platinum" },
                    { 2, 8500000m, "Southern Energy Solutions", "S. Rajesh", false, "South", "Gold" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "SolarProjects");
        }
    }
}
