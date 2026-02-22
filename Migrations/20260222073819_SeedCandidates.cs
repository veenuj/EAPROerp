using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class SeedCandidates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "AppliedDate", "CurrentStep", "Email", "Name", "Position", "ResumeUrl", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "rahul.v@gmail.com", "Rahul Verma", "GenAI Developer", "", "Active" },
                    { 2, new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "sneha.k@eapro.in", "Sneha Kapoor", "Supply Chain Manager", "", "Active" },
                    { 3, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "aditya.v@outlook.com", "Vikram Aditya", "Embedded Systems Engineer", "", "Active" },
                    { 4, new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "pooja.h@gmail.com", "Pooja Hegde", "Technical Sales Executive", "", "Active" }
                });

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 13, 8, 18, 613, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 13, 8, 18, 613, DateTimeKind.Local).AddTicks(2750));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 13, 3, 17, 667, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 13, 3, 17, 667, DateTimeKind.Local).AddTicks(2490));
        }
    }
}
