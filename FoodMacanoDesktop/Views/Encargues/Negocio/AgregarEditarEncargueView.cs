using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Encargues.Negocio
{
    public partial class AgregarEditarEncargueView : Form
    {
        private readonly DesktopEncargueService encargueService = new DesktopEncargueService();
        private readonly ProductoService productoService = new ProductoService();
        private DesktopEncargue encargue;

        public AgregarEditarEncargueView(DesktopEncargue encargueEdit)
        {
            InitializeComponent();
            this.encargue = encargueEdit;
            txtMesa.Text = encargueEdit.NumeroMesa;
            nudCantidad.Value = encargueEdit.Cantidad;
            CargarProductos();
        }

        private async void CargarProductos()
        {
            try
            {
                var productos = await productoService.GetAllAsync();
                cboProductos.DataSource = productos;
                cboProductos.DisplayMember = "Nombre";
                cboProductos.ValueMember = "Id";

                var productoActual = productos.FirstOrDefault(p => p.Id == encargue.ProductoId);
                if (productoActual != null)
                {
                    cboProductos.SelectedValue = productoActual.Id;
                }
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

                    await encargueService.UpdateEncargueAsync(encargue);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el encargue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarDatos()
        {
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

    }
}
