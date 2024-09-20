using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class mascambiosDatoss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DescripcionCorta", "DescripcionLarga" },
                values: new object[] { "Hamburguesa clásica de carne a la parrilla", "Deliciosa hamburguesa de carne a la parrilla con queso cheddar, lechuga fresca, tomate jugoso y nuestra salsa especial en un pan suave y tostado." });

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DescripcionCorta", "DescripcionLarga" },
                values: new object[] { "Hamburguesa doble con bacon", "Hamburguesa doble carne, doble queso y tiras de bacon crujiente. Acompañada de cebolla caramelizada y salsa barbacoa casera." });

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DescripcionCorta", "DescripcionLarga" },
                values: new object[] { "Hamburguesa vegetariana", "Hamburguesa vegetariana a base de lentejas y vegetales, con queso provolone, rúcula y tomates secos. Opción saludable y deliciosa." });

            migrationBuilder.InsertData(
                table: "descripcionProductos",
                columns: new[] { "Id", "DescripcionCorta", "DescripcionLarga" },
                values: new object[,]
                {
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

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Calorias",
                value: 550);

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calidad", "Calorias", "CategoriaId", "Nombre", "Precio" },
                values: new object[] { "Alta", 800, 1, "Hamburguesa Doble Bacon", 650 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calidad", "Calorias", "CategoriaId", "Nombre", "Precio" },
                values: new object[] { "Media", 400, 1, "Hamburguesa Vegetariana", 450 });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "Id", "Calidad", "Calorias", "CategoriaId", "DescripcionProductoId", "ImagenUrl", "Nombre", "Precio" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DescripcionCorta", "DescripcionLarga" },
                values: new object[] { "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.", "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa." });

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DescripcionCorta", "DescripcionLarga" },
                values: new object[] { "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.", "Sándwich de milanesa con tomate, lechuga y mayonesa en pan francés.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa." });

            migrationBuilder.UpdateData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DescripcionCorta", "DescripcionLarga" },
                values: new object[] { "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.", "Bebida gaseosa refrescante de 500 ml.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.lechuga, tomate y mayonesa." });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Calorias",
                value: 300);

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calidad", "Calorias", "CategoriaId", "Nombre", "Precio" },
                values: new object[] { "Media", 350, 2, "Sándwich de Milanesa", 450 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calidad", "Calorias", "CategoriaId", "Nombre", "Precio" },
                values: new object[] { "Alta", 150, 3, "Coca-Cola 500ml", 150 });
        }
    }
}
