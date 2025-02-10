using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class modificacionDesktop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "desktopEncargues");

            migrationBuilder.DropColumn(
                name: "NombreProducto",
                table: "desktopEncargues");

            migrationBuilder.DropColumn(
                name: "PrecioUnitario",
                table: "desktopEncargues");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "desktopEncargues");

            migrationBuilder.CreateTable(
                name: "DesktopDetalleEncargue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DesktopEncargueId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    NombreProducto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesktopDetalleEncargue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesktopDetalleEncargue_desktopEncargues_DesktopEncargueId",
                        column: x => x.DesktopEncargueId,
                        principalTable: "desktopEncargues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DesktopDetalleEncargue_DesktopEncargueId",
                table: "DesktopDetalleEncargue",
                column: "DesktopEncargueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesktopDetalleEncargue");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "desktopEncargues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NombreProducto",
                table: "desktopEncargues",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioUnitario",
                table: "desktopEncargues",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "desktopEncargues",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
