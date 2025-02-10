using System;
using System.Windows.Forms;
using FoodMacanoServices.Services;
using FoodMacanoServices.Models;
using System.Collections.Generic;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class MovilView : Form
    {
        private readonly MauiEncargueService _encargueService;
        private readonly MauiFirebaseAuthService _authService;
        private List<MauiEncargue> encargues;

        public MovilView(MauiFirebaseAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            _encargueService = new MauiEncargueService(_authService);
            ConfigureDataGridView();
            LoadEncargues();
        }

        private void ConfigureDataGridView()
        {
            // Configurar el DataGridView
            dgvEncargues.AutoGenerateColumns = false;
            dgvEncargues.AllowUserToAddRows = false;
            dgvEncargues.AllowUserToDeleteRows = false;
            dgvEncargues.ReadOnly = true;
            dgvEncargues.MultiSelect = false;
            dgvEncargues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Agregar columnas
            dgvEncargues.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });

            dgvEncargues.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaEncargue",
                DataPropertyName = "FechaEncargue",
                HeaderText = "Fecha",
                Width = 150
            });

            dgvEncargues.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Width = 100
            });

            dgvEncargues.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                DataPropertyName = "Total",
                HeaderText = "Total",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvEncargues.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UserId",
                DataPropertyName = "UserId",
                HeaderText = "Usuario ID",
                Width = 200
            });
        }

        private async void LoadEncargues()
        {
            try
            {
                if (_authService.IsAdmin())
                {
                    encargues = await _encargueService.GetEncarguesParaAdminAsync();
                    dgvEncargues.DataSource = encargues;
                }
                else
                {
                    MessageBox.Show("No tienes permisos de administrador para ver todos los encargues.",
                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los encargues: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEncargues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var encargue = encargues[e.RowIndex];
                MostrarDetallesEncargue(encargue);
            }
        }

        private void MostrarDetallesEncargue(MauiEncargue encargue)
        {
            var detallesForm = new Form();
            detallesForm.Text = $"Detalles del Encargue #{encargue.Id}";
            detallesForm.Size = new Size(600, 400);
            detallesForm.StartPosition = FormStartPosition.CenterParent;

            var dgvDetalles = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            dgvDetalles.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "NombreProducto",
                    DataPropertyName = "NombreProducto",
                    HeaderText = "Producto",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Cantidad",
                    DataPropertyName = "Cantidad",
                    HeaderText = "Cantidad",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PrecioUnitario",
                    DataPropertyName = "PrecioUnitario",
                    HeaderText = "Precio Unitario",
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                }
            });

            dgvDetalles.DataSource = encargue.Detalles;
            detallesForm.Controls.Add(dgvDetalles);
            detallesForm.ShowDialog();
        }
    }
}