using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class BASEM : Migration
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
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: false)
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
                name: "redesSociales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Instagram = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Facebook = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Whatsapp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_redesSociales", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    FirebaseId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "negocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MapaIframe = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RedesSocialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_negocios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_negocios_redesSociales_RedesSocialId",
                        column: x => x.RedesSocialId,
                        principalTable: "redesSociales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "carritoCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carritoCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_carritoCompra_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carritoCompra_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "encargues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaEncargue = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_encargues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_encargues_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_encargues_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraApertura = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraCierre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NegocioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horario_negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "negocios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "Id", "IconUrl", "Nombre" },
                values: new object[,]
                {
                    { 1, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconHamburguesa.png?alt=media&token=b280cbd2-9016-4647-85e9-048858807010", "Hamburguesas" },
                    { 2, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconSandwich.png?alt=media&token=dc21b284-630e-4b54-9b93-1b4668f316f2", "Sanguches" },
                    { 3, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconBebidas.png?alt=media&token=c87c60a9-215c-4a8f-8939-b3423e48a1c0", "Bebidas" }
                });

            migrationBuilder.InsertData(
                table: "descripcionProductos",
                columns: new[] { "Id", "DescripcionCorta", "DescripcionLarga" },
                values: new object[,]
                {
                    { 1, "Hamburguesa clásica de carne a la parrilla", "Deliciosa hamburguesa de carne a la parrilla con queso cheddar, lechuga fresca, tomate jugoso y nuestra salsa especial en un pan suave y tostado." },
                    { 2, "Hamburguesa doble con bacon", "Hamburguesa doble carne, doble queso y tiras de bacon crujiente. Acompañada de cebolla caramelizada y salsa barbacoa casera." },
                    { 3, "Hamburguesa vegetariana", "Hamburguesa vegetariana a base de lentejas y vegetales, con queso provolone, rúcula y tomates secos. Opción saludable y deliciosa." },
                    { 4, "Hamburguesa de pollo", "Jugosa hamburguesa de pollo a la parrilla con aguacate, lechuga y mayonesa de chipotle en pan integral." },
                    { 5, "Hamburguesa gourmet", "Hamburguesa gourmet de carne Angus, queso azul, cebolla caramelizada y reducción de vino tinto en pan brioche." },
                    { 6, "Sándwich de milanesa clásico", "Sándwich de milanesa de ternera con lechuga, tomate, queso y mayonesa en pan francés crujiente." },
                    { 7, "Sándwich de jamón y queso", "Sándwich caliente de jamón y queso derretido en pan de miga tostado. Un clásico irresistible." },
                    { 8, "Sándwich de pollo", "Sándwich de pechuga de pollo a la plancha con palta, tomate y lechuga en pan integral." },
                    { 9, "Sándwich vegetariano", "Sándwich vegetariano con hummus, vegetales asados, queso de cabra y rúcula en pan de centeno." },
                    { 10, "Sándwich de lomito", "Sándwich de lomito completo con lechuga, tomate, jamón, queso, huevo frito y mayonesa en pan ciabatta." },
                    { 11, "Coca-Cola", "Refrescante Coca-Cola clásica en botella de 500ml. El sabor de siempre para acompañar tu comida." },
                    { 12, "Agua mineral", "Agua mineral natural sin gas en botella de 500ml. Hidratación pura y refrescante." },
                    { 13, "Limonada casera", "Limonada casera preparada con limones frescos, un toque de menta y endulzada con miel. Bebida refrescante de 500ml." },
                    { 14, "Cerveza artesanal", "Cerveza artesanal tipo IPA en botella de 330ml. Sabor intenso y aromático con notas cítricas y tropicales." },
                    { 15, "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.", "Smoothie natural de frutas mixtas (frutilla, banana y naranja) sin azúcar añadida. Vaso de 400ml." }
                });

            migrationBuilder.InsertData(
                table: "redesSociales",
                columns: new[] { "Id", "Facebook", "Instagram", "Whatsapp" },
                values: new object[] { 1, "https://www.facebook.com", "https://www.instagram.com", "https://wa.me/543498409675" });

            migrationBuilder.InsertData(
                table: "negocios",
                columns: new[] { "Id", "Direccion", "MapaIframe", "Nombre", "RedesSocialId", "Telefono" },
                values: new object[] { 1, "Calle Falsa 123, Ciudad Ejemplo", "<iframe class=\"map\" src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d27541.325671616178!2d-60.439340636223776!3d-30.360449115325437!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944b0554d0eb3903%3A0x7b078fba72f704b!2sGdor.%20Crespo%2C%20Santa%20Fe!5e0!3m2!1ses!2sar!4v1725375616155!5m2!1ses!2sar\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Food Macano", 1, "123456789" });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "Id", "Calidad", "Calorias", "CategoriaId", "DescripcionProductoId", "ImagenUrl", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Alta", 550, 1, 1, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", "Hamburguesa Clásica", 500 },
                    { 2, "Alta", 800, 1, 2, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", "Hamburguesa Doble Bacon", 650 },
                    { 3, "Media", 400, 1, 3, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", "Hamburguesa Vegetariana", 450 },
                    { 4, "Media", 450, 1, 4, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", "Hamburguesa de Pollo", 480 },
                    { 5, "Premium", 700, 1, 5, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", "Hamburguesa Gourmet", 750 },
                    { 6, "Media", 600, 2, 6, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", "Sándwich de Milanesa", 450 },
                    { 7, "Media", 400, 2, 7, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", "Sándwich Jamón y Queso", 350 },
                    { 8, "Alta", 450, 2, 8, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", "Sándwich de Pollo", 400 },
                    { 9, "Alta", 350, 2, 9, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", "Sándwich Vegetariano", 380 },
                    { 10, "Premium", 700, 2, 10, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", "Sándwich de Lomito", 550 },
                    { 11, "Alta", 210, 3, 11, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", "Coca-Cola 500ml", 150 },
                    { 12, "Alta", 0, 3, 12, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", "Agua Mineral 500ml", 100 },
                    { 13, "Alta", 120, 3, 13, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", "Limonada Casera 500ml", 200 },
                    { 14, "Premium", 180, 3, 14, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", "Cerveza Artesanal IPA 330ml", 300 },
                    { 15, "Alta", 200, 3, 15, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", "Smoothie de Frutas 400ml", 250 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_carritoCompra_ProductoId",
                table: "carritoCompra",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_carritoCompra_UsuarioId",
                table: "carritoCompra",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_encargues_ProductoId",
                table: "encargues",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_encargues_UsuarioId",
                table: "encargues",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_NegocioId",
                table: "Horario",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_negocios_RedesSocialId",
                table: "negocios",
                column: "RedesSocialId");

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
                name: "carritoCompra");

            migrationBuilder.DropTable(
                name: "encargues");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "negocios");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "descripcionProductos");

            migrationBuilder.DropTable(
                name: "redesSociales");
        }
    }
}
