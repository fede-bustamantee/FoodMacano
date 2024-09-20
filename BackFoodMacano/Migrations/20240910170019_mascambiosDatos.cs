using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class mascambiosDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DescripcionCorta",
                value: "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.");

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DescripcionCorta",
                value: "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.");

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DescripcionCorta",
                value: "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DescripcionCorta",
                value: "Clásica con queso");

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DescripcionCorta",
                value: "Sándwich de Milanesa");

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DescripcionCorta",
                value: "Coca-Cola");
        }
    }
}
