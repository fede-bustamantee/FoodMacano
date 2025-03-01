using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class actualizac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "Id", "IconUrl", "Nombre" },
                values: new object[,]
                {
                    { 1, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconHamburguesa.png?alt=media&token=b280cbd2-9016-4647-85e9-048858807010", "Hamburguesas" },
                    { 2, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconSandwich.png?alt=media&token=dc21b284-630e-4b54-9b93-1b4668f316f2", "Sanguches" },
                    { 3, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconBebidas.png?alt=media&token=c87c60a9-215c-4a8f-8939-b3423e48a1c0", "Bebidas" },
                    { 4, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2Fpizza.png?alt=media&token=fcc39a34-2c50-448a-bfa1-81a28fca2dfb", "Pizzas" }
                });

            migrationBuilder.InsertData(
                table: "descripcionProductos",
                columns: new[] { "Id", "DescripcionCorta", "DescripcionLarga" },
                values: new object[,]
                {
                    { 1, "Hamburguesa clásica con carne premium y vegetales frescos", "Deliciosa hamburguesa de carne a la parrilla con queso cheddar, lechuga fresca, tomate jugoso y nuestra salsa especial en un pan suave y tostado." },
                    { 2, "Hamburguesa doble con bacon y queso", "Hamburguesa doble carne, doble queso y tiras de bacon crujiente. Acompañada de cebolla caramelizada y salsa barbacoa casera." },
                    { 3, "Hamburguesa de carne Angus con cheddar", "Jugosa hamburguesa de carne Angus premium con queso cheddar derretido, pepinillos, cebolla y salsa especial de la casa." },
                    { 4, "Hamburguesa mexicana picante", "Hamburguesa con carne sazonada con especias mexicanas, jalapeños, guacamole, queso pepper jack y salsa picante casera." },
                    { 5, "Hamburguesa gourmet con queso azul", "Hamburguesa gourmet de carne Angus, queso azul, cebolla caramelizada, rúcula fresca y reducción de vino tinto en pan brioche." },
                    { 6, "Sándwich de milanesa completo", "Sándwich de milanesa de ternera con lechuga, tomate, queso, jamón y mayonesa en pan francés crujiente." },
                    { 7, "Sándwich de lomito premium", "Sándwich de lomito completo con lechuga, tomate, jamón, queso, huevo frito y mayonesa en pan ciabatta." },
                    { 8, "Sándwich de milanesa con queso", "Sándwich de milanesa con queso derretido, lechuga fresca, tomate y salsa tártara casera en pan de campo." },
                    { 9, "Sándwich club premium", "Sándwich club de tres pisos con pollo grillado, bacon crujiente, huevo, lechuga, tomate y mayonesa casera." },
                    { 10, "Sándwich de lomo completo", "Sándwich de lomo completo con queso derretido, huevo frito, jamón, lechuga, tomate y salsa especial en pan ciabatta." },
                    { 11, "Agua mineral sin gas 500ml", "Agua mineral natural sin gas en botella de 500ml. Hidratación pura y refrescante." },
                    { 12, "Coca-Cola original 500ml", "Refrescante Coca-Cola clásica en botella de 500ml. El sabor de siempre para acompañar tu comida." },
                    { 13, "Cóctel especial de la casa", "Cóctel exclusivo preparado con frutas frescas, licores premium y un toque secreto que lo hace único. Servido en vaso de 350ml." },
                    { 14, "Limonada casera con menta", "Limonada casera preparada con limones frescos, un toque de menta y endulzada con miel. Bebida refrescante de 500ml." },
                    { 15, "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.", "Smoothie natural de frutas mixtas (frutilla, banana y naranja) sin azúcar añadida. Vaso de 400ml." },
                    { 16, "Pizza Muzzarella tradicional", "Pizza con abundante queso muzzarella, salsa de tomate casera y orégano fresco. Masa a la piedra crujiente por fuera y tierna por dentro." },
                    { 17, "Pizza Pepperoni", "Pizza con salsa de tomate, queso muzzarella y generosa cantidad de pepperoni picante. Una combinación clásica y deliciosa." },
                    { 18, "Pizza Cuatro Quesos", "Pizza gourmet con selección de cuatro quesos: muzzarella, provolone, parmesano y queso azul. Una explosión de sabores para los amantes del queso." },
                    { 19, "Pizza Napolitana", "Pizza clásica napolitana con salsa de tomate, muzzarella, rodajas de tomate fresco, ajo y albahaca. Un homenaje a la tradición italiana." },
                    { 20, "Pizza Especial de la Casa", "Pizza con salsa de tomate, muzzarella, jamón, morrones, aceitunas, huevo y orégano. La especialidad más completa y sabrosa." }
                });

            migrationBuilder.InsertData(
                table: "redesSociales",
                columns: new[] { "Id", "Facebook", "Instagram", "Whatsapp" },
                values: new object[] { 1, "https://www.facebook.com", "https://www.instagram.com", "https://wa.me/543498409675" });

            migrationBuilder.InsertData(
                table: "negocios",
                columns: new[] { "Id", "Direccion", "Horario", "MapaIframe", "Nombre", "RedesSocialId", "Telefono" },
                values: new object[,]
                {
                    { 1, "San Martín 329, Calchaquí", "Lunes a Viernes: 11:00 - 23:00\nSábado: 11:00 - 00:00\nDomingo: 11:00 - 22:00", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3459.2046380850775!2d-60.286982767738394!3d-29.887203614077283!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944bbec37fa30239%3A0x363b55a9e714bf24!2sCalchaqu%C3%AD%2C%20Santa%20Fe!5e0!3m2!1ses-419!2sar!4v1740498914063!5m2!1ses-419!2sar\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Food Macano, Restaurante 03", 1, "3498756569" },
                    { 2, "Belgrano 329, Gobernador Crespo", "Lunes a Viernes: 11:00 - 23:00\nSábado: 11:00 - 00:00\nDomingo: 11:00 - 22:00", "<iframe class=\"map\" src=\"https://www.google.com/maps/place/Gdor.+Crespo,+Santa+Fe/@-30.3611856,-60.4003288,16z/data=!4m6!3m5!1s0x944b0554d0eb3903:0x7b078fba72f704b!8m2!3d-30.3620638!4d-60.4020713!16s%2Fg%2F120y82vp?entry=ttu&g_ep=EgoyMDI1MDEyOC4wIKXMDSoASAFQAw%3D%3D\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Food Macano, Restaurante 01", 1, "3498756567" },
                    { 3, "San Juan 329, Vera y Pintado", "Lunes a Viernes: 11:00 - 23:00\nSábado: 11:00 - 00:00\nDomingo: 11:00 - 22:00", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d6900.601861528618!2d-60.34531971028043!3d-30.142811221417357!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944ba702b3cb97c3%3A0xfab9b5972c337c1b!2sVera%20y%20Pintado%2C%20Santa%20Fe!5e0!3m2!1ses-419!2sar!4v1740498816032!5m2!1ses-419!2sar\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Food Macano, Restaurante 02", 1, "3498756569" }
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "Id", "Calidad", "Calorias", "CategoriaId", "DescripcionProductoId", "ImagenUrl", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Alta", 550, 1, 1, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2FHaburqueso.png?alt=media&token=0c9d6309-e1df-4a6c-ae52-4af835a1a291", "Hamburguesa Clásica", 4200 },
                    { 2, "Premium", 800, 1, 2, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhabur.png?alt=media&token=d43a0f98-591d-4325-b410-299dbb2da279", "Hamburguesa Doble Bacon", 5500 },
                    { 3, "Premium", 720, 1, 3, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhamurchedar.png?alt=media&token=b8c4f465-7b9f-46fa-b3c2-c7c035fff6a3", "Hamburguesa Angus", 6300 },
                    { 4, "Alta", 680, 1, 4, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2FHaburqueso.png?alt=media&token=0c9d6309-e1df-4a6c-ae52-4af835a1a291", "Hamburguesa Mexicana", 5800 },
                    { 5, "Premium", 750, 1, 5, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhabur.png?alt=media&token=d43a0f98-591d-4325-b410-299dbb2da279", "Hamburguesa Gourmet", 7900 },
                    { 6, "Alta", 600, 2, 6, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmila.png?alt=media&token=9fc4685f-2fd1-41cb-a707-bfe7b35e4bb5", "Sándwich de Milanesa Completo", 4700 },
                    { 7, "Premium", 720, 2, 7, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaeslom.png?alt=media&token=7b4c522e-3473-483c-9cb8-9a66fe59c83a", "Sándwich de Lomito Premium", 6800 },
                    { 8, "Alta", 590, 2, 8, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaque.jpg?alt=media&token=70219250-edd3-43ec-aed2-52a189d45c00", "Sándwich Milanesa con Queso", 5100 },
                    { 9, "Alta", 650, 2, 9, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmila.png?alt=media&token=9fc4685f-2fd1-41cb-a707-bfe7b35e4bb5", "Sándwich Club", 5600 },
                    { 10, "Premium", 780, 2, 10, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaeslom.png?alt=media&token=7b4c522e-3473-483c-9cb8-9a66fe59c83a", "Sándwich de Lomo Completo", 7200 },
                    { 11, "Alta", 0, 3, 11, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fagua.jpg?alt=media&token=d18faac5-b227-43e4-aa5a-5bf6fdfce40f", "Agua Mineral 500ml", 4100 },
                    { 12, "Alta", 210, 3, 12, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcoca.jpeg?alt=media&token=d364cef2-8a4d-4756-83b3-adb1bb259c22", "Coca-Cola 500ml", 4300 },
                    { 13, "Premium", 180, 3, 13, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcoptel.png?alt=media&token=1f8e271a-efeb-4f70-9f5f-ee00a2a27e8f", "Cóctel Especial", 5800 },
                    { 14, "Alta", 120, 3, 14, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fagua.jpg?alt=media&token=d18faac5-b227-43e4-aa5a-5bf6fdfce40f", "Limonada Casera", 4600 },
                    { 15, "Alta", 200, 3, 15, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcoca.jpeg?alt=media&token=d364cef2-8a4d-4756-83b3-adb1bb259c22", "Smoothie de Frutas", 4900 },
                    { 16, "Alta", 850, 4, 16, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizamita.png?alt=media&token=5acd1c05-40ab-4447-af38-2874e93540e4", "Pizza Muzzarella", 5200 },
                    { 17, "Alta", 920, 4, 17, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizapp.jpeg?alt=media&token=1a33825e-b383-4b66-a5d5-9f3ad98977fe", "Pizza Pepperoni", 6100 },
                    { 18, "Premium", 980, 4, 18, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizaques.avif?alt=media&token=c31eacc9-9f21-403b-be71-b6a0df74a858", "Pizza Cuatro Quesos", 6800 },
                    { 19, "Alta", 880, 4, 19, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizas.png?alt=media&token=6e337a8e-bf33-40db-ba97-02c1c0e3ef7c", "Pizza Napolitana", 5700 },
                    { 20, "Premium", 1050, 4, 20, "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizamita.png?alt=media&token=5acd1c05-40ab-4447-af38-2874e93540e4", "Pizza Especial", 7500 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "productos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "descripcionProductos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "redesSociales",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
