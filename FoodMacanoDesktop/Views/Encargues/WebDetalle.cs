using FoodMacanoServices.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class WebDetalle : Form
    {
        private readonly Encargue _encargue;
        private readonly DataTable _detallesTable;

        public WebDetalle(Encargue encargue)
        {
            InitializeComponent();
            _encargue = encargue;
            _detallesTable = CreateDetallesTable();
            ConfigureDataGridView();
            LoadEncargueDetails();
        }

        private DataTable CreateDetallesTable()
        {
            var table = new DataTable();
            table.Columns.Add("Concepto", typeof(string));
            table.Columns.Add("Valor", typeof(string));
            return table;
        }

        private void ConfigureDataGridView()
        {
            dgvDetalles.AutoGenerateColumns = true;
            dgvDetalles.DataSource = _detallesTable;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ajustar el estilo para mejor visualización
            dgvDetalles.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dgvDetalles.DefaultCellStyle.Padding = new Padding(3);
        }

        private void LoadEncargueDetails()
        {
            try
            {
                _detallesTable.Rows.Clear();

                // Información del Encargue
                _detallesTable.Rows.Add("=== DATOS DEL ENCARGUE ===", "");
                _detallesTable.Rows.Add("ID Encargue", _encargue.Id);
                _detallesTable.Rows.Add("Número de Encargue", _encargue.NumeroEncargue);
                _detallesTable.Rows.Add("Fecha y Hora", _encargue.FechaEncargue.ToString("dd/MM/yyyy HH:mm:ss"));
                _detallesTable.Rows.Add("Cantidad", _encargue.Cantidad);

                // Información del Producto
                if (_encargue.Producto != null)
                {
                    _detallesTable.Rows.Add("", "");
                    _detallesTable.Rows.Add("=== DATOS DEL PRODUCTO ===", "");
                    _detallesTable.Rows.Add("ID Producto", _encargue.Producto.Id);
                    _detallesTable.Rows.Add("Nombre Producto", _encargue.Producto.Nombre);
                    _detallesTable.Rows.Add("Precio Unitario", $"${_encargue.Producto.Precio:N2}");
                    _detallesTable.Rows.Add("Calidad", _encargue.Producto.Calidad);
                    _detallesTable.Rows.Add("Calorías", $"{_encargue.Producto.Calorias} cal");
                    _detallesTable.Rows.Add("Categoría ID", _encargue.Producto.CategoriaId);
                    _detallesTable.Rows.Add("Descripción ID", _encargue.Producto.DescripcionProductoId);
                }

                // Información del Usuario
                if (_encargue.Usuario != null)
                {
                    _detallesTable.Rows.Add("", "");
                    _detallesTable.Rows.Add("=== DATOS DEL USUARIO ===", "");
                    _detallesTable.Rows.Add("ID Usuario", _encargue.Usuario.Id);
                    _detallesTable.Rows.Add("Username", _encargue.Usuario.User);
                    _detallesTable.Rows.Add("Email", _encargue.Usuario.Email);
                    _detallesTable.Rows.Add("Tipo Usuario", _encargue.Usuario.TipoUsuario);
                    _detallesTable.Rows.Add("Firebase ID", _encargue.Usuario.FirebaseId);
                }

                // Total del Encargue
                _detallesTable.Rows.Add("", "");
                _detallesTable.Rows.Add("=== TOTAL ===", "");
                decimal total = (_encargue.Producto?.Precio ?? 0) * _encargue.Cantidad;
                _detallesTable.Rows.Add("Total del Encargue", $"${total:N2}");

                // Refrescar el DataGridView
                dgvDetalles.Refresh();

                // Ajustar el tamaño de las filas para mejor visualización
                dgvDetalles.AutoResizeRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los detalles del encargue: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Funcionalidad no implementada",
                              "Información",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el estado: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

    }
}