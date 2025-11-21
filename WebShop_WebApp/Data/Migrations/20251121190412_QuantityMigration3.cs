using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebShop_WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuantityMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuantityTypes",
                columns: new[] { "Id", "Created", "Description", "Name", "Updated", "Valid" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6493), null, "Dan", null, true },
                    { 2L, new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6536), null, "Mjesec", null, true },
                    { 3L, new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6537), null, "Godina", null, true },
                    { 4L, new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6539), null, "Komad", null, true },
                    { 5L, new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6541), null, "Kilogram", null, true },
                    { 6L, new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6542), null, "Gram", null, true },
                    { 7L, new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6544), null, "Litara", null, true },
                    { 8L, new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6545), null, "Mililitar", null, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 8L);
        }
    }
}
