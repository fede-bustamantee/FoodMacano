using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Models.Orders;
using FoodMacanoServices.Services.Common;
using FoodMacanoServices.Services.Orders;

namespace FoodMacanoDesktop.Views.Encargues.Web
{
    public partial class EditarWebView : Form
    {
        private DesktopWebService _encarguesService;
        private Encargue _encargue; 
        private BindingSource _detallesBindingSource; 
        private ProductoService _productoService;
        private Panel panelDetalles;

        public EditarWebView(Encargue encargue)
        {
            InitializeComponent();
            _encarguesService = new DesktopWebService();
            _encargue = encargue;
            _detallesBindingSource = new BindingSource();
            _productoService = new ProductoService();

            Configuaraciontxt();
            ConfigurarFormulario();
            // Cargamos los datos del encargue
            CargarDatos();
        }

        // Este método configura los controles de texto para mostrar los datos del encargue
        private void Configuaraciontxt()
        {
            if (_encargue != null)
            {
                // Mostramos los datos del cliente y la fecha del encargue
                txtCliente.Text = _encargue.Usuario?.User ?? "Desconocido"; 
                dtpFecha.Value = _encargue.FechaEncargue; 

                // Calculamos el total del encargue sumando los productos (cantidad * precio)
                decimal total = _encargue.EncargueDetalles.Sum(d => d.Cantidad * d.Producto.Precio);
                txtTotal.Text = total.ToString("C2");

                // Verificamos si el panel donde se muestran los detalles es null
                // Si lo es, lo creamos y lo agregamos al formulario
                if (panelDetalles == null)
                {
                    panelDetalles = new Panel
                    {
                        Location = new Point(10, 200),
                        Size = new Size(760, 300),
                        AutoScroll = true,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    this.Controls.Add(panelDetalles);
                }
                CargarDetalles();
            }
        }

        // Método para cargar los detalles del encargue
        private void CargarDetalles()
        {
            panelDetalles.Controls.Clear(); // Limpiamos los controles previos
            panelDetalles.BorderStyle = BorderStyle.None;
            panelDetalles.BackColor = Color.Gray;
            panelDetalles.Width = 600; 
            panelDetalles.Left = ((this.ClientSize.Width - panelDetalles.Width) / 2) + 200; // Centramos el panel

            int yPos = 10; // Posición inicial para los controles de cada detalle

            // Recorremos los detalles del encargue y los mostramos en el panel
            foreach (var detalle in _encargue.EncargueDetalles)
            {
                // Creamos un panel para cada producto del detalle
                Panel panelItem = new Panel
                {
                    Size = new Size(560, 100),
                    Location = new Point(10, yPos),
                    BackColor = Color.FromArgb(40, 40, 40)
                };
                panelDetalles.Controls.Add(panelItem);

                // Agregamos el control Label para mostrar "Producto:"
                Label lblProducto = new Label
                {
                    Text = "Producto:",
                    Location = new Point(10, 15),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Font = new Font("Arial", 11, FontStyle.Bold) 
                };
                panelItem.Controls.Add(lblProducto);

                // Creamos un TextBox para mostrar el nombre del producto (solo lectura)
                TextBox txtProducto = new TextBox
                {
                    Text = detalle.Producto?.Nombre ?? "",
                    Location = new Point(90, 12),
                    Width = 200,
                    Height = 25,
                    ReadOnly = true,
                    Font = new Font("Arial", 11)
                };
                panelItem.Controls.Add(txtProducto);

                // Botón "Cambiar" para cambiar el producto
                Button btnCambiar = new Button
                {
                    Text = "Cambiar",
                    Location = new Point(300, 10),
                    Width = 90,
                    Height = 30,
                    BackColor = Color.Orange,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 11, FontStyle.Bold)
                };
                btnCambiar.Click += async (s, e) => await MostrarProductosAsync(txtProducto, detalle); // Evento al hacer clic
                panelItem.Controls.Add(btnCambiar);

                // Agregamos el control Label para mostrar "Cantidad:"
                Label lblCantidad = new Label
                {
                    Text = "Cantidad:",
                    Location = new Point(10, 60),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Font = new Font("Arial", 11, FontStyle.Bold)
                };
                panelItem.Controls.Add(lblCantidad);

                // Creamos un NumericUpDown para modificar la cantidad del producto
                NumericUpDown numCantidad = new NumericUpDown
                {
                    Value = detalle.Cantidad,
                    Location = new Point(90, 55),
                    Width = 50,
                    Minimum = 1,
                    Maximum = 100,
                    Font = new Font("Arial", 11)
                };
                numCantidad.ValueChanged += (s, e) =>
                {
                    var det = (EncargueDetalle)numCantidad.Tag;
                    det.Cantidad = (int)numCantidad.Value; // Actualizamos la cantidad
                    ActualizarTotal(); // Actualizamos el total
                };
                numCantidad.Tag = detalle; // Asignamos el detalle al control
                panelItem.Controls.Add(numCantidad);

                // Agregamos el control Label para mostrar "Precio:"
                Label lblPrecio = new Label
                {
                    Text = "Precio:",
                    Location = new Point(170, 60),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Font = new Font("Arial", 11, FontStyle.Bold)
                };
                panelItem.Controls.Add(lblPrecio);

                // Creamos un TextBox para mostrar el precio del producto (solo lectura)
                TextBox txtPrecio = new TextBox
                {
                    Text = detalle.Producto?.Precio.ToString("C2") ?? "0",
                    Location = new Point(230, 55),
                    Width = 90,
                    Height = 25,
                    ReadOnly = true,
                    Font = new Font("Arial", 11)
                };
                panelItem.Controls.Add(txtPrecio);

                yPos += 110; // Incrementamos la posición vertical para el siguiente detalle
            }
        }

