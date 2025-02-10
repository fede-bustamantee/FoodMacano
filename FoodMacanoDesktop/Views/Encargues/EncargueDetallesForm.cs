using System;
using System.Windows.Forms;
using FoodMacanoServices.Services;
using FoodMacanoServices.Models;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class EncargueDetallesForm : Form
    {
        private readonly MauiEncargueService _encargueService;
        private readonly int _encargueId;

        public EncargueDetallesForm(int encargueId, MauiEncargueService encargueService)
        {
            InitializeComponent();
            _encargueId = encargueId;
            _encargueService = encargueService;
            LoadEncargueDetails();
        }

        private async void LoadEncargueDetails()
        {
            try
            {
                var encargue = await _encargueService.GetEncargueByIdAsync(_encargueId);

                // Configurar labels con información general
                lblEncargueId.Text = $"Encargue ID: {encargue.Id}";
                lblFecha.Text = $"Fecha: {encargue.FechaEncargue}";
                lblEstado.Text = $"Estado: {encargue.Estado}";
                lblTotal.Text = $"Total: {encargue.Total:C2}";

                // Configurar DataGridView con detalles
                dataGridViewDetalles.AutoGenerateColumns = false;
                dataGridViewDetalles.DataSource = encargue.Detalles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}