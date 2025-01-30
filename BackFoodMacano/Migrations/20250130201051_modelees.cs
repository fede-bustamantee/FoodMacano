using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class modelees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mauiDetalleEncargue_mauiEncargue_EncargueId",
                table: "mauiDetalleEncargue");

            migrationBuilder.DropForeignKey(
                name: "FK_mauiDetalleEncargue_productos_ProductoId",
                table: "mauiDetalleEncargue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mauiDetalleEncargue",
                table: "mauiDetalleEncargue");

            migrationBuilder.RenameTable(
                name: "mauiDetalleEncargue",
                newName: "MauiEncargueDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_mauiDetalleEncargue_ProductoId",
                table: "MauiEncargueDetalle",
                newName: "IX_MauiEncargueDetalle_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_mauiDetalleEncargue_EncargueId",
                table: "MauiEncargueDetalle",
                newName: "IX_MauiEncargueDetalle_EncargueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MauiEncargueDetalle",
                table: "MauiEncargueDetalle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MauiEncargueDetalle_mauiEncargue_EncargueId",
                table: "MauiEncargueDetalle",
                column: "EncargueId",
                principalTable: "mauiEncargue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MauiEncargueDetalle_productos_ProductoId",
                table: "MauiEncargueDetalle",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MauiEncargueDetalle_mauiEncargue_EncargueId",
                table: "MauiEncargueDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_MauiEncargueDetalle_productos_ProductoId",
                table: "MauiEncargueDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MauiEncargueDetalle",
                table: "MauiEncargueDetalle");

            migrationBuilder.RenameTable(
                name: "MauiEncargueDetalle",
                newName: "mauiDetalleEncargue");

            migrationBuilder.RenameIndex(
                name: "IX_MauiEncargueDetalle_ProductoId",
                table: "mauiDetalleEncargue",
                newName: "IX_mauiDetalleEncargue_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_MauiEncargueDetalle_EncargueId",
                table: "mauiDetalleEncargue",
                newName: "IX_mauiDetalleEncargue_EncargueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mauiDetalleEncargue",
                table: "mauiDetalleEncargue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mauiDetalleEncargue_mauiEncargue_EncargueId",
                table: "mauiDetalleEncargue",
                column: "EncargueId",
                principalTable: "mauiEncargue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mauiDetalleEncargue_productos_ProductoId",
                table: "mauiDetalleEncargue",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
