using FoodMacanoDesktop.Controls;
using FoodMacanoDesktop.Views.Informaciones;
using FoodMacanoDesktop.Views.Menu;
using FoodMacanoDesktop.Views.ShowInActivity;
using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Services.Common;
using System.Data;

namespace FoodMacanoDesktop.Views.Productos
{
    public partial class TodosLosProductos : Form
    {
        private ProductoService productoService = new ProductoService();

        private List<Producto> productos = new List<Producto>();

        // Control del carrito de compras para gestionar los productos agregados.
        private CarritoControl carritoControl;

        public TodosLosProductos()
        {
            InitializeComponent();
            CargarDatosProductos();

            // Inicializa y agrega el control del carrito de compras a la vista.
            carritoControl = new CarritoControl();
            Controls.Add(carritoControl);
        }
        private async void CargarDatosProductos()
        {
            // Muestra el indicador de carga mientras se obtienen los productos.
            var loadingForm = new ActivityView();
            loadingForm.Message = "Cargando productos...";
            loadingForm.Show();

            try
            {
                productos = await productoService.GetAllAsync(); // Obtiene los productos.
                FiltrarProductos("");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingForm.Close(); // Cierra el indicador de carga cuando la operación termina.
            }
        }
        private void FiltrarProductos(string filtro)
        {
            // Filtra productos según su nombre o descripción.
            var productosFiltrados = productos
            .Where(p =>
            p.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) || // Verifica si el nombre del producto contiene el texto de búsqueda (ignorando mayúsculas y minúsculas).
            (p.DescripcionProducto?.DescripcionLarga?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) // Si la descripción larga existe, verifica si contiene el texto de búsqueda. Si es null, devuelve false.
            )
            .ToList();

            flowLayoutPanel1.Controls.Clear(); // Limpia los productos mostrados anteriormente.

            int panelWidth = 170, panelHeight = 230;

            foreach (var producto in productosFiltrados) // Recorremos la lista de productos filtrados.
            {
                // Crea un panel para representar cada producto visualmente.
                var panelProducto = new Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    BackColor = Color.LightGray 
                };

                // Etiqueta para mostrar el nombre del producto con un tamaño y estilo definidos.
                var labelNombre = new Label
                {
                    Text = producto.Nombre,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Location = new Point(10, 10), 
                    Size = new Size(135, 25), 
                    AutoEllipsis = true 
                };
                panelProducto.Controls.Add(labelNombre); // Se agrega la etiqueta al panel.

                // Etiqueta para mostrar el precio del producto con formato de dos decimales.
                panelProducto.Controls.Add(new Label
                {
                    Text = $"${producto.Precio:F2}",
                    Font = new Font("Segoe UI", 12F), 
                    Location = new Point(10, 40), 
                    AutoSize = true 
                });

                // Imagen del producto.
                var picImagen = new PictureBox
                {
                    Size = new Size(111, 99),
                    Location = new Point(10, 70),
                    SizeMode = PictureBoxSizeMode.StretchImage 
                };

                // Intenta cargar la imagen del producto desde la URL proporcionada.
                try
                {
                    if (!string.IsNullOrEmpty(producto.ImagenUrl)) // Verifica si la URL no está vacía.
                        picImagen.Load(producto.ImagenUrl);
                }
                catch
                {
                    picImagen.BackColor = Color.Gray;
                }
                panelProducto.Controls.Add(picImagen); // Agrega la imagen al panel.

                // Botón para agregar el producto al carrito con efecto hover.
                var btnAgregar = new Button
                {
                    Text = "+", 
                    Size = new Size(50, 30), 
                    Location = new Point(10, 180), 
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.LightGreen, 
                    ForeColor = Color.DarkGreen,
                    Cursor = Cursors.Hand 
                };

                btnAgregar.FlatAppearance.BorderSize = 0;

                // Cambia los colores del botón cuando el usuario pasa el cursor sobre él.
                btnAgregar.MouseEnter += (s, e) =>
                {
                    btnAgregar.BackColor = Color.Green;
                    btnAgregar.ForeColor = Color.White;
                };
                btnAgregar.MouseLeave += (s, e) =>
                {
                    btnAgregar.BackColor = Color.LightGreen;
                    btnAgregar.ForeColor = Color.DarkGreen;
                };

                // Asigna la acción de agregar el producto al carrito cuando se presiona el botón.
                btnAgregar.Click += (s, e) => AgregarAlCarrito(producto);
                panelProducto.Controls.Add(btnAgregar); // Agrega el botón al panel.

                // Botón para ver información detallada del producto con efecto hover.
                var btnInfo = new Button
                {
                    Text = "Info", 
                    Size = new Size(50, 30), 
                    Location = new Point(80, 180), 
                    FlatStyle = FlatStyle.Flat, 
                    BackColor = Color.LightBlue, 
                    ForeColor = Color.DarkBlue, 
                    Cursor = Cursors.Hand 
                };

                btnInfo.FlatAppearance.BorderSize = 0;

                btnInfo.MouseEnter += (s, e) =>
                {
                    btnInfo.BackColor = Color.RoyalBlue;
                    btnInfo.ForeColor = Color.White;
                };
                btnInfo.MouseLeave += (s, e) =>
                {
                    btnInfo.BackColor = Color.LightBlue;
                    btnInfo.ForeColor = Color.DarkBlue;
                };

                // Asigna la acción de mostrar detalles del producto cuando se presiona el botón.
                btnInfo.Click += (s, e) => AbrirInformacionProducto(producto);
                panelProducto.Controls.Add(btnInfo); // Agrega el botón al panel.

                // Finalmente, agrega el panel con toda la información al contenedor principal.
                flowLayoutPanel1.Controls.Add(panelProducto);
            }
        }
        // Abre una nueva ventana con la información del producto seleccionado.
        private void AbrirInformacionProducto(Producto? producto)
        {
            if (producto == null)
            {
                MessageBox.Show("Error: Producto no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtiene los datos del producto o establece valores predeterminados si están vacíos.
            string nombre = producto.Nombre ?? "Nombre no disponible";
            string imagenUrl = producto.ImagenUrl ?? "";
            string descripcion = producto.DescripcionProducto?.DescripcionLarga ?? "Descripción no disponible";

            var infoView = new InformacionesView(nombre, imagenUrl, descripcion);

            // Verifica si el formulario de menú principal está abierto y usa su método para abrir la ventana de información.
            MenuPrincipalView? menu = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();
            if (menu != null)
            {
                menu.AbrirFormulariosHijos(infoView);
            }
        }

        // Agrega el producto seleccionado al carrito de compras.
        private void AgregarAlCarrito(Producto producto)
        {
            carritoControl.AgregarProducto(producto);
        }

        // Evento del botón de búsqueda para ejecutar la búsqueda de productos.
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
