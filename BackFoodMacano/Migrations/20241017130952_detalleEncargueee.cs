using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class detalleEncargueee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "carritoCompra");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "carritoCompra");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "carritoCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_carritoCompra_ProductoId",
                table: "carritoCompra",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_carritoCompra_productos_ProductoId",
                table: "carritoCompra",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carritoCompra_productos_ProductoId",
                table: "carritoCompra");

            migrationBuilder.DropIndex(
                name: "IX_carritoCompra_ProductoId",
                table: "carritoCompra");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "carritoCompra");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "carritoCompra",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "carritoCompra",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
