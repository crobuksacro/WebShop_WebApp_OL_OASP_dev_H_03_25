using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuantityMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "QuantityTypeId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuantityTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_QuantityTypeId",
                table: "Products",
                column: "QuantityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_QuantityTypes_QuantityTypeId",
                table: "Products",
                column: "QuantityTypeId",
                principalTable: "QuantityTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_QuantityTypes_QuantityTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "QuantityTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_QuantityTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "QuantityTypeId",
                table: "Products");
        }
    }
}
