using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class AddBiometricToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "BiometricCredentialId",
                table: "Employees",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "BiometricPublicKey",
                table: "Employees",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BiometricCredentialId", "BiometricPublicKey" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BiometricCredentialId", "BiometricPublicKey" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "BiometricCredentialId", "BiometricPublicKey" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiometricCredentialId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BiometricPublicKey",
                table: "Employees");
        }
    }
}
