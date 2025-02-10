using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System.Text;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class MovilView : Form
    {
        private readonly MauiEncargueService _encargueService;
        private BindingSource _bindingSource;

        public MovilView(IAuthService authService)
        {
            InitializeComponent();
            _encargueService = new MauiEncargueService(authService);
            _bindingSource = new BindingSource();
            InitializeDataGridView();
            LoadEncarguesAsync();
        }

        private void InitializeDataGridView()
        {
            // Create DataGridView if not already in designer
            dgvEncargues = new DataGridView();
            dgvEncargues.Dock = DockStyle.Fill;

            // Configure columns
            dgvEncargues.AutoGenerateColumns = false;
            dgvEncargues.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    DataPropertyName = "Id",
                    HeaderText = "ID",
                    Width = 50
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "FechaEncargue",
                    DataPropertyName = "FechaEncargue",
                    HeaderText = "Fecha",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Estado",
                    DataPropertyName = "Estado",
                    HeaderText = "Estado",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    DataPropertyName = "Total",
                    HeaderText = "Total",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "UserId",
                    DataPropertyName = "UserId",
                    HeaderText = "Usuario",
                    Width = 150
                }
            });

            // Configure DataGridView properties
            dgvEncargues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEncargues.ReadOnly = true;
            dgvEncargues.AllowUserToAddRows = false;
            dgvEncargues.AllowUserToDeleteRows = false;
            dgvEncargues.MultiSelect = false;

            // Add DataGridView to form
            Controls.Add(dgvEncargues);

            // Add double-click handler for viewing details
            dgvEncargues.CellDoubleClick += DgvEncargues_CellDoubleClick;

            // Bind data source
            dgvEncargues.DataSource = _bindingSource;
        }

        private async void LoadEncarguesAsync()
        {
            try
            {
                UseWaitCursor = true;
                var encargues = await _encargueService.GetEncarguesAsync(string.Empty); // You might want to pass a specific userId
                _bindingSource.DataSource = encargues;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los encargues: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private async void DgvEncargues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var encargue = (MauiEncargue)_bindingSource[e.RowIndex];
            try
            {
                var detalles = await _encargueService.GetEncargueConDetallesAsync(encargue.Id);
                ShowDetallesForm(detalles);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los detalles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDetallesForm(MauiEncargue encargue)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Encargue ID: {encargue.Id}");
            sb.AppendLine($"Fecha: {encargue.FechaEncargue}");
            sb.AppendLine($"Estado: {encargue.Estado}");
            sb.AppendLine($"Total: {encargue.Total:C2}");
            sb.AppendLine("\nDetalles:");

            foreach (var detalle in encargue.Detalles)
            {
                sb.AppendLine($"- {detalle.NombreProducto} x{detalle.Cantidad} @ {detalle.PrecioUnitario:C2}");
            }

            MessageBox.Show(sb.ToString(), "Detalles del Encargue",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Designer variables
        private DataGridView dgvEncargues;
    }
}