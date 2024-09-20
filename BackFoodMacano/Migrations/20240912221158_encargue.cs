using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class encargue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carritoCompra_encargues_EncargueId",
                table: "carritoCompra");

            migrationBuilder.AlterColumn<int>(
                name: "EncargueId",
                table: "carritoCompra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "encargues",
                columns: new[] { "Id", "Estado", "FechaEncargue", "Total" },
                values: new object[,]
                {
                    { 1, "Pendiente", new DateTime(2024, 9, 11, 19, 11, 55, 326, DateTimeKind.Local).AddTicks(3485), 100.00m },
                    { 2, "Completado", new DateTime(2024, 9, 12, 19, 11, 55, 326, DateTimeKind.Local).AddTicks(3567), 200.00m }
                });

            migrationBuilder.InsertData(
                table: "carritoCompra",
                columns: new[] { "Id", "Cantidad", "EncargueId", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 1, 1, "Producto A", 50.00m },
                    { 2, 2, 1, "Producto B", 25.00m },
                    { 3, 2, 2, "Producto C", 100.00m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_carritoCompra_encargues_EncargueId",
                table: "carritoCompra",
                column: "EncargueId",
                principalTable: "encargues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carritoCompra_encargues_EncargueId",
                table: "carritoCompra");

            migrationBuilder.DeleteData(
                table: "carritoCompra",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "carritoCompra",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "carritoCompra",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "encargues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "encargues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "EncargueId",
                table: "carritoCompra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_carritoCompra_encargues_EncargueId",
                table: "carritoCompra",
                column: "EncargueId",
                principalTable: "encargues",
                principalColumn: "Id");
        }
    }
}
