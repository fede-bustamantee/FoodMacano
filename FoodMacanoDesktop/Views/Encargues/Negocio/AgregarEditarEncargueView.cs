using FoodMacanoServices.Models;
using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Services.Common;
using FoodMacanoServices.Services.Orders;

namespace FoodMacanoDesktop.Views.Encargues.Negocio
{
    public partial class AgregarEditarEncargueView : Form
    {
        private DesktopEncargueService encargueService = new DesktopEncargueService();
        private ProductoService productoService = new ProductoService();
        private DesktopEncargue encargue;

        public AgregarEditarEncargueView(DesktopEncargue encargueEdit)
        {
            InitializeComponent(); 
            this.encargue = encargueEdit;  // Asigna el encargue recibido para editarlo
            txtMesa.Text = encargueEdit.NumeroMesa;  // Rellena el número de mesa
            nudCantidad.Value = encargueEdit.Cantidad;
            CargarProductos(); 
        }

        // Método asíncrono para cargar la lista de productos disponibles
        private async void CargarProductos()
        {
            try
            {
                // Se obtienen todos los productos de la base de datos
                var productos = await productoService.GetAllAsync();
                cboProductos.DataSource = productos; 
                cboProductos.DisplayMember = "Nombre";  
                cboProductos.ValueMember = "Id";  

                // Se selecciona automáticamente el producto que corresponde al encargue editado
                var productoActual = productos.FirstOrDefault(p => p.Id == encargue.ProductoId);
                if (productoActual != null)
                {
                    cboProductos.SelectedValue = productoActual.Id;  // Establece el valor seleccionado en el combo box
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())  // Verifica si los datos son válidos
            {
                try
                {
                    // Se obtiene el producto seleccionado en el combo box
                    var productoSeleccionado = (Producto)cboProductos.SelectedItem;

                    // Se actualizan los datos del encargue con los valores actuales del formulario
                    encargue.ProductoId = productoSeleccionado.Id;
                    encargue.NombreProducto = productoSeleccionado.Nombre;
                    encargue.Cantidad = (int)nudCantidad.Value;
                    encargue.PrecioUnitario = productoSeleccionado.Precio;
                    encargue.Total = encargue.Cantidad * encargue.PrecioUnitario;  // Calcula el total
                    encargue.NumeroMesa = txtMesa.Text.Trim();  // Obtiene el número de mesa

                    // Llama al servicio para actualizar el encargue en la base de datos
                    await encargueService.UpdateEncargueAsync(encargue);

                    // Si la actualización es exitosa, se cierra el formulario
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Si ocurre un error al actualizar el encargue, se muestra un mensaje de error
                    MessageBox.Show($"Error al actualizar el encargue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidarDatos()
        {
            // Verifica que se haya seleccionado un producto
            if (cboProductos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Verifica que la cantidad sea mayor a 0
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;  // Si las validaciones son correctas, devuelve true
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}