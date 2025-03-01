using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Models.Orders;
using FoodMacanoServices.Services.Common;
using FoodMacanoServices.Services.Orders;

namespace FoodMacanoDesktop.Views.Encargues.Movil
{
    public partial class EditarMovilView : Form
    {
        // Servicios para encargues y productos
        private DesktopMovilService _encarguesService;
        private MauiEncargue _encargue;
        private BindingSource _detallesBindingSource;
        private ProductoService productoService;

        // Constructor que inicializa los servicios y carga los datos del encargue
        public EditarMovilView(MauiEncargue encargue)
        {
            InitializeComponent();
            _encarguesService = new DesktopMovilService();
            _encargue = encargue;
            _detallesBindingSource = new BindingSource();
            productoService = new ProductoService();

            ConfigurarFormulario();
            CargarDatos(); 
        }

        // Configura los controles del formulario con los datos actuales del encargue
        private void ConfigurarFormulario()
        {
            txtCliente.Text = _encargue.UserDisplayName; 
            txtDireccion.Text = _encargue.Direccion; 
            dtpFecha.Value = _encargue.FechaEncargue; 
            ActualizarTotal(); 
            CargarDetalles(); 
        }

        // Carga los detalles del encargue en los controles del formulario
        private async void CargarDetalles()
        {
            var detalles = _encargue.Detalles.ToList();
            panelDetalles.Controls.Clear();
            panelDetalles.BackColor = Color.Gray;
            panelDetalles.Padding = new Padding(10);

            // Recorremos los detalles del encargue y los mostramos en el panel
            foreach (var detalle in detalles)
            {
                // Crear un panel para cada detalle
                Panel detallePanel = new Panel
                {
                    Size = new Size(600, 160),
                    BackColor = Color.FromArgb(64, 64, 64),
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(15),
                    Margin = new Padding(250, 0, 0, 0)
                };

                // Crear un TableLayoutPanel para organizar los controles
                TableLayoutPanel grid = new TableLayoutPanel
                {
                    ColumnCount = 4,
                    RowCount = 2,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(5),
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Anchor = AnchorStyles.None,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.None
                };

                // Configuración de las columnas del grid
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100)); 
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150)); 

                // Fila 1: Producto + Botón para cambiar
                grid.Controls.Add(new Label
                {
                    Text = "Producto:",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    Anchor = AnchorStyles.None
                }, 0, 0);

                TextBox txtProducto = new TextBox
                {
                    Text = detalle.NombreProducto,
                    Font = new Font("Segoe UI", 12),
                    Anchor = AnchorStyles.None,
                    ReadOnly = true,
                    BackColor = Color.WhiteSmoke,
                    Width = 190
                };
                grid.Controls.Add(txtProducto, 1, 0);

                Button btnSelectProduct = new Button
                {
                    Text = "Cambiar",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Size = new Size(90, 32),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Orange,
                    ForeColor = Color.White,
                    Anchor = AnchorStyles.None
                };
                btnSelectProduct.FlatAppearance.BorderSize = 0;
                btnSelectProduct.Click += async (s, e) => await MostrarProductosAsync(txtProducto, detalle, grid);
                grid.Controls.Add(btnSelectProduct, 2, 0);

                // Fila 2: Cantidad + Precio centrados
                grid.Controls.Add(new Label
                {
                    Text = "Cantidad:",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    Anchor = AnchorStyles.None
                }, 0, 1);

                NumericUpDown numCantidad = new NumericUpDown
                {
                    Value = detalle.Cantidad,
                    Minimum = 1,
                    Maximum = 999,
                    Font = new Font("Segoe UI", 12),
                    Size = new Size(70, 28),
                    BackColor = Color.WhiteSmoke,
                    Anchor = AnchorStyles.None
                };
                numCantidad.ValueChanged += (s, e) =>
                {
                    detalle.Cantidad = (int)numCantidad.Value;
                    ActualizarTotal(); // Actualiza el total cuando cambia la cantidad
                };
                grid.Controls.Add(numCantidad, 1, 1);

                // Mostrar precio unitario
                grid.Controls.Add(new Label
                {
                    Text = "Precio:",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    Anchor = AnchorStyles.None
                }, 2, 1);

                TextBox txtPrecio = new TextBox
                {
                    Text = detalle.PrecioUnitario.ToString("C2"),
                    Font = new Font("Segoe UI", 12),
                    ReadOnly = true,
                    BackColor = Color.WhiteSmoke,
                    Width = 140,
                    Anchor = AnchorStyles.None
                };
                grid.Controls.Add(txtPrecio, 3, 1);

                detallePanel.Controls.Add(grid);
                panelDetalles.Controls.Add(detallePanel);
            }

            panelDetalles.AutoScroll = true; // Habilita el desplazamiento en el panel
        }

        // Muestra el formulario para seleccionar un producto y actualiza el detalle del encargue
        private async Task MostrarProductosAsync(TextBox txtProducto, MauiEncargueDetalle detalle, TableLayoutPanel grid)
        {
            var productos = await productoService.GetAllAsync(); // Obtener productos disponibles

            // Crear el formulario para seleccionar el producto
            using (var selectProductForm = new Form())
            {
                selectProductForm.Text = "Seleccionar Producto";
                selectProductForm.StartPosition = FormStartPosition.CenterScreen;
                selectProductForm.Size = new Size(300, 400);
                selectProductForm.BackColor = Color.Gray;

                ListBox listBox = new ListBox
                {
                    DataSource = productos,
                    DisplayMember = "Nombre",
                    ValueMember = "Id",
                    Dock = DockStyle.Fill
                };
                selectProductForm.Controls.Add(listBox);

                Button btnSelect = new Button
                {
                    Text = "Seleccionar",
                    Dock = DockStyle.Bottom
                };
                selectProductForm.Controls.Add(btnSelect);

                btnSelect.Click += (s, e) =>
                {
                    if (listBox.SelectedItem is Producto selectedProduct)
                    {
                        detalle.NombreProducto = selectedProduct.Nombre; // Actualizar nombre del producto
                        txtProducto.Text = selectedProduct.Nombre;
                        detalle.PrecioUnitario = selectedProduct.Precio; // Actualizar precio unitario

                        var txtPrecio = grid.Controls.OfType<TextBox>().FirstOrDefault(txt => txt != txtProducto && txt.ReadOnly);
                        if (txtPrecio != null)
                        {
                            txtPrecio.Text = selectedProduct.Precio.ToString("C2");
                        }

                        ActualizarTotal(); // Actualiza el total
                        selectProductForm.Close();
                    }
                };

                selectProductForm.ShowDialog(); // Mostrar el formulario de selección
            }
        }
        private void ActualizarTotal()
        {
            decimal total = _encargue.Detalles.Sum(d => d.Cantidad * d.PrecioUnitario); // Calcular el total
            txtTotal.Text = total.ToString("C2"); // Mostrar el total
            _encargue.Total = total; // Actualizar el total en el encargue
        }

        // Cargar los datos de los detalles en el BindingSource
        private void CargarDatos()
        {
            _detallesBindingSource.DataSource = _encargue.Detalles;
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            _encargue.UserDisplayName = txtCliente.Text;
            _encargue.Direccion = txtDireccion.Text;
            _encargue.FechaEncargue = dtpFecha.Value;

            await _encarguesService.UpdateEncargueAsync(_encargue); // Actualizar encargue en el servicio

            CargarDetalles(); // Recargar detalles
            _detallesBindingSource.ResetBindings(false); // Actualizar bindings

            this.DialogResult = DialogResult.OK; // Cerrar formulario con éxito
            this.Close();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}