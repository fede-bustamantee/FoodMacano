using FoodMacanoDesktop.Controls;
using FoodMacanoDesktop.Views.Informaciones;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System.Data;

namespace FoodMacanoDesktop.Views.Productos
{
    public partial class TodosLosProductos : Form
    {
        private ProductoService productoService = new ProductoService();
        private List<Producto> productos = new List<Producto>();
        private CarritoControl carritoControl;

        public TodosLosProductos()
        {
            InitializeComponent();
            CargarDatosProductos();

            // Inicializar carrito
            carritoControl = new CarritoControl();
            Controls.Add(carritoControl);
        }

        private async void CargarDatosProductos()
        {
            productos = await productoService.GetAllAsync();
            FiltrarProductos(""); // Mostrar todos los productos al inicio
        }

        private void FiltrarProductos(string filtro)
        {
            var productosFiltrados = productos
            .Where(p => p.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                       (p.DescripcionProducto?.DescripcionLarga?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false))
            .ToList();

            flowLayoutPanel1.Controls.Clear();
            int panelWidth = 155, panelHeight = 230;

            foreach (var producto in productosFiltrados)
            {
                var panelProducto = new Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    BackColor = Color.LightGray
                };

                panelProducto.Controls.Add(new Label
                {
                    Text = producto.Nombre,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                });

                panelProducto.Controls.Add(new Label
                {
                    Text = $"${producto.Precio:F2}",
                    Font = new Font("Segoe UI", 12F),
                    Location = new Point(10, 40),
                    AutoSize = true
                });

                var picImagen = new PictureBox
                {
                    Size = new Size(111, 99),
                    Location = new Point(10, 70),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                try
                {
                    if (!string.IsNullOrEmpty(producto.ImagenUrl))
                        picImagen.Load(producto.ImagenUrl);
                }
                catch
                {
                    picImagen.BackColor = Color.Gray;
                }

                panelProducto.Controls.Add(picImagen);

                var btnAgregar = new Button
                {
                    Text = "+",
                    Size = new Size(50, 30),
                    Location = new Point(10, 180)
                };
                btnAgregar.Click += (s, e) => AgregarAlCarrito(producto);
                panelProducto.Controls.Add(btnAgregar);

                var btnInfo = new Button
                {
                    Text = "Info",
                    Size = new Size(50, 30),
                    Location = new Point(80, 180)
                };
                btnInfo.Click += (s, e) => AbrirInformacionProducto(producto);
                panelProducto.Controls.Add(btnInfo);

                flowLayoutPanel1.Controls.Add(panelProducto);
            }
        }

        private void AbrirInformacionProducto(Producto producto)
        {
            var infoView = new InformacionesView(
                producto.Nombre,
                producto.ImagenUrl,
                producto.DescripcionProducto?.DescripcionLarga ?? "Descripción no disponible"
            );
            infoView.ShowDialog();
        }

        private void AgregarAlCarrito(Producto producto)
        {
            carritoControl.AgregarProducto(producto);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();
        }
        private void RealizarBusqueda()
        {
            string textoBusqueda = txtBoxBuscar.Text.Trim();
            FiltrarProductos(textoBusqueda);
        }
    }
}