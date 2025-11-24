using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class orderTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderAddressId = table.Column<long>(type: "bigint", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresss_OrderAddressId",
                        column: x => x.OrderAddressId,
                        principalTable: "Addresss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 20, 19, 20, 620, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 20, 19, 20, 620, DateTimeKind.Local).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 20, 19, 20, 620, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 20, 19, 20, 620, DateTimeKind.Local).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 20, 19, 20, 620, DateTimeKind.Local).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 20, 19, 20, 620, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 20, 19, 20, 620, DateTimeKind.Local).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 20, 19, 20, 620, DateTimeKind.Local).AddTicks(7439));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderAddressId",
                table: "Orders",
                column: "OrderAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 18, 25, 14, 164, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 18, 25, 14, 164, DateTimeKind.Local).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 18, 25, 14, 164, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 18, 25, 14, 164, DateTimeKind.Local).AddTicks(4416));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 18, 25, 14, 164, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 18, 25, 14, 164, DateTimeKind.Local).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 18, 25, 14, 164, DateTimeKind.Local).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Created",
                value: new DateTime(2025, 11, 24, 18, 25, 14, 164, DateTimeKind.Local).AddTicks(4422));
        }
    }
}
