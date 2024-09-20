using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class encarg : Migration
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_carritoCompra_encargues_EncargueId",
                table: "carritoCompra",
                column: "EncargueId",
                principalTable: "encargues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
