using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Controls
{
    public partial class CarritoControl : UserControl
    {
        private DesktopCarrito carrito = DesktopCarrito.Instance;
        public CarritoControl()
        {
            InitializeComponent();
            carrito.CarritoActualizado += Carrito_Actualizado;
            ActualizarVistaCarrito();
        }
        public void AgregarProducto(Producto producto)
        {
            carrito.AgregarProducto(producto);
            ActualizarVistaCarrito();
        }

        private void Carrito_Actualizado(object sender, EventArgs e)
        {
            ActualizarVistaCarrito();
        }

        private void ActualizarVistaCarrito()
        {
            flowLayoutPanelCarrito.Controls.Clear();

            foreach (var item in carrito.Items)
            {
                var panelItem = new Panel
                {
                    Size = new Size(320, 40),
                    BackColor = Color.LightGray,
                    Margin = new Padding(5)
                };

                panelItem.Controls.Add(new Label
                {
                    Text = $"{item.Producto.Nombre} x{item.Cantidad} - ${item.Producto.Precio * item.Cantidad:F2}",
                    Location = new Point(10, 10),
                    AutoSize = true
                });

                var btnEliminar = new Button
                {
                    Text = "X",
                    Size = new Size(30, 30),
                    Location = new Point(260, 5)
                };
                btnEliminar.Click += (s, e) => RemoverDelCarrito(item);
                panelItem.Controls.Add(btnEliminar);

                flowLayoutPanelCarrito.Controls.Add(panelItem);
            }

            txtTotal.Text = $"Total: ${carrito.Total:F2}";
        }

        private void RemoverDelCarrito(CarritoCompra item)
        {
            carrito.RemoverProducto(item);
            ActualizarVistaCarrito();
        }

        private async void btnEncargar_Click(object sender, EventArgs e)
        {
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
                string numeroMesa = textBox1.Text;

                // Verificar si la mesa ya tiene una reserva
                bool mesaReservada = await encargueService.MesaYaReservadaAsync(numeroMesa);
                if (mesaReservada)
                {
                    MessageBox.Show($"La mesa {numeroMesa} ya tiene un encargo activo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<Task> tareas = new List<Task>();

                foreach (var item in carrito.Items)
                {
                    var encargue = new DesktopEncargue
                    {
                        NumeroMesa = numeroMesa,
                        ProductoId = item.Producto.Id,
                        NombreProducto = item.Producto.Nombre,
                        Cantidad = item.Cantidad,
                        PrecioUnitario = item.Producto.Precio,
                        Total = item.Producto.Precio * item.Cantidad,
                        FechaEncargue = DateTime.Now
                    };

                    tareas.Add(encargueService.EnviarEncargueAsync(encargue));
                }

                await Task.WhenAll(tareas);
                carrito.LimpiarCarrito();
                textBox1.Clear();
                ActualizarVistaCarrito();
                MessageBox.Show("El encargo ha sido realizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el encargo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
