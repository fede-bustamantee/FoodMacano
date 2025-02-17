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

namespace FoodMacanoDesktop.Views.Encargues.Web
{
    public partial class EditarWebView : Form
    {
        private readonly DesktopWebService _encarguesService;
        private readonly Encargue _encargue;
        private BindingSource _detallesBindingSource;
        private readonly ProductoService _productoService;
        private Panel panelDetalles;

        public EditarWebView(Encargue encargue)
        {
            InitializeComponent();
            _encarguesService = new DesktopWebService();
            _encargue = encargue;
            _detallesBindingSource = new BindingSource();
            _productoService = new ProductoService();

            InitializeCustomComponents();
            ConfigurarFormulario();
            CargarDatos();
        }

        private void InitializeCustomComponents()
        {
            this.Size = new Size(800, 600);

            // TextBox para Usuario
            Label lblUsuario = new Label
            {
                Text = "Usuario:",
                Location = new Point(10, 10),
                AutoSize = true
            };
            TextBox txtUsuario = new TextBox
            {
                Text = _encargue.Usuario?.User ?? "",
                Location = new Point(10, 30),
                Width = 200
            };

            // TextBox para Total
            Label lblTotal = new Label
            {
                Text = "Total:",
                Location = new Point(10, 110),
                AutoSize = true
            };
            TextBox txtTotal = new TextBox
            {
                Text = CalcularTotal().ToString("C2"),
                Location = new Point(10, 130),
                Width = 200,
                ReadOnly = true
            };

            // DateTimePicker
            DateTimePicker dtpFecha = new DateTimePicker
            {
                Value = _encargue.FechaEncargue,
                Location = new Point(10, 160),
                Width = 200
            };

            // Panel para los detalles
            panelDetalles = new Panel
            {
                Location = new Point(10, 200),
                Size = new Size(760, 300),
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] {
            lblUsuario, txtUsuario,
            lblTotal, txtTotal,
            dtpFecha,
            panelDetalles,
        });
        }

        private void CargarDetalles()
        {
            panelDetalles.Controls.Clear();
            int yPos = 10;

            foreach (var detalle in _encargue.EncargueDetalles)
            {
                // Grupo Producto
                Label lblProducto = new Label
                {
                    Text = "Producto:",
                    Location = new Point(10, yPos),
                    AutoSize = true
                };
                panelDetalles.Controls.Add(lblProducto);

                TextBox txtProducto = new TextBox
                {
                    Text = detalle.Producto?.Nombre ?? "",
                    Location = new Point(80, yPos),
                    Width = 150,
                    ReadOnly = true,
                    Tag = detalle
                };
                panelDetalles.Controls.Add(txtProducto);

                Button btnSelectProduct = new Button
                {
                    Text = "Seleccionar Producto",
                    Location = new Point(240, yPos),
                    Width = 200,
                    Height = 40,
                    Font = new Font("Arial", 12, FontStyle.Bold)
                };
                btnSelectProduct.Click += async (s, e) => await MostrarProductosAsync(txtProducto, detalle);
                panelDetalles.Controls.Add(btnSelectProduct);

                yPos += 60;

                // Grupo Cantidad
                Label lblCantidad = new Label
                {
                    Text = "Cantidad:",
                    Location = new Point(10, yPos),
                    AutoSize = true
                };
                panelDetalles.Controls.Add(lblCantidad);

                TextBox txtCantidad = new TextBox
                {
                    Text = detalle.Cantidad.ToString(),
                    Location = new Point(80, yPos),
                    Width = 50,
                    Tag = detalle
                };
                txtCantidad.TextChanged += (s, e) =>
                {
                    if (int.TryParse(txtCantidad.Text, out int cantidad))
                    {
                        var det = (EncargueDetalle)txtCantidad.Tag;
                        det.Cantidad = cantidad;
                        ActualizarTotal();
                    }
                };
                panelDetalles.Controls.Add(txtCantidad);
                yPos += 30;

                // Grupo Precio
                Label lblPrecio = new Label
                {
                    Text = "Precio:",
                    Location = new Point(10, yPos),
                    AutoSize = true
                };
                panelDetalles.Controls.Add(lblPrecio);

                TextBox txtPrecio = new TextBox
                {
                    Text = detalle.Producto?.Precio.ToString("C2") ?? "0",
                    Location = new Point(80, yPos),
                    Width = 80,
                    ReadOnly = true
                };
                panelDetalles.Controls.Add(txtPrecio);
                yPos += 30;

                // Grupo Subtotal
                Label lblSubtotal = new Label
                {
                    Text = "Subtotal:",
                    Location = new Point(10, yPos),
                    AutoSize = true
                };
                panelDetalles.Controls.Add(lblSubtotal);

                TextBox txtSubtotal = new TextBox
                {
                    Text = (detalle.Cantidad * (detalle.Producto?.Precio ?? 0)).ToString("C2"),
                    Location = new Point(80, yPos),
                    Width = 80,
                    ReadOnly = true,
                    Tag = detalle
                };
                panelDetalles.Controls.Add(txtSubtotal);
                yPos += 50;
            }
        }

