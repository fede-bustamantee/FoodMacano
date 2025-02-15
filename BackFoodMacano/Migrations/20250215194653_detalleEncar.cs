using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class detalleEncar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_encargues_productos_ProductoId",
                table: "encargues");

            migrationBuilder.DropIndex(
                name: "IX_encargues_ProductoId",
                table: "encargues");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "encargues");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "encargues");

            migrationBuilder.CreateTable(
                name: "encargueDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EncargueId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_encargueDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_encargueDetalles_encargues_EncargueId",
                        column: x => x.EncargueId,
                        principalTable: "encargues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_encargueDetalles_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_encargueDetalles_EncargueId",
                table: "encargueDetalles",
                column: "EncargueId");

            migrationBuilder.CreateIndex(
                name: "IX_encargueDetalles_ProductoId",
                table: "encargueDetalles",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "encargueDetalles");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "encargues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "encargues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_encargues_ProductoId",
                table: "encargues",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_encargues_productos_ProductoId",
                table: "encargues",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
