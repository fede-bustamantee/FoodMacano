using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreProducto",
                table: "MauiEncargueDetalle");

            migrationBuilder.DropColumn(
                name: "PrecioUnitario",
                table: "MauiEncargueDetalle");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "MauiEncargueDetalle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreProducto",
                table: "MauiEncargueDetalle",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioUnitario",
                table: "MauiEncargueDetalle",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "MauiEncargueDetalle",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
