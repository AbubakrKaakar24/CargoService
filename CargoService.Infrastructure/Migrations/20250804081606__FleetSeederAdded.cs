using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CargoService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _FleetSeederAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fleets",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 2, "fleet2@example.com", "FastTrans", "+93712345678" },
                    { 3, "contact@cargo3.com", "Speedy Movers", "+93798765432" },
                    { 4, "info@fleet4.com", "Reliable Fleet", "+93755566677" },
                    { 5, "support@fleet5.com", "Express Logistics", "+93711223344" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
