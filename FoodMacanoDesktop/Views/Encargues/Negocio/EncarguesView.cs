using FoodMacanoServices.Models;
using FoodMacanoDesktop.Views.Encargues.Negocio;
using FoodMacanoDesktop.Views.Menu;
using FoodMacanoServices.Services.Orders;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class EncarguesView : Form
    {
        // Servicios para interactuar
        private DesktopEncargueService _encargueService = new DesktopEncargueService();
        public BindingSource listaEncargues = new BindingSource();
        private List<DesktopEncargue> encarguesOriginales = new List<DesktopEncargue>();

        public EncarguesView()
        {
            InitializeComponent();
            dgvEncargues.DataSource = listaEncargues;

            // Suscribe a los eventos de cambio de fecha y selección de mesa
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            cboMesas.SelectedIndexChanged += cboMesas_SelectedIndexChanged;

            // Carga los encargues correspondientes a la fecha seleccionada
            LoadEncarguesPorFecha(dtpFecha.Value);
        }

        // Carga los encargues filtrados por fecha
        private async void LoadEncarguesPorFecha(DateTime fecha)
        {
            try
            {
                // Obtiene los encargues desde el servicio
                var encargues = await _encargueService.GetEncarguesAsync();
                encarguesOriginales = encargues.Where(e => e.FechaEncargue.Date == fecha.Date).ToList();

                // Asigna los encargues filtrados a la lista que se muestra en el DataGridView
                listaEncargues.DataSource = new List<DesktopEncargue>(encarguesOriginales); // Se clona para evitar modificar la lista original
                OcultarColumnas(); // Oculta algunas columnas innecesarias
                LoadMesasDisponibles(encarguesOriginales); // Carga las mesas disponibles

                // Configura el formato de las columnas de precio
                dgvEncargues.Columns["PrecioUnitario"].DefaultCellStyle.Format = "N2";  // Formato con 2 decimales
                dgvEncargues.Columns["Total"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar encargues: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga las mesas disponibles en el ComboBox
        private void LoadMesasDisponibles(List<DesktopEncargue> encarguesFiltrados)
        {
            // Desvincula el evento antes de modificar el ComboBox
            cboMesas.SelectedIndexChanged -= cboMesas_SelectedIndexChanged;

            var mesas = encarguesFiltrados.Select(e => e.NumeroMesa).Distinct().ToList(); // Obtiene mesas únicas
            mesas.Insert(0, "Todas"); // Agrega la opción "Todas"
            cboMesas.DataSource = mesas;

            // Vuelve a vincular el evento después de modificar el ComboBox
            cboMesas.SelectedIndexChanged += cboMesas_SelectedIndexChanged;
        }

        // Evento cuando cambia la fecha en el DateTimePicker
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            LoadEncarguesPorFecha(dtpFecha.Value); // Recarga los encargues para la nueva fecha
        }

        // Evento cuando cambia la selección de mesa en el ComboBox
        private void cboMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarEncargues(); // Aplica el filtro de mesa a los encargues
        }

        // Filtra los encargues según la mesa seleccionada
        private void FiltrarEncargues()
        {
            var fechaSeleccionada = dtpFecha.Value.Date;
            var mesaSeleccionada = cboMesas.SelectedItem?.ToString();

            // Filtra los encargues por la fecha seleccionada
            var encarguesFiltrados = encarguesOriginales.Where(e => e.FechaEncargue.Date == fechaSeleccionada).ToList();

            // Si se selecciona una mesa específica, filtra también por la mesa
            if (!string.IsNullOrEmpty(mesaSeleccionada) && mesaSeleccionada != "Todas")
            {
                encarguesFiltrados = encarguesFiltrados.Where(e => e.NumeroMesa == mesaSeleccionada).ToList();
            }

            // Actualiza la lista de encargues filtrados en el BindingSource
            listaEncargues.DataSource = encarguesFiltrados;
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listaEncargues.Current is not DesktopEncargue encargue)
            {
                MessageBox.Show("Por favor seleccione un encargue para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Está seguro que quiere eliminar el encargue de {encargue.NombreProducto}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                // Elimina el encargue usando el servicio
                await _encargueService.DeleteEncargueAsync(encargue.Id);
                LoadEncarguesPorFecha(dtpFecha.Value); // Recarga los encargues después de la eliminación
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listaEncargues.Current is not DesktopEncargue encargue)
            {
                MessageBox.Show("Por favor seleccione un encargue para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Guarda la mesa seleccionada para mantenerla después de la edición
            string mesaSeleccionadaActual = cboMesas.SelectedItem?.ToString();

            // Abre la vista de agregar/editar encargue
            var agregarEditarEncargueView = new AgregarEditarEncargueView(encargue);

            // Si hay un menú principal abierto, lo usa para abrir el formulario
            MenuPrincipalView? menu = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();
            if (menu != null)
            {
                menu.AbrirFormulariosHijos(agregarEditarEncargueView);
                agregarEditarEncargueView.FormClosed += (s, args) => {
                    if (agregarEditarEncargueView.DialogResult == DialogResult.OK)
                        RecargarDatosYMantenerSeleccion(mesaSeleccionadaActual);
                };
            }
            else if (agregarEditarEncargueView.ShowDialog() == DialogResult.OK)
                RecargarDatosYMantenerSeleccion(mesaSeleccionadaActual);
        }

        // Recarga los datos de los encargues y mantiene la selección de mesa
        private async void RecargarDatosYMantenerSeleccion(string mesaSeleccionada)
        {
            try
            {
                // Desvincula el evento para evitar disparos innecesarios durante la recarga
                cboMesas.SelectedIndexChanged -= cboMesas_SelectedIndexChanged;

                // Recarga los encargues desde el servicio
                var encargues = await _encargueService.GetEncarguesAsync();
                encarguesOriginales = encargues.Where(e => e.FechaEncargue.Date == dtpFecha.Value.Date).ToList();
                listaEncargues.DataSource = new List<DesktopEncargue>(encarguesOriginales); // Clona la lista original
                OcultarColumnas(); // Oculta las columnas innecesarias

                // Configura el formato de las columnas de precio
                dgvEncargues.Columns["PrecioUnitario"].DefaultCellStyle.Format = "N2";
                dgvEncargues.Columns["Total"].DefaultCellStyle.Format = "N2";

                // Vuelve a cargar las mesas disponibles
                var mesas = encarguesOriginales.Select(e => e.NumeroMesa).Distinct().ToList();
                mesas.Insert(0, "Todas");
                cboMesas.DataSource = mesas;

                // Mantiene la mesa seleccionada si sigue disponible
                if (!string.IsNullOrEmpty(mesaSeleccionada) && mesas.Contains(mesaSeleccionada))
                    cboMesas.SelectedItem = mesaSeleccionada;

                // Vuelve a vincular el evento de selección de mesa
                cboMesas.SelectedIndexChanged += cboMesas_SelectedIndexChanged;

                // Si no se seleccionó "Todas", aplica el filtro de mesa
                if (mesaSeleccionada != "Todas" && !string.IsNullOrEmpty(mesaSeleccionada))
                    FiltrarEncargues();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recargar encargues: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OcultarColumnas()
        {
            if (dgvEncargues.Columns.Count == 0) return; // Evita el error si no hay columnas

            // Oculta las columnas de Id, ProductoId y FechaEncargue
            if (dgvEncargues.Columns.Contains("Id"))
                dgvEncargues.Columns["Id"].Visible = false;
            if (dgvEncargues.Columns.Contains("ProductoId"))
                dgvEncargues.Columns["ProductoId"].Visible = false;
            if (dgvEncargues.Columns.Contains("FechaEncargue"))
                dgvEncargues.Columns["FechaEncargue"].Visible = false;
        }
    }
}