using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class DocumentMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "Document",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Document",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 44, 26, 879, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 44, 26, 879, DateTimeKind.Local).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 44, 26, 879, DateTimeKind.Local).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 44, 26, 879, DateTimeKind.Local).AddTicks(128));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 44, 26, 879, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 44, 26, 879, DateTimeKind.Local).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 44, 26, 879, DateTimeKind.Local).AddTicks(133));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 44, 26, 879, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.CreateIndex(
                name: "IX_Document_BuyerId",
                table: "Document",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_CreatedById",
                table: "Document",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_AspNetUsers_BuyerId",
                table: "Document",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_AspNetUsers_CreatedById",
                table: "Document",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_AspNetUsers_BuyerId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_AspNetUsers_CreatedById",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_BuyerId",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_CreatedById",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Document");

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 38, 0, 313, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 38, 0, 313, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 38, 0, 313, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 38, 0, 313, DateTimeKind.Local).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 38, 0, 313, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 38, 0, 313, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 38, 0, 313, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Created",
                value: new DateTime(2025, 12, 10, 20, 38, 0, 313, DateTimeKind.Local).AddTicks(4950));
        }
    }
}
