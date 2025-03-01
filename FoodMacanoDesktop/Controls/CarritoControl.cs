using FoodMacanoServices.Models;
using FoodMacanoServices.Models.Cart;
using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Services.Cart;
using FoodMacanoServices.Services.Orders;
using System.Data;

namespace FoodMacanoDesktop.Controls
{
    public partial class CarritoControl : UserControl //clase con única instancia y proporcionaa acceso global.
    {
        //patrón Singleton.
        private DesktopCarrito carrito = DesktopCarrito.Instance;

        public CarritoControl()
        {
            InitializeComponent();
            // Se suscribe al evento que se dispara cuando el carrito se actualiza.
            carrito.CarritoActualizado += Carrito_Actualizado;
            ActualizarVistaCarrito();
        }

        // Método para agregar un producto al carrito y actualizar la vista.
        public void AgregarProducto(Producto producto)
        {
            carrito.AgregarProducto(producto);
            ActualizarVistaCarrito();
        }

        // Manejador del evento que se dispara cuando el carrito es actualizado.
        private void Carrito_Actualizado(object sender, EventArgs e)
        {
            ActualizarVistaCarrito();
        }

        // Método para actualizar la vista del carrito.
        private void ActualizarVistaCarrito()
        {
            flowLayoutPanelCarrito.Controls.Clear();  // Limpia los controles existentes.

            // Itera sobre cada item en el carrito y crea su representación visual.
            foreach (var item in carrito.Items)
            {
                // Crea un panel para representar un producto.
                var panelItem = new Panel
                {
                    Size = new Size(340, 50),
                    BackColor = Color.White,
                    Margin = new Padding(4),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Crea la etiqueta que muestra el nombre del producto con elipsis si el texto es largo.
                var lblNombre = new Label
                {
                    Text = item.Producto.Nombre,
                    Location = new Point(10, 8),
                    Size = new Size(200, 18),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoEllipsis = true
                };
                panelItem.Controls.Add(lblNombre);  // Añade la etiqueta al panel.

                // Crea la etiqueta para mostrar la cantidad y el precio total del producto.
                var lblDetalle = new Label
                {
                    Text = $"Cant: {item.Cantidad} - ${item.Producto.Precio * item.Cantidad:F2}",
                    Location = new Point(10, 26),
                    AutoSize = true,
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 9F)
                };
                panelItem.Controls.Add(lblDetalle);  // Añade la etiqueta al panel.

                // Crea el botón de eliminar producto, estilizado y con efectos hover.
                var btnEliminar = new Button
                {
                    Text = "✕",
                    Size = new Size(30, 30),
                    Location = new Point(306, 10),
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.FromArgb(255, 80, 80),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnEliminar.FlatAppearance.BorderSize = 0;

                // Efecto hover para el botón eliminar: cambia el color de fondo y texto cuando el mouse pasa sobre él.
                btnEliminar.MouseEnter += (s, e) => {
                    btnEliminar.BackColor = Color.FromArgb(255, 80, 80);
                    btnEliminar.ForeColor = Color.White;
                };
                btnEliminar.MouseLeave += (s, e) => {
                    btnEliminar.BackColor = Color.White;
                    btnEliminar.ForeColor = Color.FromArgb(255, 80, 80);
                };

                // Cuando se hace clic en el botón eliminar, se elimina el producto del carrito.
                btnEliminar.Click += (s, e) => RemoverDelCarrito(item);
                panelItem.Controls.Add(btnEliminar);  // Añade el botón al panel.

                // Efecto hover para el panel completo: cambia el color de fondo del panel cuando el mouse pasa sobre él.
                panelItem.MouseEnter += (s, e) => {
                    panelItem.BackColor = Color.FromArgb(250, 250, 250);
                };
                panelItem.MouseLeave += (s, e) => {
                    panelItem.BackColor = Color.White;
                };

                // Añade el panel al FlowLayoutPanel que contiene los elementos del carrito.
                flowLayoutPanelCarrito.Controls.Add(panelItem);
            }

            // Si el carrito está vacío, muestra un mensaje indicándolo.
            if (!carrito.Items.Any())
            {
                var emptyLabel = new Label
                {
                    Text = "Tu carrito está vacío",
                    Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(100, 150, 0, 0)
                };
                flowLayoutPanelCarrito.Controls.Add(emptyLabel);
            }

            // Actualiza el total del carrito en el cuadro de texto correspondiente.
            txtTotal.Text = $"${carrito.Total:F2}";
        }

        // Método para eliminar un producto del carrito y actualizar la vista.
        private void RemoverDelCarrito(CarritoCompra item)
        {
            carrito.RemoverProducto(item);
            ActualizarVistaCarrito();
        }

        // Manejador del evento clic en el botón de realizar el pedido.
        private async void btnEncargar_Click(object sender, EventArgs e)
        {
            // Verifica que el carrito no esté vacío y que se haya ingresado un número de mesa.
            if (!carrito.Items.Any())
            {
                MessageBox.Show("El carrito está vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Por favor ingrese un número de mesa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var encargueService = new DesktopEncargueService();

                // Verifica si ya existe un encargo para la mesa indicada.
                var existingEncargues = await encargueService.GetEncarguesAsync();
                if (existingEncargues.Any(e => e.NumeroMesa == textBox1.Text))
                {
                    MessageBox.Show($"La mesa {textBox1.Text} ya tiene un encargo activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crea una lista de encargos con todos los productos del carrito.
                List<DesktopEncargue> ordenCompleta = carrito.Items.Select(item => new DesktopEncargue
                {
                    NumeroMesa = textBox1.Text,
                    ProductoId = item.Producto.Id,
                    NombreProducto = item.Producto.Nombre,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.Producto.Precio,
                    Total = item.Producto.Precio * item.Cantidad,
                    FechaEncargue = DateTime.Now
                }).ToList();

                // Envía los encargos al servicio para su procesamiento.
                bool resultadoEnvio = await encargueService.EnviarEncarguesAsync(ordenCompleta);

                if (resultadoEnvio)
                {
                    // Si el pedido se envió exitosamente, limpia el carrito y muestra un mensaje de éxito.
                    carrito.LimpiarCarrito();
                    textBox1.Clear();
                    ActualizarVistaCarrito();
                    MessageBox.Show("El encargo ha sido realizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Si hubo un error al enviar el pedido, muestra un mensaje de error.
                    MessageBox.Show("No se pudo procesar completamente el encargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, muestra el mensaje de error correspondiente.
                MessageBox.Show($"Error al procesar el encargo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}