        private async Task MostrarProductosAsync(TextBox txtProducto, EncargueDetalle detalle)
        {
            var productos = await _productoService.GetAllAsync();

            using (var selectProductForm = new Form())
            {
                selectProductForm.Text = "Seleccionar Producto";
                selectProductForm.Size = new Size(400, 500);
                selectProductForm.StartPosition = FormStartPosition.CenterParent;

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
                    Dock = DockStyle.Bottom,
                    Height = 40,
                    Font = new Font("Arial", 12)
                };
                selectProductForm.Controls.Add(btnSelect);

                btnSelect.Click += (s, e) =>
                {
                    if (listBox.SelectedItem is Producto selectedProduct)
                    {
                        detalle.ProductoId = selectedProduct.Id;
                        detalle.Producto = selectedProduct;
                        txtProducto.Text = selectedProduct.Nombre;

                        // Actualizar precio y subtotal
                        var txtPrecio = ObtenerControlHermano(txtProducto, "Precio:") as TextBox;
                        if (txtPrecio != null) txtPrecio.Text = selectedProduct.Precio.ToString("C2");

                        var txtSubtotal = ObtenerControlHermano(txtProducto, "Subtotal:") as TextBox;
                        if (txtSubtotal != null) ActualizarSubtotal(detalle, txtSubtotal);

                        ActualizarTotal();
                        selectProductForm.Close();
                    }
                };

                selectProductForm.ShowDialog();
            }
        }

        private Control ObtenerControlHermano(Control control, string labelText)
        {
            var controls = control.Parent.Controls;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i] is Label label && label.Text == labelText)
                {
                    if (i + 1 < controls.Count && controls[i + 1] is TextBox)
                    {
                        return controls[i + 1];
                    }
                }
            }
            return null;
        }

        private void ActualizarSubtotal(EncargueDetalle detalle, TextBox txtSubtotal)
        {
            decimal subtotal = detalle.Cantidad * (detalle.Producto?.Precio ?? 0);
            txtSubtotal.Text = subtotal.ToString("C2");
        }

        private void ActualizarTotal()
        {
            var txtTotal = Controls.OfType<TextBox>().FirstOrDefault(t => t.Text.StartsWith("$"));
            if (txtTotal != null)
            {
                txtTotal.Text = CalcularTotal().ToString("C2");
            }
        }

        private decimal CalcularTotal()
        {
            return _encargue.EncargueDetalles.Sum(d => d.Cantidad * (d.Producto?.Precio ?? 0));
        }

        private void CargarDatos()
        {
            _detallesBindingSource.DataSource = _encargue.EncargueDetalles;
            CargarDetalles();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Editar Encargue";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var dtpFecha = Controls.OfType<DateTimePicker>().FirstOrDefault();
                if (dtpFecha != null)
                {
                    _encargue.FechaEncargue = dtpFecha.Value;
                }

                await _encarguesService.UpdateEncargueAsync(_encargue);
                MessageBox.Show("Encargue actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el encargue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}