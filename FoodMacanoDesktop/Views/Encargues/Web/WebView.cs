using FoodMacanoDesktop.Views.Encargues.Web;
using FoodMacanoDesktop.Views.Menu;
using FoodMacanoServices.Services.Orders;
using System.Data;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class WebView : Form
    {
        private DesktopWebService _encarguesService;
        private BindingSource bindingSource;
        private List<Encargue> _encargues;
        public WebView()
        {
            InitializeComponent();
            _encarguesService = new DesktopWebService(); // Instancia el servicio que manejará los encargues.
            bindingSource = new BindingSource(); // Instancia la fuente de datos para el DataGridView.

            // Configura las columnas del DataGridView.
            ConfigureDataGridView();

            // Configura los eventos para los controles.
            dataGridViewEncargues.CellDoubleClick += DataGridViewEncargues_CellDoubleClick;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;

            LoadEncarguesAsync();
        }

        // Evento que se dispara cuando el valor de la fecha en el control dtpFecha cambia.
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            // Filtra los encargues según la fecha seleccionada.
            FilterEncarguesByDate(dtpFecha.Value);
        }

        // Configura las columnas del DataGridView donde se mostrarán los encargues.
        private void ConfigureDataGridView()
        {
            dataGridViewEncargues.AutoGenerateColumns = false; // Evita la generación automática de columnas.
            dataGridViewEncargues.Columns.Clear(); // Limpia las columnas actuales.

            // Agrega las columnas deseadas con sus respectivas configuraciones.
            dataGridViewEncargues.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Usuario",
                    DataPropertyName = "Usuario.User",
                    HeaderText = "Cliente",
                    ReadOnly = true,
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "FechaEncargue",
                    DataPropertyName = "FechaEncargue",
                    HeaderText = "Fecha",
                    ReadOnly = true,
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    HeaderText = "Total",
                    ReadOnly = true,
                    Width = 100
                }
            });
        }

        // Filtra los encargues de acuerdo con la fecha seleccionada.
        private void FilterEncarguesByDate(DateTime fecha)
        {
            if (_encargues == null || !_encargues.Any()) return;

            // Filtra la lista de encargues para mostrar solo los que coinciden con la fecha seleccionada.
            var encarguesFiltrados = _encargues
                .Where(enc => enc.FechaEncargue.Date == fecha.Date)
                .Select(enc => new
                {
                    EncargueOriginal = enc,
                    Usuario = enc.Usuario,
                    Total = enc.EncargueDetalles.Sum(d => d.Cantidad * d.Producto.Precio)
                })
                .ToList();

            // Limpia las filas actuales del DataGridView.
            dataGridViewEncargues.Rows.Clear();

            // Agrega los encargues filtrados al DataGridView.
            foreach (var enc in encarguesFiltrados)
            {
                int rowIndex = dataGridViewEncargues.Rows.Add(
                    enc.Usuario?.User ?? "N/A",
                    enc.EncargueOriginal.FechaEncargue.ToString("dd/MM/yyyy HH:mm"),
                    $"${enc.Total:N2}"
                );
                // Asocia el objeto de encargue con la fila para su posterior acceso.
                dataGridViewEncargues.Rows[rowIndex].Tag = enc.EncargueOriginal;
            }
        }
        private async void LoadEncarguesAsync()
        {
            try
            {
                // Obtiene los encargues desde el servicio.
                _encargues = await _encarguesService.GetAllEncarguesAsync();
                // Filtra los encargues de acuerdo con la fecha seleccionada en el control dtpFecha.
                FilterEncarguesByDate(dtpFecha.Value);
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre algún problema al cargar los encargues.
                MessageBox.Show($"Error al cargar los encargues: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento que se dispara cuando se hace doble clic en una fila del DataGridView.
        private void DataGridViewEncargues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si se hizo doble clic en una fila válida.
            if (e.RowIndex < 0) return;

            // Obtiene el objeto encargue asociado con la fila seleccionada.
            var encargue = dataGridViewEncargues.Rows[e.RowIndex].Tag as Encargue;
            if (encargue != null)
            {
                // Muestra los detalles del encargue seleccionado.
                ShowEncargueDetails(encargue);
            }
        }

        // Muestra los detalles del encargue seleccionado en el DataGridView dgvDetalles.
        private void ShowEncargueDetails(Encargue encargue)
        {
            try
            {
                dgvDetalles.DataSource = null; // Limpia el DataGridView antes de cargar los nuevos datos.

                if (encargue?.EncargueDetalles != null && encargue.EncargueDetalles.Any())
                {
                    // Filtra los detalles del encargue para mostrar el nombre, cantidad y precio de cada producto.
                    var detallesFiltrados = encargue.EncargueDetalles.Select(ed => new
                    {
                        Producto = ed.Producto.Nombre,
                        Cantidad = ed.Cantidad,
                        PrecioUnitario = ed.Producto.Precio 
                    }).ToList();

                    // Asigna los detalles al DataGridView.
                    dgvDetalles.DataSource = detallesFiltrados;

                    // Opcional: Formatea las columnas según sea necesario (ejemplo, el precio con dos decimales).
                    foreach (DataGridViewColumn column in dgvDetalles.Columns)
                    {
                        if (column.Name == "PrecioUnitario")
                        {
                            column.DefaultCellStyle.Format = "N2"; // Formatea el precio unitario con dos decimales.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar los detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView.
            if (dataGridViewEncargues.CurrentRow?.Tag is Encargue encargue)
            {
                var editarEncargueView = new EditarWebView(encargue);
                // Agrega un manejador para el evento FormClosed para recargar los encargues si se edita uno.
                editarEncargueView.FormClosed += (s, args) =>
                {
                    if (((Form)s).DialogResult == DialogResult.OK)
                    {
                        LoadEncarguesAsync(); // Recarga los encargues.
                        ShowEncargueDetails(encargue); // Muestra los detalles del encargue editado.
                    }
                };

                // Verifica si hay un formulario de menú abierto para cargar el formulario hijo.
                MenuPrincipalView? menu = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();
                if (menu != null)
                {
                    menu.AbrirFormulariosHijos(editarEncargueView);
                }
                else
                {
                    // Si no hay un formulario de menú, muestra el formulario de edición como un diálogo.
                    editarEncargueView.ShowDialog();
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView.
            if (dataGridViewEncargues.CurrentRow?.Tag is Encargue encargue)
            {
                // Muestra una ventana de confirmación para eliminar el encargue.
                var respuesta = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el encargue #{encargue.NumeroEncargue}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        // Elimina el encargue mediante el servicio.
                        await _encarguesService.DeleteEncargueAsync(encargue.Id);
                        LoadEncarguesAsync(); // Recarga los encargues después de la eliminación.
                        dgvDetalles.DataSource = null; // Limpia los detalles del encargue.
                        MessageBox.Show("Encargue eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el encargue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}