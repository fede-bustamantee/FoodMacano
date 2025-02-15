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

namespace FoodMacanoDesktop.Views.Encargues.Movil
{
    public partial class EditarMovilView : Form
    {
        private readonly DesktopMovilService _encarguesService;
        private readonly MauiEncargue _encargue;
        private BindingSource _detallesBindingSource;

        public EditarMovilView(MauiEncargue encargue)
        {
            InitializeComponent();
            _encarguesService = new DesktopMovilService();
            _encargue = encargue;
            _detallesBindingSource = new BindingSource();

            ConfigurarFormulario();
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            // Configurar los controles para editar el encargue
            txtCliente.Text = _encargue.UserDisplayName;
            txtDireccion.Text = _encargue.Direccion;
            dtpFecha.Value = _encargue.FechaEncargue;
            txtTotal.Text = _encargue.Total.ToString("C2");

            // Cargar los detalles en los TextBox del diseño
            CargarDetalles();
        }

        private void CargarDetalles()
        {
            var detalles = _encargue.Detalles.ToList();
            panelDetalles.Controls.Clear();
            int yPos = 10;

            foreach (var detalle in detalles)
            {
                Label lblProducto = new Label
                {
                    Text = "Producto:",
                    Location = new Point(10, yPos),
                    AutoSize = true
                };
                panelDetalles.Controls.Add(lblProducto);

                TextBox txtProducto = new TextBox
                {
                    Text = detalle.NombreProducto,
                    Location = new Point(80, yPos),
                    Width = 150,
                    ReadOnly = true // Hacer que no sea editable
                };
                panelDetalles.Controls.Add(txtProducto);
                yPos += 30;

                Label lblCantidad = new Label { Text = "Cantidad:", Location = new Point(10, yPos), AutoSize = true };
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
                        ((MauiEncargueDetalle)txtCantidad.Tag).Cantidad = cantidad;
                    }
                };
                panelDetalles.Controls.Add(txtCantidad);
                yPos += 30;

                Label lblPrecio = new Label { Text = "Precio:", Location = new Point(10, yPos), AutoSize = true };
                panelDetalles.Controls.Add(lblPrecio);

                TextBox txtPrecio = new TextBox
                {
                    Text = detalle.PrecioUnitario.ToString("C2"),
                    Location = new Point(80, yPos),
                    Width = 80,
                    Tag = detalle
                };
                txtPrecio.TextChanged += (s, e) =>
                {
                    if (decimal.TryParse(txtPrecio.Text, out decimal precio))
                    {
                        ((MauiEncargueDetalle)txtPrecio.Tag).PrecioUnitario = precio;
                    }
                };
                panelDetalles.Controls.Add(txtPrecio);
                yPos += 30;

                Label lblSubtotal = new Label { Text = "Subtotal:", Location = new Point(10, yPos), AutoSize = true };
                panelDetalles.Controls.Add(lblSubtotal);

                TextBox txtSubtotal = new TextBox
                {
                    Text = detalle.Subtotal.ToString("C2"),
                    Location = new Point(80, yPos),
                    Width = 80,
                    ReadOnly = true
                };
                panelDetalles.Controls.Add(txtSubtotal);
                yPos += 40;
            }
        }

        private void CargarDatos()
        {
            _detallesBindingSource.DataSource = _encargue.Detalles;
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            _encargue.UserDisplayName = txtCliente.Text;
            _encargue.Direccion = txtDireccion.Text;
            _encargue.FechaEncargue = dtpFecha.Value;

            await _encarguesService.UpdateEncargueAsync(_encargue);

            // Notificar que los datos fueron actualizados
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
