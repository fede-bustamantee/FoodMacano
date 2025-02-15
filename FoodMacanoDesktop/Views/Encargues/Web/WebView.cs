using FoodMacanoDesktop.Views.Encargues.Web;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
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
                labelTotal.Text = $"Total de encargues: {_encargues.Count}";
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
            _detallesTable.Rows.Add("=== DATOS DEL ENCARGUE ===", "");
            _detallesTable.Rows.Add("ID Encargue", encargue.Id);
            _detallesTable.Rows.Add("Número de Encargue", encargue.NumeroEncargue);
            _detallesTable.Rows.Add("Fecha y Hora", encargue.FechaEncargue.ToString("dd/MM/yyyy HH:mm:ss"));
            _detallesTable.Rows.Add("Cantidad", encargue.Cantidad);

            // Información del Producto
            if (encargue.Producto != null)
            {
                _detallesTable.Rows.Add("", "");
                _detallesTable.Rows.Add("=== DATOS DEL PRODUCTO ===", "");
                _detallesTable.Rows.Add("ID Producto", encargue.Producto.Id);
                _detallesTable.Rows.Add("Nombre Producto", encargue.Producto.Nombre);
                _detallesTable.Rows.Add("Precio Unitario", $"${encargue.Producto.Precio:N2}");
                _detallesTable.Rows.Add("Calidad", encargue.Producto.Calidad);
                _detallesTable.Rows.Add("Calorías", $"{encargue.Producto.Calorias} cal");
                _detallesTable.Rows.Add("Categoría ID", encargue.Producto.CategoriaId);
                _detallesTable.Rows.Add("Descripción ID", encargue.Producto.DescripcionProductoId);
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
            decimal total = (encargue.Producto?.Precio ?? 0) * encargue.Cantidad;
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
            labelTotal.Text = $"Total de encargues: {encarguesFiltrados.Count}";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar la selección de manera más robusta
            if (dataGridViewEncargues.CurrentRow != null && dataGridViewEncargues.CurrentRow.Index != -1)
            {
                var encargueSeleccionado = dataGridViewEncargues.CurrentRow.DataBoundItem as Encargue;
                if (encargueSeleccionado != null)
                {
                    using (var editarForm = new EditarWebView(encargueSeleccionado))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadEncarguesAsync();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener el encargue seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un encargue para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Aplicar el mismo patrón para el botón eliminar
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEncargues.CurrentRow != null && dataGridViewEncargues.CurrentRow.Index != -1)
            {
                var encargueSeleccionado = dataGridViewEncargues.CurrentRow.DataBoundItem as Encargue;
                if (encargueSeleccionado != null)
                {
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de eliminar el encargue N° {encargueSeleccionado.NumeroEncargue}?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            await _encarguesService.DeleteEncargueAsync(encargueSeleccionado.Id);
                            LoadEncarguesAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar el encargue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener el encargue seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un encargue para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
