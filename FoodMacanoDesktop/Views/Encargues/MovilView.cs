using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class MovilView : Form
    {
        private readonly DesktopMovilService _encarguesService;
        private BindingSource bindingSource;
        private List<MauiEncargue> _encargues;

        public MovilView()
        {
            InitializeComponent();
            _encarguesService = new DesktopMovilService();
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
                var encargue = (MauiEncargue)bindingSource[e.RowIndex];
                ShowEncargueDetails(encargue);
            }
        }

        private void ShowEncargueDetails(MauiEncargue encargue)
        {
            var detailsForm = new MovilDetalle(encargue);
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