using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class DocumentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 34, 9, 704, DateTimeKind.Local).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 34, 9, 704, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 34, 9, 704, DateTimeKind.Local).AddTicks(866));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 34, 9, 704, DateTimeKind.Local).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 34, 9, 704, DateTimeKind.Local).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 34, 9, 704, DateTimeKind.Local).AddTicks(875));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 34, 9, 704, DateTimeKind.Local).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 34, 9, 704, DateTimeKind.Local).AddTicks(878));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2025, 12, 8, 20, 9, 6, 249, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2025, 12, 8, 20, 9, 6, 249, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2025, 12, 8, 20, 9, 6, 249, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2025, 12, 8, 20, 9, 6, 249, DateTimeKind.Local).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created",
                value: new DateTime(2025, 12, 8, 20, 9, 6, 249, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created",
                value: new DateTime(2025, 12, 8, 20, 9, 6, 249, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created",
                value: new DateTime(2025, 12, 8, 20, 9, 6, 249, DateTimeKind.Local).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Created",
                value: new DateTime(2025, 12, 8, 20, 9, 6, 249, DateTimeKind.Local).AddTicks(1450));
        }
    }
}
