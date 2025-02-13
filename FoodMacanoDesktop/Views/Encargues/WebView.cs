using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class WebView : Form
    {
        private readonly DesktopWebService _encarguesService;
        private BindingSource bindingSource;
        private List<Encargue> _encargues;

        public WebView()
        {
            InitializeComponent();
            _encarguesService = new DesktopWebService();
            bindingSource = new BindingSource();
            ConfigureDataGridView();
            LoadEncarguesAsync();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewEncargues.DataSource = bindingSource;
            dataGridViewEncargues.CellDoubleClick += DataGridViewEncargues_CellDoubleClick;
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
            var detailsForm = new WebDetalle(encargue);
            detailsForm.ShowDialog();
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
    }
}