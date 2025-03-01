using FoodMacanoDesktop.Views.Encargues.Movil;
using FoodMacanoDesktop.Views.Menu;
using FoodMacanoServices.Models.Orders;
using FoodMacanoServices.Services.Orders;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class MovilView : Form
    {
        private DesktopMovilService _encarguesService;
        private BindingSource bindingSource;
        private List<MauiEncargue> _encargues;

        public MovilView()
        {
            InitializeComponent();
            _encarguesService = new DesktopMovilService();
            // Inicializamos el BindingSource para enlazar datos
            bindingSource = new BindingSource();
            ConfigureDataGridView();
            LoadEncarguesAsync();

            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
        }

        // Configura las columnas del DataGridView para mostrar los encargues
        private void ConfigureDataGridView()
        {
            dataGridViewEncargues.AutoGenerateColumns = false;
            // Enlazamos el DataGridView con el BindingSource
            dataGridViewEncargues.DataSource = bindingSource;

            // Limpiamos las columnas previas y las agregamos nuevamente
            dataGridViewEncargues.Columns.Clear();
            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "UserDisplayName" });
            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Dirección", DataPropertyName = "Direccion" });
            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "FechaEncargue" });
            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total", DataPropertyName = "Total", DefaultCellStyle = { Format = "C2" } });

            // Agregamos el evento de doble clic para mostrar detalles del encargue
            dataGridViewEncargues.CellDoubleClick += DataGridViewEncargues_CellDoubleClick;
        }

        // Método asíncrono para cargar todos los encargues
        private async void LoadEncarguesAsync()
        {
            try
            {
                // Obtenemos todos los encargues a través del servicio
                _encargues = await _encarguesService.GetAllEncarguesAsync();
                // Filtramos los encargues por la fecha seleccionada
                FilterEncarguesByDate(dtpFecha.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los encargues: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método que se ejecuta cuando se cambia la fecha en el DateTimePicker
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            // Filtramos los encargues por la fecha seleccionada
            FilterEncarguesByDate(dtpFecha.Value);
        }

        // Filtra los encargues según la fecha proporcionada
        private void FilterEncarguesByDate(DateTime fecha)
        {
            // Si no hay encargues cargados, no hacemos nada
            if (_encargues == null || !_encargues.Any()) return;

            // Filtramos la lista de encargues para mostrar solo los de la fecha seleccionada
            var encarguesFiltrados = _encargues
                .Where(enc => enc.FechaEncargue.Date == fecha.Date)
                .ToList();

            // Enlazamos los encargues filtrados al BindingSource
            bindingSource.DataSource = encarguesFiltrados;
        }
        private void DataGridViewEncargues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que el índice de la fila seleccionada sea válido
            if (e.RowIndex < 0) return;

            // Obtenemos el encargue seleccionado
            var encargueSeleccionado = bindingSource.Current as MauiEncargue;
            if (encargueSeleccionado == null) return;

            // Llamamos al método para mostrar los detalles del encargue
            MostrarDetalles(encargueSeleccionado);
        }

        // Muestra los detalles del encargue seleccionado en un DataGridView adicional
        private void MostrarDetalles(MauiEncargue encargue)
        {
            // Limpiamos los detalles previos
            dataGridViewDetalles.DataSource = null;
            // Asignamos los detalles del encargue seleccionado
            dataGridViewDetalles.DataSource = encargue?.Detalles ?? new List<MauiEncargueDetalle>();

            // Ocultamos las columnas que no son necesarias
            OcultarColumnas(dataGridViewDetalles, "Id", "EncargueId", "Encargue", "ProductoId", "Producto", "Subtotal");

            // Formateamos el precio unitario para mostrar dos decimales
            if (dataGridViewDetalles.Columns["PrecioUnitario"] != null)
            {
                dataGridViewDetalles.Columns["PrecioUnitario"].DefaultCellStyle.Format = "N2";
            }
        }

        private void OcultarColumnas(DataGridView dgv, params string[] nombresColumnas)
        {
            if (dgv.Columns.Count == 0) return;

            foreach (var nombre in nombresColumnas)
            {
                if (dgv.Columns.Contains(nombre))
                {
                    dgv.Columns[nombre].Visible = false;
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtenemos el encargue seleccionado
            var encargue = bindingSource.Current as MauiEncargue;
            if (encargue == null) return;

            // Pedimos confirmación al usuario antes de eliminar
            var respuesta = MessageBox.Show(
                $"¿Está seguro que desea eliminar el encargue de {encargue.UserDisplayName}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Si el usuario confirma, eliminamos el encargue
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Llamamos al servicio para eliminar el encargue
                    await _encarguesService.DeleteEncargueAsync(encargue.Id);
                    // Recargamos la lista de encargues
                    LoadEncarguesAsync();
                    // Mostramos un mensaje de éxito
                    MessageBox.Show("Encargue eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiamos los detalles mostrados
                    MostrarDetalles(null);
                }
                catch (Exception ex)
                {
                    // En caso de error, mostramos un mensaje
                    MessageBox.Show($"Error al eliminar el encargue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Obtenemos el encargue seleccionado
            var encargue = bindingSource.Current as MauiEncargue;
            if (encargue == null) return;

            // Creamos una nueva vista para editar el encargue
            var editarEncargueView = new EditarMovilView(encargue);

            // Verificamos si existe un formulario principal abierto
            MenuPrincipalView? menu = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();
            if (menu != null)
            {
                // Si existe, abrimos el formulario de edición como hijo del menú
                menu.AbrirFormulariosHijos(editarEncargueView);
            }
            else
            {
                // Si no existe un menú, mostramos el formulario de edición de forma independiente
                editarEncargueView.ShowDialog();
            }
        }
    }
}