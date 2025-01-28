namespace FoodMacanoServices.Class
{
    public class ApiEndPoints
    {
        public static string Producto { get; set; } = "productos";
        public static string Categoria { get; set; } = "categorias";
        public static string DescripcionProducto { get; set; } = "descripcionproductos";
        public static string Product { get; set; } = "productos/aleatorios";
        public static string Negocio { get; set; } = "negocios";
        public static string RedesSocial { get; set; } = "redesociales";
        public static string CarritoCompra { get; set; } = "carritocompras";
        public static string Encargue { get; set; } = "encargues";
        public static string Usuario { get; set; } = "usuarios";
        public static string MauiEncargue { get; set; } = "mauiencargues";



        public static string GetEndpoint(string name)
        {
            return name switch
            {
                nameof(Producto) => Producto,
                nameof(Categoria) => Categoria,
                nameof(DescripcionProducto) => DescripcionProducto,
                nameof(Product) => Product,
                nameof(Negocio) => Negocio,
                nameof(RedesSocial) => RedesSocial,
                nameof(CarritoCompra) => CarritoCompra,
                nameof(Encargue) => Encargue,
                nameof(Usuario) => Usuario,
                nameof(MauiEncargue) => MauiEncargue,


                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }
    }
}

