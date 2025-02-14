using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Encargues.Movil
{
    public partial class EditarMovilView : Form
    {
        private readonly DesktopMovilService _encarguesService;
        private readonly MauiEncargue _encargue;
        private BindingSource _detallesBindingSource;

        public EditarMovilView(MauiEncargue encargue)
        {
            InitializeComponent();
            _encarguesService = new DesktopMovilService();
            _encargue = encargue;
            _detallesBindingSource = new BindingSource();

            ConfigurarFormulario();
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            // Configurar los controles para editar el encargue
            txtCliente.Text = _encargue.UserDisplayName;
            txtDireccion.Text = _encargue.Direccion;
            dtpFecha.Value = _encargue.FechaEncargue;
            txtTotal.Text = _encargue.Total.ToString("C2");

            // Configurar el DataGridView para los detalles
            dataGridViewDetalles.AutoGenerateColumns = false;
            dataGridViewDetalles.DataSource = _detallesBindingSource;
        }

        private void CargarDatos()
        {
            _detallesBindingSource.DataSource = _encargue.Detalles;
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                _encargue.UserDisplayName = txtCliente.Text;
                _encargue.Direccion = txtDireccion.Text;
                _encargue.FechaEncargue = dtpFecha.Value;

                await _encarguesService.UpdateEncargueAsync(_encargue);
                MessageBox.Show("Encargue actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el encargue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
