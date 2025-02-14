
using FoodMacanoDesktop.Views.Encargues.Movil;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System;
using System.Collections.Generic;
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
            dataGridViewEncargues.AutoGenerateColumns = false;
            dataGridViewEncargues.DataSource = bindingSource;

            // Agregar columnas
            dataGridViewEncargues.Columns.Clear();
            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id" });
            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "UserDisplayName" });
            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Dirección", DataPropertyName = "Direccion" });
            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "FechaEncargue" });
            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total", DataPropertyName = "Total", DefaultCellStyle = { Format = "C2" } });

            // Expandir detalles con doble clic
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

        private void DataGridViewEncargues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var encargueSeleccionado = bindingSource.Current as MauiEncargue;
            if (encargueSeleccionado == null) return;

            MostrarDetalles(encargueSeleccionado);
        }

        private void MostrarDetalles(MauiEncargue encargue)
        {
            // Asignar los detalles del encargue al DataGridViewDetalles
            dataGridViewDetalles.DataSource = null;
            dataGridViewDetalles.DataSource = encargue.Detalles;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var encargue = bindingSource.Current as MauiEncargue;
            if (encargue == null) return;

            var editarEncargueView = new EditarMovilView(encargue);
            editarEncargueView.ShowDialog();
            // Recargar datos después de editar
            LoadEncarguesAsync();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var encargue = bindingSource.Current as MauiEncargue;
            if (encargue == null) return;

            var respuesta = MessageBox.Show(
                $"¿Está seguro que desea eliminar el encargue de {encargue.UserDisplayName}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await _encarguesService.DeleteEncargueAsync(encargue.Id);
                    LoadEncarguesAsync();
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
