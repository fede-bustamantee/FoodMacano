using FoodMacanoDesktop.Controls;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;

namespace FoodMacanoDesktop.Views.Productos
{
    public partial class PorCategoriaView : Form
    {
        private ProductoService productoService = new ProductoService();
        private List<Producto> productos = new List<Producto>();
        private CategoriaService categoriaService = new CategoriaService();
        private CarritoControl carritoControl;


        public PorCategoriaView()
        {
            InitializeComponent();
            carritoControl = new CarritoControl();
            Controls.Add(carritoControl);
            CargarCategorias();
        }

        private async void CargarCategorias()
        {
            try
            {
                // Configurar el estilo del ComboBox
                cboCategorias.DropDownStyle = ComboBoxStyle.DropDownList;

                // Obtener las categorías de la base de datos
                var categorias = await categoriaService.GetAllAsync();

                // Desactivar temporalmente el evento para evitar una carga doble
                cboCategorias.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;

                cboCategorias.DisplayMember = "Nombre";
                cboCategorias.ValueMember = "Id";
                cboCategorias.DataSource = categorias;

                // Suscribirse al evento de cambio
                cboCategorias.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

                // Seleccionar la primera categoría y cargar sus productos
                if (cboCategorias.Items.Count > 0)
                {
                    cboCategorias.SelectedIndex = 0;
                    var primerCategoria = cboCategorias.SelectedItem as Categoria;
                    if (primerCategoria != null)
                    {
                        await CargarProductosPorCategoria(primerCategoria.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategorias.SelectedItem != null)
            {
                var categoriaSeleccionada = cboCategorias.SelectedItem as Categoria;
                if (categoriaSeleccionada != null)
                {
                    await CargarProductosPorCategoria(categoriaSeleccionada.Id);
                }
            }
        }

        private async Task CargarProductosPorCategoria(int categoriaId)
        {
            try
            {
                productos = await productoService.GetByCategoriaAsync(categoriaId);
                MostrarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarProductos()
        {
            flowLayoutPanel1.Controls.Clear();
            int panelWidth = 230, panelHeight = 200;

            foreach (var producto in productos)
            {
                var panelProducto = new Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    Margin = new Padding(10),
                    BackColor = Color.LightGray
                };

                var lblNombre = new Label
                {
                    Text = producto.Nombre,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                var lblPrecio = new Label
                {
                    Text = $"${producto.Precio:F2}",
                    Font = new Font("Segoe UI", 12F),
                    Location = new Point(10, 40),
                    AutoSize = true
                };

                var picImagen = new PictureBox
                {
                    Size = new Size(111, 99),
                    Location = new Point(10, 70),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                if (!string.IsNullOrEmpty(producto.ImagenUrl))
                {
                    try
                    {
                        picImagen.Load(producto.ImagenUrl);
                    }
                    catch
                    {
                        picImagen.BackColor = Color.Gray;
                    }
                }

                var btnAgregar = new Button
                {
                    Text = "Agregar",
                    Size = new Size(80, 30),
                    Location = new Point(130, 70)
                };
                btnAgregar.Click += (s, e) => AgregarAlCarrito(producto);

                panelProducto.Controls.AddRange(new Control[] { lblNombre, lblPrecio, picImagen, btnAgregar });
                flowLayoutPanel1.Controls.Add(panelProducto);
            }
        }

        private void AgregarAlCarrito(Producto producto)
        {
            carritoControl.AgregarProducto(producto);
        }
    }
}