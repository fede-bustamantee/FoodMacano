using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class cambiosDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DescripcionLarga",
                value: "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.");

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DescripcionLarga",
                value: "Sándwich de milanesa con tomate, lechuga y mayonesa en pan francés.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.");

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DescripcionLarga",
                value: "Bebida gaseosa refrescante de 500 ml.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.lechuga, tomate y mayonesa.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DescripcionLarga",
                value: "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.");

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DescripcionLarga",
                value: "Sándwich de milanesa con tomate, lechuga y mayonesa en pan francés.");

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DescripcionLarga",
                value: "Bebida gaseosa refrescante de 500 ml.");
        }
    }
}
