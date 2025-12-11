using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicationUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresss_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresss",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresss_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created",
                value: new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6541));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created",
                value: new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created",
                value: new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "QuantityTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Created",
                value: new DateTime(2025, 11, 21, 20, 4, 12, 107, DateTimeKind.Local).AddTicks(6545));
        }
    }
}
