using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class carritoCompr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarritoCompra",
                table: "CarritoCompra");

            migrationBuilder.RenameTable(
                name: "CarritoCompra",
                newName: "carritoCompra");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carritoCompra",
                table: "carritoCompra",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_carritoCompra",
                table: "carritoCompra");

            migrationBuilder.RenameTable(
                name: "carritoCompra",
                newName: "CarritoCompra");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarritoCompra",
                table: "CarritoCompra",
                column: "Id");
        }
    }
}
