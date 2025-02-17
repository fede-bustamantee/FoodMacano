using FoodMacanoDesktop.Views.Encargues.Web;
using FoodMacanoServices.Services;
using System;
using System.Data;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class WebView : Form
    {
        private readonly DesktopWebService _encarguesService;
        private BindingSource bindingSource;
        private List<Encargue> _encargues;
        private readonly DataTable _detallesTable;

        public WebView()
        {
            InitializeComponent();
            _encarguesService = new DesktopWebService();
            bindingSource = new BindingSource();
            _detallesTable = CreateDetallesTable();
            ConfigureDataGridView();
            ConfigureDetailsGridView();
            LoadEncarguesAsync();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewEncargues.DataSource = bindingSource;
            dataGridViewEncargues.CellDoubleClick += DataGridViewEncargues_CellDoubleClick;
        }

        private void ConfigureDetailsGridView()
        {
            dgvDetalles.AutoGenerateColumns = true;
            dgvDetalles.DataSource = _detallesTable;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Estilo de visualización
            dgvDetalles.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dgvDetalles.DefaultCellStyle.Padding = new Padding(3);

            dataGridViewEncargues.DataSource = bindingSource;
            dataGridViewEncargues.CellDoubleClick += DataGridViewEncargues_CellDoubleClick;

            // Agregar estas configuraciones
            dataGridViewEncargues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEncargues.MultiSelect = false;
            dataGridViewEncargues.AllowUserToAddRows = false;
        }

        private DataTable CreateDetallesTable()
        {
            var table = new DataTable();
            table.Columns.Add("Concepto", typeof(string));
            table.Columns.Add("Valor", typeof(string));
            return table;
        }

        private async void LoadEncarguesAsync()
        {
            try
            {
                _encargues = await _encarguesService.GetAllEncarguesAsync();

                var fechas = _encargues.Select(e => e.FechaEncargue.Date).Distinct().ToList();

                cboFecha.Items.Clear();
                foreach (var fecha in fechas)
                {
                    cboFecha.Items.Add(fecha.ToString("dd/MM/yyyy"));
                }

                if (fechas.Any())
                {
                    cboFecha.SelectedIndex = 0;
                }

                bindingSource.DataSource = _encargues;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los encargues: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewEncargues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var encargue = (Encargue)bindingSource[e.RowIndex];
                ShowEncargueDetails(encargue);
            }
        }

        private void ShowEncargueDetails(Encargue encargue)
        {
            _detallesTable.Rows.Clear();

            // Información del Encargue
            // Información del Encargue
            _detallesTable.Rows.Add("=== DATOS DEL ENCARGUE ===", "");
            _detallesTable.Rows.Add("ID Encargue", encargue.Id);
            _detallesTable.Rows.Add("Número de Encargue", encargue.NumeroEncargue);
            _detallesTable.Rows.Add("Fecha y Hora", encargue.FechaEncargue.ToString("dd/MM/yyyy HH:mm:ss"));

            // Información del Producto
            if (encargue.EncargueDetalles.Any())
            {
                _detallesTable.Rows.Add("", "");
                _detallesTable.Rows.Add("=== PRODUCTOS DEL ENCARGUE ===", "");

                foreach (var detalle in encargue.EncargueDetalles)
                {
                    if (detalle.Producto != null)
                    {
                        _detallesTable.Rows.Add("ID Producto", detalle.Producto.Id);
                        _detallesTable.Rows.Add("Nombre Producto", detalle.Producto.Nombre);
                        _detallesTable.Rows.Add("Cantidad", detalle.Cantidad);
                        _detallesTable.Rows.Add("Precio Unitario", $"${detalle.Producto.Precio:N2}");
                        _detallesTable.Rows.Add("", "------------------");
                    }
                }
            }

            // Información del Usuario
            if (encargue.Usuario != null)
            {
                _detallesTable.Rows.Add("", "");
                _detallesTable.Rows.Add("=== DATOS DEL USUARIO ===", "");
                _detallesTable.Rows.Add("ID Usuario", encargue.Usuario.Id);
                _detallesTable.Rows.Add("Username", encargue.Usuario.User);
                _detallesTable.Rows.Add("Email", encargue.Usuario.Email);
                _detallesTable.Rows.Add("Tipo Usuario", encargue.Usuario.TipoUsuario);
                _detallesTable.Rows.Add("Firebase ID", encargue.Usuario.FirebaseId);
            }

            // Total del Encargue
            _detallesTable.Rows.Add("", "");
            _detallesTable.Rows.Add("=== TOTAL ===", "");

            decimal total = 0;

            foreach (var detalle in encargue.EncargueDetalles) // Asegúrate de que Encargue tiene una lista de EncargueDetalles
            {
                total += (detalle.Producto?.Precio ?? 0) * detalle.Cantidad;
            }

            _detallesTable.Rows.Add("Total del Encargue", $"${total:N2}");


            // Refrescar el DataGridView
            dgvDetalles.Refresh();
            dgvDetalles.AutoResizeRows();
        }

        private void cboFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_encargues == null || !_encargues.Any()) return;

            var fechaSeleccionada = DateTime.Parse(cboFecha.SelectedItem.ToString());

            var encarguesFiltrados = _encargues
                .Where(enc => enc.FechaEncargue.Date == fechaSeleccionada.Date)
                .ToList();

            bindingSource.DataSource = encarguesFiltrados;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var encargue = bindingSource.Current as Encargue;
            if (encargue == null) return;

            var editarEncargueView = new EditarWebView(encargue);
            if (editarEncargueView.ShowDialog() == DialogResult.OK)
            {
                LoadEncarguesAsync();  // Recargar la lista
                ShowEncargueDetails(encargue);  // Actualizar los detalles
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener el encargue seleccionado
            var encargue = bindingSource.Current as Encargue;
            if (encargue == null) return;

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
                    await _encarguesService.DeleteEncargueAsync(encargue.Id);
                    LoadEncarguesAsync();  // Recargar la lista
                    _detallesTable.Clear(); // Limpiar los detalles
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