        // Método para mostrar la lista de productos y permitir seleccionar uno
        private async Task MostrarProductosAsync(TextBox txtProducto, EncargueDetalle detalle)
        {
            var productos = await _productoService.GetAllAsync(); // Obtenemos todos los productos

            using (var selectProductForm = new Form())
            {
                selectProductForm.Text = "Seleccionar Producto";
                selectProductForm.Size = new Size(400, 500);
                selectProductForm.StartPosition = FormStartPosition.CenterParent;

                ListBox listBox = new ListBox
                {
                    DataSource = productos, // Asignamos los productos a la lista
                    DisplayMember = "Nombre",
                    ValueMember = "Id", 
                    Dock = DockStyle.Fill
                };
                selectProductForm.Controls.Add(listBox);

                Button btnSelect = new Button
                {
                    Text = "Seleccionar",
                    Dock = DockStyle.Bottom,
                    Height = 40,
                    Font = new Font("Arial", 12)
                };

                // Evento cuando se selecciona un producto
                btnSelect.Click += (s, e) =>
                {
                    if (listBox.SelectedItem is Producto selectedProduct)
                    {
                        detalle.Producto = selectedProduct; // Actualizamos el producto seleccionado
                        txtProducto.Text = selectedProduct.Nombre; // Mostramos el nombre en el TextBox

                        Panel panelItem = txtProducto.Parent as Panel; // Obtenemos el panel del detalle
                        if (panelItem != null)
                        {
                            var txtPrecio = panelItem.Controls.OfType<TextBox>().FirstOrDefault(txt => txt != txtProducto && txt.ReadOnly);
                            if (txtPrecio != null)
                            {
                                // Actualizamos el precio mostrado
                                txtPrecio.Text = selectedProduct.Precio.ToString("C2");
                            }
                        }

                        ActualizarTotal(); // Actualizamos el total general
                        selectProductForm.Close(); // Cerramos el formulario de selección de productos
                    }
                };

                selectProductForm.Controls.Add(btnSelect);
                selectProductForm.ShowDialog(); // Mostramos el formulario para seleccionar un producto
            }
        }
        private void ActualizarTotal()
        {
            // Sumamos todos los subtotales (cantidad * precio) y mostramos el total
            decimal total = _encargue.EncargueDetalles.Sum(d => d.Cantidad * (d.Producto?.Precio ?? 0));
            txtTotal.Text = total.ToString("C2");
        }

        // Método para cargar los datos iniciales del encargue
        private void CargarDatos()
        {
            _detallesBindingSource.DataSource = _encargue.EncargueDetalles; // Asignamos los detalles al BindingSource
            CargarDetalles(); // Cargamos los detalles en los controles del formulario
        }

        // Método para configurar el formulario
        private void ConfigurarFormulario()
        {
            this.Text = "Editar Encargue"; // Establecemos el título del formulario
            this.StartPosition = FormStartPosition.CenterScreen; // Centrado en la pantalla
        }

        // Evento para cerrar el formulario
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento para guardar los cambios del encargue
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var dtpFecha = Controls.OfType<DateTimePicker>().FirstOrDefault(); // Obtenemos el DateTimePicker
            if (dtpFecha != null)
            {
                _encargue.FechaEncargue = dtpFecha.Value; // Actualizamos la fecha del encargue
            }

            await _encarguesService.UpdateEncargueAsync(_encargue); // Guardamos los cambios
            MessageBox.Show("Encargue actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK; // Indicamos que los cambios fueron exitosos
            Close();
        }
    }
}
