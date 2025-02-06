using FoodMacanoServices.Enums;
using FoodMacanoServices.Models;
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
        public virtual DbSet<Usuario> usuarios { get; set; }
        public virtual DbSet<MauiEncargue> mauiEncargue { get; set; }
        public virtual DbSet<DesktopEncargue> desktopEncargues { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Hamburguesas", IconUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconHamburguesa.png?alt=media&token=b280cbd2-9016-4647-85e9-048858807010" },
                new Categoria { Id = 2, Nombre = "Sanguches" , IconUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconSandwich.png?alt=media&token=dc21b284-630e-4b54-9b93-1b4668f316f2" },
                new Categoria { Id = 3, Nombre = "Bebidas", IconUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconBebidas.png?alt=media&token=c87c60a9-215c-4a8f-8939-b3423e48a1c0" }
            );

            modelBuilder.Entity<DescripcionProducto>().HasData(
                new DescripcionProducto { Id = 1, DescripcionCorta = "Hamburguesa clásica de carne a la parrilla", DescripcionLarga = "Deliciosa hamburguesa de carne a la parrilla con queso cheddar, lechuga fresca, tomate jugoso y nuestra salsa especial en un pan suave y tostado." },
                new DescripcionProducto { Id = 2, DescripcionCorta = "Hamburguesa doble con bacon", DescripcionLarga = "Hamburguesa doble carne, doble queso y tiras de bacon crujiente. Acompañada de cebolla caramelizada y salsa barbacoa casera." },
                new DescripcionProducto { Id = 3, DescripcionCorta = "Hamburguesa vegetariana", DescripcionLarga = "Hamburguesa vegetariana a base de lentejas y vegetales, con queso provolone, rúcula y tomates secos. Opción saludable y deliciosa." },
                new DescripcionProducto { Id = 4, DescripcionCorta = "Hamburguesa de pollo", DescripcionLarga = "Jugosa hamburguesa de pollo a la parrilla con aguacate, lechuga y mayonesa de chipotle en pan integral." },
                new DescripcionProducto { Id = 5, DescripcionCorta = "Hamburguesa gourmet", DescripcionLarga = "Hamburguesa gourmet de carne Angus, queso azul, cebolla caramelizada y reducción de vino tinto en pan brioche." },
                new DescripcionProducto { Id = 6, DescripcionCorta = "Sándwich de milanesa clásico", DescripcionLarga = "Sándwich de milanesa de ternera con lechuga, tomate, queso y mayonesa en pan francés crujiente." },
                new DescripcionProducto { Id = 7, DescripcionCorta = "Sándwich de jamón y queso", DescripcionLarga = "Sándwich caliente de jamón y queso derretido en pan de miga tostado. Un clásico irresistible." },
                new DescripcionProducto { Id = 8, DescripcionCorta = "Sándwich de pollo", DescripcionLarga = "Sándwich de pechuga de pollo a la plancha con palta, tomate y lechuga en pan integral." },
                new DescripcionProducto { Id = 9, DescripcionCorta = "Sándwich vegetariano", DescripcionLarga = "Sándwich vegetariano con hummus, vegetales asados, queso de cabra y rúcula en pan de centeno." },
                new DescripcionProducto { Id = 10, DescripcionCorta = "Sándwich de lomito", DescripcionLarga = "Sándwich de lomito completo con lechuga, tomate, jamón, queso, huevo frito y mayonesa en pan ciabatta." },
                new DescripcionProducto { Id = 11, DescripcionCorta = "Coca-Cola", DescripcionLarga = "Refrescante Coca-Cola clásica en botella de 500ml. El sabor de siempre para acompañar tu comida." },
                new DescripcionProducto { Id = 12, DescripcionCorta = "Agua mineral", DescripcionLarga = "Agua mineral natural sin gas en botella de 500ml. Hidratación pura y refrescante." },
                new DescripcionProducto { Id = 13, DescripcionCorta = "Limonada casera", DescripcionLarga = "Limonada casera preparada con limones frescos, un toque de menta y endulzada con miel. Bebida refrescante de 500ml." },
                new DescripcionProducto { Id = 14, DescripcionCorta = "Cerveza artesanal", DescripcionLarga = "Cerveza artesanal tipo IPA en botella de 330ml. Sabor intenso y aromático con notas cítricas y tropicales." },
                new DescripcionProducto { Id = 15, DescripcionCorta = "Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.Hamburguesa de carne a la parrilla con queso, lechuga, tomate y mayonesa.", DescripcionLarga = "Smoothie natural de frutas mixtas (frutilla, banana y naranja) sin azúcar añadida. Vaso de 400ml." }
            );

            modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Hamburguesa Clásica", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", Precio = 500, Calidad = "Alta", Calorias = 550, CategoriaId = 1, DescripcionProductoId = 1 },
            new Producto { Id = 2, Nombre = "Hamburguesa Doble Bacon", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", Precio = 650, Calidad = "Alta", Calorias = 800, CategoriaId = 1, DescripcionProductoId = 2 },
            new Producto { Id = 3, Nombre = "Hamburguesa Vegetariana", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", Precio = 450, Calidad = "Media", Calorias = 400, CategoriaId = 1, DescripcionProductoId = 3 },
            new Producto { Id = 4, Nombre = "Hamburguesa de Pollo", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", Precio = 480, Calidad = "Media", Calorias = 450, CategoriaId = 1, DescripcionProductoId = 4 },
            new Producto { Id = 5, Nombre = "Hamburguesa Gourmet", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", Precio = 750, Calidad = "Premium", Calorias = 700, CategoriaId = 1, DescripcionProductoId = 5 },
            new Producto { Id = 6, Nombre = "Sándwich de Milanesa", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", Precio = 450, Calidad = "Media", Calorias = 600, CategoriaId = 2, DescripcionProductoId = 6 },
            new Producto { Id = 7, Nombre = "Sándwich Jamón y Queso", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", Precio = 350, Calidad = "Media", Calorias = 400, CategoriaId = 2, DescripcionProductoId = 7 },
            new Producto { Id = 8, Nombre = "Sándwich de Pollo", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", Precio = 400, Calidad = "Alta", Calorias = 450, CategoriaId = 2, DescripcionProductoId = 8 },
            new Producto { Id = 9, Nombre = "Sándwich Vegetariano", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", Precio = 380, Calidad = "Alta", Calorias = 350, CategoriaId = 2, DescripcionProductoId = 9 },
            new Producto { Id = 10, Nombre = "Sándwich de Lomito", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", Precio = 550, Calidad = "Premium", Calorias = 700, CategoriaId = 2, DescripcionProductoId = 10 },
            new Producto { Id = 11, Nombre = "Coca-Cola 500ml", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", Precio = 150, Calidad = "Alta", Calorias = 210, CategoriaId = 3, DescripcionProductoId = 11 },
            new Producto { Id = 12, Nombre = "Agua Mineral 500ml", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", Precio = 100, Calidad = "Alta", Calorias = 0, CategoriaId = 3, DescripcionProductoId = 12 },
            new Producto { Id = 13, Nombre = "Limonada Casera 500ml", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHambuerguesa.png?alt=media&token=03b62ad8-16e4-4b06-b595-28baf10de9a7", Precio = 200, Calidad = "Alta", Calorias = 120, CategoriaId = 3, DescripcionProductoId = 13 },
            new Producto { Id = 14, Nombre = "Cerveza Artesanal IPA 330ml", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FMilanesa.png?alt=media&token=89683de5-6f3d-4a17-be75-be0640e5906b", Precio = 300, Calidad = "Premium", Calorias = 180, CategoriaId = 3, DescripcionProductoId = 14 },
            new Producto { Id = 15, Nombre = "Smoothie de Frutas 400ml", ImagenUrl = "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPiza.png?alt=media&token=d52e606d-597c-4065-aed3-9ae33e633ab8", Precio = 250, Calidad = "Alta", Calorias = 200, CategoriaId = 3, DescripcionProductoId = 15 }
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
                    Nombre = "Food Macano",
                    Direccion = "Calle Falsa 123, Ciudad Ejemplo",
                    Telefono = "123456789",
                    Horario = "Lunes a Viernes: 11:00 - 23:00\nSábado: 11:00 - 00:00\nDomingo: 11:00 - 22:00",
                    MapaIframe = "<iframe class=\"map\" src=\"https://www.google.com/maps/place/Gdor.+Crespo,+Santa+Fe/@-30.3611856,-60.4003288,16z/data=!4m6!3m5!1s0x944b0554d0eb3903:0x7b078fba72f704b!8m2!3d-30.3620638!4d-60.4020713!16s%2Fg%2F120y82vp?entry=ttu&g_ep=EgoyMDI1MDEyOC4wIKXMDSoASAFQAw%3D%3D\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                    RedesSocialId = 1
                }
            );
        }
        
    }
}
