using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FoodMacanoServices.Services;
using FoodMacanoServices.Models;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class Movil : Form
    {
        private readonly MauiEncargueService _encargueService;
        private string _currentUserId;

        public Movil(MauiEncargueService encargueService, string userId)
        {
            InitializeComponent();
            _encargueService = encargueService;
            _currentUserId = userId;
            ConfigureDataGridView();
            LoadEncargues();
        }

        private void dataGridViewEncargues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedEncargueId = Convert.ToInt32(dataGridViewEncargues.Rows[e.RowIndex].Cells["Id"].Value);
                // Pass the service to the details form
                var detallesForm = new EncargueDetallesForm(selectedEncargueId, _encargueService);
                detallesForm.ShowDialog();
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridViewEncargues.AutoGenerateColumns = false;

            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });

            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaEncargue",
                HeaderText = "Fecha",
                Width = 150
            });

            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Width = 100
            });

            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total",
                Width = 100
            });

            dataGridViewEncargues.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrimerProducto",
                HeaderText = "Primer Producto",
                Width = 200
            });
        }

        private async void LoadEncargues()
        {
            try
            {
                var encargues = await _encargueService.GetEncarguesSummaryAsync(_currentUserId);

                var summaryList = encargues.Select(e => new
                {
                    Id = e.Id,
                    FechaEncargue = e.FechaEncargue,
                    Estado = e.Estado,
                    Total = e.Total,
                    PrimerProducto = e.Detalles.FirstOrDefault()?.NombreProducto ?? "Sin productos"
                }).ToList();

                dataGridViewEncargues.DataSource = summaryList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar encargues: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}