using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class inicioProyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "descripcionProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionCorta = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescripcionLarga = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_descripcionProductos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagenUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Calidad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Calorias = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    DescripcionProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productos_descripcionProductos_DescripcionProductoId",
                        column: x => x.DescripcionProductoId,
                        principalTable: "descripcionProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Hamburguesas" },
                    { 2, "Sanguches" },
                    { 3, "Bebidas" }
                });

            migrationBuilder.InsertData(
                table: "descripcionProductos",
                columns: new[] { "Id", "DescripcionCorta", "DescripcionLarga" },
                values: new object[,]
                {
                    { 1, "Clásica con queso", "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa." },
                    { 2, "Sándwich de Milanesa", "Sándwich de milanesa con tomate, lechuga y mayonesa en pan francés." },
                    { 3, "Coca-Cola", "Bebida gaseosa refrescante de 500 ml." }
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "Id", "Calidad", "Calorias", "CategoriaId", "DescripcionProductoId", "ImagenUrl", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Alta", 300, 1, 1, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", "Hamburguesa Clásica", 500 },
                    { 2, "Media", 350, 2, 2, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", "Sándwich de Milanesa", 450 },
                    { 3, "Alta", 150, 3, 3, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", "Coca-Cola 500ml", 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_productos_CategoriaId",
                table: "productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_DescripcionProductoId",
                table: "productos",
                column: "DescripcionProductoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "descripcionProductos");
        }
    }
}
