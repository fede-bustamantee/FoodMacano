//using FoodMacanoServices.Models;
//using FoodMacanoServices.Models.FoodMacanoServices.Models;
//using FoodMacanoServices.Services;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace FoodMacanoDesktop.Views.Productos
//{
//    public partial class PrimerCategoriaView : Form
//    {
//        private ProductoService productoService = new ProductoService();
//        private List<Producto> productos = new List<Producto>();
//        private List<CarritoCompra> carrito = new List<CarritoCompra>();
//        private CarritoComprasService carritoComprasService;
//        private decimal total = 0;

//        public PrimerCategoriaView()
//        {
//            InitializeComponent();
//            InitializeServices();
//            CargarProductosDeHamburguesa();
//            CargarCarritoDesdeApi();
//        }

//        private void InitializeServices()
//        {
//            var carritoService = new GenericService<CarritoCompra>();
//            var encargueService = new GenericService<Encargue>();
//            carritoComprasService = new CarritoComprasService(carritoService, encargueService, new HttpClient(), null);
//        }

//        private async void CargarProductosDeHamburguesa()
//        {
//            int hamburguesaCategoriaId = 1;
//            productos = await productoService.GetByCategoriaAsync(hamburguesaCategoriaId);

//            flowLayoutPanel1.Controls.Clear();
//            int panelWidth = 230, panelHeight = 200;

//            foreach (var producto in productos)
//            {
//                // Crear un nuevo panel para cada producto
//                Panel panelProducto = new Panel
//                {
//                    Size = new Size(panelWidth, panelHeight),
//                    Margin = new Padding(10),
//                    BackColor = Color.LightGray
//                };

//                // Label para el nombre del producto
//                Label lblNombre = new Label
//                {
//                    Text = producto.Nombre,
//                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
//                    Location = new Point(10, 10)
//                };

//                // Label para el precio del producto
//                Label lblPrecio = new Label
//                {
//                    Text = $"${producto.Precio}",
//                    Font = new Font("Segoe UI", 12F),
//                    Location = new Point(10, 40)
//                };

//                // PictureBox para la imagen del producto
//                PictureBox picImagen = new PictureBox
//                {
//                    Size = new Size(111, 99),
//                    Location = new Point(10, 70),
//                    SizeMode = PictureBoxSizeMode.StretchImage
//                };

//                // Cargar imagen del producto si está disponible
//                if (!string.IsNullOrEmpty(producto.ImagenUrl))
//                {
//                    picImagen.Load(producto.ImagenUrl);
//                }

//                // Agregar evento click para agregar producto al carrito
//                picImagen.Click += (s, e) => AgregarAlCarrito(producto);

//                // Agregar controles al panel del producto
//                panelProducto.Controls.Add(lblNombre);
//                panelProducto.Controls.Add(lblPrecio);
//                panelProducto.Controls.Add(picImagen);

//                // Agregar el panel del producto al FlowLayoutPanel
//                flowLayoutPanel1.Controls.Add(panelProducto);
//            }
//        }

//        private async Task CargarCarritoDesdeApi()
//        {
//            carrito = await carritoComprasService.GetCartItemsAsync();
//            total = carrito.Sum(item => item.Producto.Precio);
//            ActualizarVistaCarrito();
//        }

//        private void ActualizarVistaCarrito()
//        {
//            flowLayoutPanelCarrito.Controls.Clear();

//            foreach (var item in carrito)
//            {
//                var panelItemCarrito = new Panel
//                {
//                    Size = new Size(320, 40),
//                    BackColor = Color.LightGray,
//                    Margin = new Padding(5)
//                };

//                panelItemCarrito.Controls.Add(new Label
//                {
//                    Text = $"{item.Producto?.Nombre} x{item.Cantidad} - ${item.Producto?.Precio:F2}",
//                    Location = new Point(10, 10),
//                    Size = new Size(250, 20)
//                });

//                var btnEliminar = new Button
//                {
//                    Text = "X",
//                    Size = new Size(30, 30),
//                    Location = new Point(260, 5)
//                };

//                btnEliminar.Click += (s, e) => RemoverDelCarrito(item);
//                panelItemCarrito.Controls.Add(btnEliminar);
//                flowLayoutPanelCarrito.Controls.Add(panelItemCarrito);
//            }

//            txtTotal.Text = $"Total: ${total:F2}";
//        }

//        private async void AgregarAlCarrito(Producto producto)
//        {
//            await carritoComprasService.AddToCartAsync(producto);
//            var itemEnCarrito = carrito.Find(p => p.Producto?.Nombre == producto.Nombre);

//            if (itemEnCarrito != null)
//            {
//                // Si el producto ya está en el carrito, incrementa la cantidad
//                itemEnCarrito.Cantidad++;
//            }
//            else
//            {
//                // Si no está en el carrito, lo agrega con cantidad 1
//                carrito.Add(new CarritoCompra
//                {
//                    Producto = producto, // Asocia el producto completo
//                    Cantidad = 1
//                });
//            }

//            // Actualiza el total sumando el precio del producto añadido
//            total += producto.Precio;

//            // Refresca la vista del carrito
//            ActualizarVistaCarrito();
//        }


//        private async void RemoverDelCarrito(CarritoCompra item)
//        {
//            carrito.Remove(item);
//            await carritoComprasService.RemoveFromCartAsync(item.Id);
//            total -= item.Producto.Precio;
//            ActualizarVistaCarrito();
//        }

//        private async void btnEncargar_Click(object sender, EventArgs e)
//        {
//            await carritoComprasService.CheckoutAsync();
//            carrito.Clear();
//            total = 0;
//            ActualizarVistaCarrito();
//            MessageBox.Show("El encargo ha sido realizado exitosamente.", "Encargar", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }
//    }
//}
