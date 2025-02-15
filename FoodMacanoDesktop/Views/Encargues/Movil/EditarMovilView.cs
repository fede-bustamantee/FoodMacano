using FoodMacanoServices.Interfaces;
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
        private readonly ProductoService productoService;

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

        private async void CargarDetalles()
        {
            var detalles = _encargue.Detalles.ToList();
            panelDetalles.Controls.Clear();
            int yPos = 10;

            foreach (var detalle in detalles)
            {
                // Etiqueta Producto
                Label lblProducto = new Label
                {
                    Text = "Producto:",
                    Location = new Point(10, yPos),
                    AutoSize = true
                };
                panelDetalles.Controls.Add(lblProducto);

                // TextBox para Producto
                TextBox txtProducto = new TextBox
                {
                    Text = detalle.NombreProducto,
                    Location = new Point(80, yPos),
                    Width = 150,
                    ReadOnly = true // Hacer que no sea editable
                };
                panelDetalles.Controls.Add(txtProducto);

                // Botón para seleccionar Producto
                Button btnSelectProduct = new Button
                {
                    Text = "Seleccionar Producto", // Cambiar el texto para que sea más claro
                    Location = new Point(240, yPos),
                    Width = 200,  // Aumentar el ancho del botón
                    Height = 40,  // Aumentar la altura del botón
                    Font = new Font("Arial", 12, FontStyle.Bold)  // Cambiar el tamaño de la fuente para hacerlo más visible
                };
                btnSelectProduct.Click += async (s, e) => await MostrarProductosAsync(txtProducto, detalle);
                panelDetalles.Controls.Add(btnSelectProduct);

                yPos += 60; // Ajustar la distancia entre controles

                // Etiqueta Cantidad
                Label lblCantidad = new Label { Text = "Cantidad:", Location = new Point(10, yPos), AutoSize = true };
                panelDetalles.Controls.Add(lblCantidad);

                // TextBox para Cantidad
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

                // Etiqueta Precio
                Label lblPrecio = new Label { Text = "Precio:", Location = new Point(10, yPos), AutoSize = true };
                panelDetalles.Controls.Add(lblPrecio);

                // TextBox para Precio
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

                // Etiqueta Subtotal
                Label lblSubtotal = new Label { Text = "Subtotal:", Location = new Point(10, yPos), AutoSize = true };
                panelDetalles.Controls.Add(lblSubtotal);

                // TextBox para Subtotal
                TextBox txtSubtotal = new TextBox
                {
                    Text = detalle.Subtotal.ToString("C2"),
                    Location = new Point(80, yPos),
                    Width = 80,
                    ReadOnly = true
                };
                panelDetalles.Controls.Add(txtSubtotal);
                yPos += 40;
                _detallesBindingSource.ResetBindings(false);
            }
        }
        private async Task MostrarProductosAsync(TextBox txtProducto, MauiEncargueDetalle detalle)
        {
            // Obtener la lista de productos disponibles
            var productos = await productoService.GetAllAsync();

            // Crear el formulario para seleccionar el producto
            using (var selectProductForm = new Form())
            {
                ListBox listBox = new ListBox
                {
                    DataSource = productos,
                    DisplayMember = "Nombre", // Muestra el nombre del producto
                    ValueMember = "Id", // Usa el Id para identificar el producto seleccionado
                    Dock = DockStyle.Fill
                };
                selectProductForm.Controls.Add(listBox);

                Button btnSelect = new Button
                {
                    Text = "Seleccionar",
                    Dock = DockStyle.Bottom
                };
                selectProductForm.Controls.Add(btnSelect);

                // Al hacer clic en "Seleccionar", actualizamos el TextBox
                btnSelect.Click += (s, e) =>
                {
                    if (listBox.SelectedItem is Producto selectedProduct)
                    {
                        detalle.NombreProducto = selectedProduct.Nombre; // Actualizamos el nombre del producto en el detalle
                        txtProducto.Text = selectedProduct.Nombre; // Actualizamos el TextBox
                        selectProductForm.Close();
                    }
                };

                selectProductForm.ShowDialog(); // Muestra el formulario
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

            // Actualizar los detalles
            CargarDetalles(); // Esto recargará los detalles en la vista
            _detallesBindingSource.ResetBindings(false);

            // Notificar que los datos fueron actualizados
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
