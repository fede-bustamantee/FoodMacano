using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class enc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carritoCompra_encargues_EncargueId",
                table: "carritoCompra");

            migrationBuilder.DropTable(
                name: "encargues");

            migrationBuilder.DropIndex(
                name: "IX_carritoCompra_EncargueId",
                table: "carritoCompra");

            migrationBuilder.DropColumn(
                name: "EncargueId",
                table: "carritoCompra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EncargueId",
                table: "carritoCompra",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "encargues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaEncargue = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_encargues", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_carritoCompra_EncargueId",
                table: "carritoCompra",
                column: "EncargueId");

            migrationBuilder.AddForeignKey(
                name: "FK_carritoCompra_encargues_EncargueId",
                table: "carritoCompra",
                column: "EncargueId",
                principalTable: "encargues",
                principalColumn: "Id");
        }
    }
}
