using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class MovilView : Form
    {
        private readonly EncarguesWindowsService _encarguesService;
        private BindingSource bindingSource;

        public MovilView()
        {
            InitializeComponent();
            _encarguesService = new EncarguesWindowsService();
            bindingSource = new BindingSource();
            ConfigureDataGridView();
            LoadEncarguesAsync();
        }

        private void ConfigureDataGridView()
        {
            // Ya no necesitamos agregar las columnas programáticamente, ya están configuradas en el Designer.
            dataGridViewEncargues.DataSource = bindingSource;
            dataGridViewEncargues.CellDoubleClick += DataGridViewEncargues_CellDoubleClick;
        }

        private async void LoadEncarguesAsync()
        {
            try
            {
                var encargues = await _encarguesService.GetAllEncarguesAsync();
                bindingSource.DataSource = encargues;
                labelTotal.Text = $"Total de encargues: {encargues.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los encargues: {ex.Message}", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var detailsForm = new EncargueDetailsForm(encargue);
            detailsForm.ShowDialog();
        }
    }
}
