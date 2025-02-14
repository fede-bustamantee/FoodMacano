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

namespace FoodMacanoDesktop.Views.Encargues.Negocio
{
    public partial class AgregarEditarEncargueView : Form
    {
        DesktopEncargueService encargueService = new DesktopEncargueService();
        ProductoService productoService = new ProductoService();
        DesktopEncargue encargue;

        // Constructor para agregar
        public AgregarEditarEncargueView(string numeroMesa)
        {
            InitializeComponent();
            encargue = new DesktopEncargue
            {
                NumeroMesa = numeroMesa,
                FechaEncargue = DateTime.Now
            };
            txtMesa.Text = numeroMesa;
            CargarProductos();
        }

        // Constructor para editar
        public AgregarEditarEncargueView(DesktopEncargue encargueEdit)
        {
            InitializeComponent();
            this.encargue = encargueEdit;
            txtMesa.Text = encargueEdit.NumeroMesa;
            nudCantidad.Value = encargueEdit.Cantidad;
            txtPrecioUnitario.Text = encargueEdit.PrecioUnitario.ToString();
            lblTotal.Text = encargueEdit.Total.ToString("C");
            CargarProductos();

            // Si estamos editando, seleccionar el producto actual
            if (cboProductos.Items.Count > 0)
            {
                var productos = (List<Producto>)cboProductos.DataSource;
                var productoActual = productos.FirstOrDefault(p => p.Id == encargueEdit.ProductoId);
                if (productoActual != null)
                {
                    cboProductos.SelectedValue = productoActual.Id;
                }
            }
        }

        private async void CargarProductos()
        {
            try
            {
                var productos = await productoService.GetAllAsync();
                cboProductos.DataSource = productos;
                cboProductos.DisplayMember = "Nombre";
                cboProductos.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    var productoSeleccionado = (Producto)cboProductos.SelectedItem;
                    encargue.ProductoId = productoSeleccionado.Id;
                    encargue.NombreProducto = productoSeleccionado.Nombre;
                    encargue.Cantidad = (int)nudCantidad.Value;
                    encargue.PrecioUnitario = productoSeleccionado.Precio;
                    encargue.Total = encargue.Cantidad * encargue.PrecioUnitario;

                    if (encargue.Id == 0)
                    {
                        await encargueService.AddEncargueAsync(encargue);
                    }
                    else
                    {
                        await encargueService.UpdateEncargueAsync(encargue);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el encargue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtMesa.Text))
            {
                MessageBox.Show("Debe ingresar un número de mesa", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboProductos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductos.SelectedItem is Producto productoSeleccionado)
            {
                txtPrecioUnitario.Text = productoSeleccionado.Precio.ToString("C");
                CalcularTotal();
            }
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            if (cboProductos.SelectedItem is Producto productoSeleccionado)
            {
                decimal total = productoSeleccionado.Precio * nudCantidad.Value;
                lblTotal.Text = total.ToString("C");
            }
        }
    }
}