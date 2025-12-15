using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class sadaksdlča : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2025, 12, 15, 18, 39, 59, 573, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2025, 12, 15, 18, 39, 59, 573, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2025, 12, 15, 18, 39, 59, 573, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2025, 12, 15, 18, 39, 59, 573, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created",
                value: new DateTime(2025, 12, 15, 18, 39, 59, 573, DateTimeKind.Local).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created",
                value: new DateTime(2025, 12, 15, 18, 39, 59, 573, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created",
                value: new DateTime(2025, 12, 15, 18, 39, 59, 573, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Created",
                value: new DateTime(2025, 12, 15, 18, 39, 59, 573, DateTimeKind.Local).AddTicks(8151));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2025, 12, 11, 20, 39, 18, 958, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2025, 12, 11, 20, 39, 18, 958, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2025, 12, 11, 20, 39, 18, 958, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2025, 12, 11, 20, 39, 18, 958, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created",
                value: new DateTime(2025, 12, 11, 20, 39, 18, 958, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created",
                value: new DateTime(2025, 12, 11, 20, 39, 18, 958, DateTimeKind.Local).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created",
                value: new DateTime(2025, 12, 11, 20, 39, 18, 958, DateTimeKind.Local).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Created",
                value: new DateTime(2025, 12, 11, 20, 39, 18, 958, DateTimeKind.Local).AddTicks(1869));
        }
    }
}
