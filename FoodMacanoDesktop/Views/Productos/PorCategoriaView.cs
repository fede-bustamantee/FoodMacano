using FoodMacanoDesktop.Controls; 
using FoodMacanoDesktop.Views.Informaciones;
using FoodMacanoDesktop.Views.Menu; 
using FoodMacanoServices.Models.Common; 
using FoodMacanoServices.Services.Common; 

namespace FoodMacanoDesktop.Views.Productos
{
    public partial class PorCategoriaView : Form
    {
        private ProductoService productoService = new ProductoService();
        private List<Producto> productos = new List<Producto>();
        private CategoriaService categoriaService = new CategoriaService();
        private CarritoControl carritoControl; // Control para manejar el carrito de compras.

        public PorCategoriaView()
        {
            InitializeComponent(); 
            carritoControl = new CarritoControl(); // Crea una instancia del control de carrito.
            Controls.Add(carritoControl); // Añade el control del carrito al formulario.
            CargarCategorias();
        }
        private async void CargarCategorias()
        {
            try
            {
                cboCategorias.DropDownStyle = ComboBoxStyle.DropDownList; // Establece el estilo de lista desplegable para el ComboBox.
                var categorias = await categoriaService.GetAllAsync(); // Obtiene las categorías de manera asíncrona desde el servicio.
                cboCategorias.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;
                cboCategorias.DisplayMember = "Nombre";
                cboCategorias.ValueMember = "Id";
                cboCategorias.DataSource = categorias; // Asocia la lista de categorías al ComboBox.
                cboCategorias.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
                
                if (cboCategorias.Items.Count > 0)
                {
                    cboCategorias.SelectedIndex = 0; // Selecciona la primera categoría si existe alguna.
                    var primeraCategoria = cboCategorias.SelectedItem as Categoria; // Obtiene la primera categoría seleccionada.
                    if (primeraCategoria != null)
                    {
                        await CargarProductosPorCategoria(primeraCategoria.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un error si ocurre una excepción.
            }
        }

        // Función que se ejecuta cuando se cambia la selección del ComboBox de categorías.
        private async void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategorias.SelectedItem is Categoria categoriaSeleccionada) // Verifica que el ítem seleccionado sea una categoría válida.
            {
                await CargarProductosPorCategoria(categoriaSeleccionada.Id); // Llama a la función para cargar los productos de la categoría seleccionada.
            }
        }
        private async Task CargarProductosPorCategoria(int categoriaId)
        {
            productos = await productoService.GetByCategoriaAsync(categoriaId); // Obtiene los productos para la categoría especificada.
            MostrarProductos();
            
        }
        private void MostrarProductos()
        {
            flowLayoutPanel1.Controls.Clear(); // Limpia cualquier control existente en el FlowLayoutPanel.
            int panelWidth = 170, panelHeight = 230;

            foreach (var producto in productos) // Itera sobre cada producto de la lista.
            {
                var panelProducto = new Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    BackColor = Color.LightGray, 
                };

                // Crea y configura una etiqueta para el nombre del producto.
                var labelNombre = new Label
                {
                    Text = producto.Nombre,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Location = new Point(10, 10),
                    Size = new Size(135, 25),
                    AutoEllipsis = true,
                    ForeColor=Color.Black
                };
                panelProducto.Controls.Add(labelNombre);

                // Agrega una etiqueta para el precio del producto.
                panelProducto.Controls.Add(new Label
                {
                    Text = $"${producto.Precio:F2}",
                    Font = new Font("Segoe UI", 12F),
                    Location = new Point(10, 40),
                    AutoSize = true,
                    ForeColor = Color.Black
                });

                // Crea un PictureBox para mostrar la imagen del producto.
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

                // Crea un botón para agregar el producto al carrito.
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

                // Efectos de hover para el botón "Agregar".
                btnAgregar.FlatAppearance.BorderSize = 0;
                btnAgregar.MouseEnter += (s, e) => {
                    btnAgregar.BackColor = Color.Green;
                    btnAgregar.ForeColor = Color.White;
                };
                btnAgregar.MouseLeave += (s, e) => {
                    btnAgregar.BackColor = Color.LightGreen;
                    btnAgregar.ForeColor = Color.DarkGreen;
                };

                // Al hacer clic en el botón, agrega el producto al carrito.
                btnAgregar.Click += (s, e) => AgregarAlCarrito(producto);
                panelProducto.Controls.Add(btnAgregar);

                // Crea un botón para ver información adicional del producto.
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

                // Efectos de hover para el botón "Info".
                btnInfo.FlatAppearance.BorderSize = 0;
                btnInfo.MouseEnter += (s, e) => {
                    btnInfo.BackColor = Color.RoyalBlue;
                    btnInfo.ForeColor = Color.White;
                };
                btnInfo.MouseLeave += (s, e) => {
                    btnInfo.BackColor = Color.LightBlue;
                    btnInfo.ForeColor = Color.DarkBlue;
                };

                // Al hacer clic en el botón, abre la información del producto.
                btnInfo.Click += (s, e) => AbrirInformacionProducto(producto);
                panelProducto.Controls.Add(btnInfo);

                flowLayoutPanel1.Controls.Add(panelProducto); // Añade el panel con el producto al FlowLayoutPanel.
            }
        }
        private void AbrirInformacionProducto(Producto? producto)
        {
            if (producto == null)
            {
                MessageBox.Show("Error: Producto no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un error si el producto no es válido.
                return;
            }

            // Crea una nueva vista con la información del producto.
            string nombre = producto.Nombre ?? "Nombre no disponible";
            string imagenUrl = producto.ImagenUrl ?? "";
            string descripcion = producto.DescripcionProducto?.DescripcionLarga ?? "Descripción no disponible";

            var infoView = new InformacionesView(nombre, imagenUrl, descripcion); // Abre la vista de información.

            MenuPrincipalView? menu = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();
            if (menu != null)
            {
                menu.AbrirFormulariosHijos(infoView); // Si hay un formulario principal, lo abre como hijo.
            }
        }

        private void AgregarAlCarrito(Producto producto)
        {
            carritoControl.AgregarProducto(producto); // Agrega el producto al control del carrito.
        }
    }
}
