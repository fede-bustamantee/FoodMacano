using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using FoodMacanoDesktop.Views.Encargues.Negocio;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class EncarguesView : Form
    {
        private DesktopEncargueService _encargueService = new DesktopEncargueService();
        public BindingSource listaEncargues = new BindingSource();
        private List<DesktopEncargue> encarguesOriginales = new List<DesktopEncargue>();

        public EncarguesView()
        {
            InitializeComponent();

            // Configurar BindingSource
            dgvEncargues.DataSource = listaEncargues;

            // Eventos
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            cboMesas.SelectedIndexChanged += cboMesas_SelectedIndexChanged;

            // Cargar encargues iniciales
            LoadEncarguesPorFecha(dtpFecha.Value);
        }

        private async void LoadEncarguesPorFecha(DateTime fecha)
        {
            try
            {
                var encargues = await _encargueService.GetEncarguesAsync();
                encarguesOriginales = encargues.Where(e => e.FechaEncargue.Date == fecha.Date).ToList();
                listaEncargues.DataSource = new List<DesktopEncargue>(encarguesOriginales); // Clonamos para evitar modificar el original
                LoadMesasDisponibles(encarguesOriginales);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar encargues: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMesasDisponibles(List<DesktopEncargue> encarguesFiltrados)
        {
            cboMesas.SelectedIndexChanged -= cboMesas_SelectedIndexChanged; // Desvincular evento

            var mesas = encarguesFiltrados.Select(e => e.NumeroMesa).Distinct().ToList();
            mesas.Insert(0, "Todas");
            cboMesas.DataSource = mesas;

            cboMesas.SelectedIndexChanged += cboMesas_SelectedIndexChanged; // Volver a vincular evento
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            LoadEncarguesPorFecha(dtpFecha.Value);
        }

        private void cboMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarEncargues();
        }

        private void FiltrarEncargues()
        {
            var fechaSeleccionada = dtpFecha.Value.Date;
            var mesaSeleccionada = cboMesas.SelectedItem?.ToString();

            var encarguesFiltrados = encarguesOriginales.Where(e => e.FechaEncargue.Date == fechaSeleccionada).ToList();

            if (!string.IsNullOrEmpty(mesaSeleccionada) && mesaSeleccionada != "Todas")
            {
                encarguesFiltrados = encarguesFiltrados.Where(e => e.NumeroMesa == mesaSeleccionada).ToList();
            }

            listaEncargues.DataSource = encarguesFiltrados;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listaEncargues.Current is not DesktopEncargue encargue)
            {
                MessageBox.Show("Por favor seleccione un encargue para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Está seguro que quiere eliminar el encargue de {encargue.NombreProducto}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                await _encargueService.DeleteEncargueAsync(encargue.Id);
                LoadEncarguesPorFecha(dtpFecha.Value);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listaEncargues.Current is not DesktopEncargue encargue)
            {
                MessageBox.Show("Por favor seleccione un encargue para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AgregarEditarEncargueView agregarEditarEncargueView = new AgregarEditarEncargueView(encargue);
            agregarEditarEncargueView.ShowDialog();
            LoadEncarguesPorFecha(dtpFecha.Value);
        }
    }
}