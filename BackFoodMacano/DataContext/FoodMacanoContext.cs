using FoodMacanoServices.Enums;
using FoodMacanoServices.Models;
using FoodMacanoServices.Models.Cart;
using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace BackFoodMacano.DataContext
{
    public class FoodMacanoContext : DbContext
    {
        public FoodMacanoContext(DbContextOptions<FoodMacanoContext> options) : base(options)
        {
        }

        #region DbSet
        public virtual DbSet<Producto> productos { get; set; }
        public virtual DbSet<Categoria> categorias { get; set; }
        public virtual DbSet<DescripcionProducto> descripcionProductos { get; set; }
        public virtual DbSet<Negocio> negocios { get; set; }
        public virtual DbSet<RedesSocial> redesSociales { get; set; }
        public virtual DbSet<CarritoCompra> carritoCompra { get; set; }
        public virtual DbSet<Encargue> encargues { get; set; }
        public virtual DbSet<EncargueDetalle> encargueDetalles { get; set; }
        public virtual DbSet<Usuario> usuarios { get; set; }
        public virtual DbSet<MauiEncargue> mauiEncargue { get; set; }
        public virtual DbSet<DesktopEncargue> desktopEncargues { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Hamburguesas", IconUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconHamburguesa.png?alt=media&token=b280cbd2-9016-4647-85e9-048858807010" },
                new Categoria { Id = 2, Nombre = "Sanguches", IconUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconSandwich.png?alt=media&token=dc21b284-630e-4b54-9b93-1b4668f316f2" },
                new Categoria { Id = 3, Nombre = "Bebidas", IconUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconBebidas.png?alt=media&token=c87c60a9-215c-4a8f-8939-b3423e48a1c0" },
                new Categoria { Id = 4, Nombre = "Pizzas", IconUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2Fpizza.png?alt=media&token=fcc39a34-2c50-448a-bfa1-81a28fca2dfb" }
                );

            modelBuilder.Entity<DescripcionProducto>().HasData(
                // Hamburguesas (1-5)
                new DescripcionProducto { Id = 1, DescripcionCorta = "Hamburguesa clásica con carne premium y vegetales frescos", DescripcionLarga = "Deliciosa hamburguesa de carne a la parrilla con queso cheddar, lechuga fresca, tomate jugoso y nuestra salsa especial en un pan suave y tostado." },
                new DescripcionProducto { Id = 2, DescripcionCorta = "Hamburguesa doble con bacon y queso", DescripcionLarga = "Hamburguesa doble carne, doble queso y tiras de bacon crujiente. Acompañada de cebolla caramelizada y salsa barbacoa casera." },
                new DescripcionProducto { Id = 3, DescripcionCorta = "Hamburguesa de carne Angus con cheddar", DescripcionLarga = "Jugosa hamburguesa de carne Angus premium con queso cheddar derretido, pepinillos, cebolla y salsa especial de la casa." },
                new DescripcionProducto { Id = 4, DescripcionCorta = "Hamburguesa mexicana picante", DescripcionLarga = "Hamburguesa con carne sazonada con especias mexicanas, jalapeños, guacamole, queso pepper jack y salsa picante casera." },
                new DescripcionProducto { Id = 5, DescripcionCorta = "Hamburguesa gourmet con queso azul", DescripcionLarga = "Hamburguesa gourmet de carne Angus, queso azul, cebolla caramelizada, rúcula fresca y reducción de vino tinto en pan brioche." },

                // Sanguches (6-10)
                new DescripcionProducto { Id = 6, DescripcionCorta = "Sándwich de milanesa completo", DescripcionLarga = "Sándwich de milanesa de ternera con lechuga, tomate, queso, jamón y mayonesa en pan francés crujiente." },
                new DescripcionProducto { Id = 7, DescripcionCorta = "Sándwich de lomito premium", DescripcionLarga = "Sándwich de lomito completo con lechuga, tomate, jamón, queso, huevo frito y mayonesa en pan ciabatta." },
                new DescripcionProducto { Id = 8, DescripcionCorta = "Sándwich de milanesa con queso", DescripcionLarga = "Sándwich de milanesa con queso derretido, lechuga fresca, tomate y salsa tártara casera en pan de campo." },
                new DescripcionProducto { Id = 9, DescripcionCorta = "Sándwich club premium", DescripcionLarga = "Sándwich club de tres pisos con pollo grillado, bacon crujiente, huevo, lechuga, tomate y mayonesa casera." },
                new DescripcionProducto { Id = 10, DescripcionCorta = "Sándwich de lomo completo", DescripcionLarga = "Sándwich de lomo completo con queso derretido, huevo frito, jamón, lechuga, tomate y salsa especial en pan ciabatta." },

                // Bebidas (11-15)
                new DescripcionProducto { Id = 11, DescripcionCorta = "Agua mineral sin gas 500ml", DescripcionLarga = "Agua mineral natural sin gas en botella de 500ml. Hidratación pura y refrescante." },
                new DescripcionProducto { Id = 12, DescripcionCorta = "Coca-Cola original 500ml", DescripcionLarga = "Refrescante Coca-Cola clásica en botella de 500ml. El sabor de siempre para acompañar tu comida." },
                new DescripcionProducto { Id = 13, DescripcionCorta = "Cóctel especial de la casa", DescripcionLarga = "Cóctel exclusivo preparado con frutas frescas, licores premium y un toque secreto que lo hace único. Servido en vaso de 350ml." },
                new DescripcionProducto { Id = 14, DescripcionCorta = "Limonada casera con menta", DescripcionLarga = "Limonada casera preparada con limones frescos, un toque de menta y endulzada con miel. Bebida refrescante de 500ml." },
                new DescripcionProducto { Id = 15, DescripcionCorta = "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.", DescripcionLarga = "Smoothie natural de frutas mixtas (frutilla, banana y naranja) sin azúcar añadida. Vaso de 400ml." },

                // Pizzas (16-20)
                new DescripcionProducto { Id = 16, DescripcionCorta = "Pizza Muzzarella tradicional", DescripcionLarga = "Pizza con abundante queso muzzarella, salsa de tomate casera y orégano fresco. Masa a la piedra crujiente por fuera y tierna por dentro." },
                new DescripcionProducto { Id = 17, DescripcionCorta = "Pizza Pepperoni", DescripcionLarga = "Pizza con salsa de tomate, queso muzzarella y generosa cantidad de pepperoni picante. Una combinación clásica y deliciosa." },
                new DescripcionProducto { Id = 18, DescripcionCorta = "Pizza Cuatro Quesos", DescripcionLarga = "Pizza gourmet con selección de cuatro quesos: muzzarella, provolone, parmesano y queso azul. Una explosión de sabores para los amantes del queso." },
                new DescripcionProducto { Id = 19, DescripcionCorta = "Pizza Napolitana", DescripcionLarga = "Pizza clásica napolitana con salsa de tomate, muzzarella, rodajas de tomate fresco, ajo y albahaca. Un homenaje a la tradición italiana." },
                new DescripcionProducto { Id = 20, DescripcionCorta = "Pizza Especial de la Casa", DescripcionLarga = "Pizza con salsa de tomate, muzzarella, jamón, morrones, aceitunas, huevo y orégano. La especialidad más completa y sabrosa." }
            );

            modelBuilder.Entity<Producto>().HasData(
                // Hamburguesas
                new Producto { Id = 1, Nombre = "Hamburguesa Clásica", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhabur.png?alt=media&token=036cfd9a-89b9-44a0-b97f-c87af5398706", Precio = 4200, Calidad = "Alta", Calorias = 550, CategoriaId = 1, DescripcionProductoId = 1 },
                new Producto { Id = 2, Nombre = "Hamburguesa Doble Bacon", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2FHaburquesoo.png?alt=media&token=21d2b902-5f75-49cb-aa0d-7b91555ab1b3", Precio = 5500, Calidad = "Premium", Calorias = 800, CategoriaId = 1, DescripcionProductoId = 2 },
                new Producto { Id = 3, Nombre = "Hamburguesa Angus", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhamurchedarr.png?alt=media&token=a6716fc2-965a-4b63-9e06-16ef5b3e194f", Precio = 6300, Calidad = "Premium", Calorias = 720, CategoriaId = 1, DescripcionProductoId = 3 },
                new Producto { Id = 4, Nombre = "Hamburguesa Mexicana", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhabur.png?alt=media&token=036cfd9a-89b9-44a0-b97f-c87af5398706", Precio = 5800, Calidad = "Alta", Calorias = 680, CategoriaId = 1, DescripcionProductoId = 4 },
                new Producto { Id = 5, Nombre = "Hamburguesa Gourmet", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2FHaburquesoo.png?alt=media&token=21d2b902-5f75-49cb-aa0d-7b91555ab1b3", Precio = 7900, Calidad = "Premium", Calorias = 750, CategoriaId = 1, DescripcionProductoId = 5 },

                // Sanguches
                new Producto { Id = 6, Nombre = "Sándwich de Milanesa Completo", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmila.png?alt=media&token=9fc4685f-2fd1-41cb-a707-bfe7b35e4bb5", Precio = 4700, Calidad = "Alta", Calorias = 600, CategoriaId = 2, DescripcionProductoId = 6 },
                new Producto { Id = 7, Nombre = "Sándwich de Lomito Premium", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaquee.png?alt=media&token=46ea6c8d-fe58-469f-9c4e-0646cdaa5a4f", Precio = 6800, Calidad = "Premium", Calorias = 720, CategoriaId = 2, DescripcionProductoId = 7 },
                new Producto { Id = 8, Nombre = "Sándwich Milanesa con Queso", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaeslomm.png?alt=media&token=5312dcbb-3365-40e3-87d1-92ce5ce7056c", Precio = 5100, Calidad = "Alta", Calorias = 590, CategoriaId = 2, DescripcionProductoId = 8 },
                new Producto { Id = 9, Nombre = "Sándwich Club", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmila.png?alt=media&token=9fc4685f-2fd1-41cb-a707-bfe7b35e4bb5", Precio = 5600, Calidad = "Alta", Calorias = 650, CategoriaId = 2, DescripcionProductoId = 9 },
                new Producto { Id = 10, Nombre = "Sándwich de Lomo Completo", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaquee.png?alt=media&token=46ea6c8d-fe58-469f-9c4e-0646cdaa5a4f", Precio = 7200, Calidad = "Premium", Calorias = 780, CategoriaId = 2, DescripcionProductoId = 10 },

                // Bebidas
                new Producto { Id = 11, Nombre = "Agua Mineral 500ml", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcocaa.png?alt=media&token=46e172b8-a890-49dc-b2d6-841e327c6fda", Precio = 4100, Calidad = "Alta", Calorias = 0, CategoriaId = 3, DescripcionProductoId = 11 },
                new Producto { Id = 12, Nombre = "Coca-Cola 500ml", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Faguaa.png?alt=media&token=b9677456-0259-47c6-91ec-8f33136c9ab8", Precio = 4300, Calidad = "Alta", Calorias = 210, CategoriaId = 3, DescripcionProductoId = 12 },
                new Producto { Id = 13, Nombre = "Cóctel Especial", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcoptell.png?alt=media&token=4b440890-37ca-4bae-aadc-3e8656d22940", Precio = 5800, Calidad = "Premium", Calorias = 180, CategoriaId = 3, DescripcionProductoId = 13 },
                new Producto { Id = 14, Nombre = "Limonada Casera", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcocaa.png?alt=media&token=46e172b8-a890-49dc-b2d6-841e327c6fda", Precio = 4600, Calidad = "Alta", Calorias = 120, CategoriaId = 3, DescripcionProductoId = 14 },
                new Producto { Id = 15, Nombre = "Smoothie de Frutas", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Faguaa.png?alt=media&token=b9677456-0259-47c6-91ec-8f33136c9ab8", Precio = 4900, Calidad = "Alta", Calorias = 200, CategoriaId = 3, DescripcionProductoId = 15 },

                // Pizzas
                new Producto { Id = 16, Nombre = "Pizza Muzzarella", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizamitaa.png?alt=media&token=c0a6c4ba-d232-4fe6-9ce7-f8d9a21ffdaa", Precio = 5200, Calidad = "Alta", Calorias = 850, CategoriaId = 4, DescripcionProductoId = 16 },
                new Producto { Id = 17, Nombre = "Pizza Pepperoni", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizappp.png?alt=media&token=d2d21eb8-bd62-4593-a64c-dfe2b5676244", Precio = 6100, Calidad = "Alta", Calorias = 920, CategoriaId = 4, DescripcionProductoId = 17 },
                new Producto { Id = 18, Nombre = "Pizza Cuatro Quesos", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizas.png?alt=media&token=6e337a8e-bf33-40db-ba97-02c1c0e3ef7c", Precio = 6800, Calidad = "Premium", Calorias = 980, CategoriaId = 4, DescripcionProductoId = 18 },
                new Producto { Id = 19, Nombre = "Pizza Napolitana", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizamitaa.png?alt=media&token=c0a6c4ba-d232-4fe6-9ce7-f8d9a21ffdaa", Precio = 5700, Calidad = "Alta", Calorias = 880, CategoriaId = 4, DescripcionProductoId = 19 },
                new Producto { Id = 20, Nombre = "Pizza Especial", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizappp.png?alt=media&token=d2d21eb8-bd62-4593-a64c-dfe2b5676244", Precio = 7500, Calidad = "Premium", Calorias = 1050, CategoriaId = 4, DescripcionProductoId = 20 }
            );

            modelBuilder.Entity<RedesSocial>().HasData(
            new RedesSocial
            {
                Id = 1,
                Instagram = "https://www.instagram.com",
                Facebook = "https://www.facebook.com",
                Whatsapp = "https://wa.me/543498409675"
            }
            );

            // Configuración en el DbContext
            modelBuilder.Entity<Negocio>().HasData(
                new Negocio
                {
                    Id = 1,
                    Nombre = "Food Macano, Restaurante 03",
                    Direccion = "San Martín 329, Calchaquí",
                    Telefono = "3498756569",
                    Horario = "Lunes a Viernes: 11:00 - 23:00\nSábado: 11:00 - 00:00\nDomingo: 11:00 - 22:00",
                    MapaIframe = "<iframe \r\n    src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d27671.94929510676!2d-60.304126219719706!3d-29.893283243730366!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944bbec37fa30239%3A0x363b55a9e714bf24!2sCalchaqu%C3%AD%2C%20Santa%20Fe!5e0!3m2!1ses-419!2sar!4v1740862222458!5m2!1ses-419!2sar\" \r\n    width=\"100%\" \r\n    height=\"450\" \r\n    style=\"border:0;\" \r\n    allowfullscreen=\"\" \r\n    loading=\"lazy\" \r\n    referrerpolicy=\"no-referrer-when-downgrade\">\r\n</iframe>\r\n",
                    RedesSocialId = 1
                }
            );
        }
        
    }
}
