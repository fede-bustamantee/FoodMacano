//using FoodMacanoDesktop.Views.Informaciones;
//using FoodMacanoServices.Models;
//using FoodMacanoServices.Models.FoodMacanoServices.Models;
//using FoodMacanoServices.Services;
//using System.Data;

//namespace FoodMacanoDesktop.Views.Productos
//{
//    public partial class TodosLosProductos : Form
//    {
//        private ProductoService productoService = new ProductoService();
//        private List<Producto> productos = new List<Producto>();
//        private List<CarritoCompra> carrito = new List<CarritoCompra>();
//        private CarritoComprasService carritoComprasService;

//        private decimal total = 0;

//        public TodosLosProductos()
//        {
//            InitializeComponent();
//            InitializeServices();
//            CargarDatosProductos();
//        }

//        private void InitializeServices()
//        {
//            var carritoService = new GenericService<CarritoCompra>();
//            var encargueService = new GenericService<Encargue>();
//            carritoComprasService = new CarritoComprasService(carritoService, encargueService, new HttpClient(), null);
//        }

//        private async void CargarDatosProductos()
//        {
//            productos = await productoService.GetAllAsync();
//            await CargarCarritoDesdeApi();
//            FiltrarProductos(""); // Mostrar todos los productos inicialmente
//        }

//        private async Task CargarCarritoDesdeApi()
//        {
//            carrito = await carritoComprasService.GetCartItemsAsync();
//            total = carrito.Sum(item => item.Producto.Precio);
//            ActualizarVistaCarrito();
//        }

//        private void FiltrarProductos(string filtro)
//        {
//            var productosFiltrados = productos
//                .Where(p => p.Nombre.ToLower().Contains(filtro))
//                .ToList();

//            flowLayoutPanel1.Controls.Clear();
//            int panelWidth = 155, panelHeight = 230; // Aumentamos el tamaño del panel para incluir los botones

//            foreach (var producto in productosFiltrados)
//            {
//                var panelProducto = new Panel
//                {
//                    Size = new Size(panelWidth, panelHeight),
//                    BackColor = Color.LightGray
//                };

//                panelProducto.Controls.Add(new Label
//                {
//                    Text = producto.Nombre,
//                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
//                    Location = new Point(10, 10)
//                });

//                panelProducto.Controls.Add(new Label
//                {
//                    Text = $"${producto.Precio}",
//                    Font = new Font("Segoe UI", 12F),
//                    Location = new Point(10, 40)
//                });

//                var picImagen = new PictureBox
//                {
//                    Size = new Size(111, 99),
//                    Location = new Point(10, 70),
//                    SizeMode = PictureBoxSizeMode.StretchImage
//                };

//                if (!string.IsNullOrEmpty(producto.ImagenUrl))
//                    picImagen.Load(producto.ImagenUrl);

//                panelProducto.Controls.Add(picImagen);

//                // Botón "+"
//                var btnAgregar = new Button
//                {
//                    Text = "+",
//                    Size = new Size(50, 30),
//                    Location = new Point(10, 180) // Debajo de la imagen
//                };
//                btnAgregar.Click += (s, e) => AgregarAlCarrito(producto);
//                panelProducto.Controls.Add(btnAgregar);

//                // Botón "Info"
//                var btnInfo = new Button
//                {
//                    Text = "Info",
//                    Size = new Size(50, 30),
//                    Location = new Point(80, 180) // Al lado del botón "+"
//                };
//                btnInfo.Click += (s, e) => AbrirInformacionProducto(producto);
//                panelProducto.Controls.Add(btnInfo);

//                flowLayoutPanel1.Controls.Add(panelProducto);
//            }
//        }

//        // Método para abrir la ventana InformacionesView
//        private void AbrirInformacionProducto(Producto producto)
//        {
//            var infoView = new InformacionesView(
//                producto.Nombre,
//                producto.ImagenUrl,
//                producto.DescripcionProducto?.DescripcionLarga ?? "Descripción no disponible"
//            );
//            infoView.ShowDialog();
//        }



//        private void txtBoxBuscar_TextChanged(object sender, EventArgs e)
//        {
//            var textoFiltro = txtBoxBuscar.Text.Trim().ToLower();
//            FiltrarProductos(textoFiltro);
//        }

//        private async void AgregarAlCarrito(Producto producto)
//        {
//            await carritoComprasService.AddToCartAsync(producto);
//            var itemEnCarrito = carrito.Find(p => p.Producto?.Nombre == producto.Nombre);

//            if (itemEnCarrito != null)
//            {
//                itemEnCarrito.Cantidad++;
//            }
//            else
//            {
//                carrito.Add(new CarritoCompra
//                {
//                    Producto = producto,
//                    Cantidad = 1
//                });
//            }

//            total += producto.Precio;
//            ActualizarVistaCarrito();
//        }

//        private void ActualizarVistaCarrito()
//        {
//            flowLayoutPanel2.Controls.Clear();

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
//                flowLayoutPanel2.Controls.Add(panelItemCarrito);
//            }

//            txtTotal.Text = $"Total: ${total:F2}";
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
//            // Realiza el encargo usando el servicio
//            await carritoComprasService.CheckoutAsync();

//            // Limpiar la lista de carrito en la interfaz
//            carrito.Clear();
//            total = 0;

//            // Actualiza la vista del carrito
//            ActualizarVistaCarrito();

//            // Puedes mostrar un mensaje de confirmación al usuario
//            MessageBox.Show("El encargo ha sido realizado exitosamente.", "Encargar", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }
//    }
//}
