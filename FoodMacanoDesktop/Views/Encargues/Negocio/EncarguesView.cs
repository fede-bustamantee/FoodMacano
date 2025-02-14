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

        public EncarguesView()
        {
            InitializeComponent();

            // Configurar BindingSource
            dgvEncargues.DataSource = listaEncargues;

            // Eventos
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;

            // Cargar encargues iniciales
            LoadEncarguesPorFecha(dtpFecha.Value);
        }

        private async void LoadEncarguesPorFecha(DateTime fecha)
        {
            try
            {
                var encargues = await _encargueService.GetEncarguesAsync();
                var encarguesFiltrados = encargues
                    .Where(e => e.FechaEncargue.Date == fecha.Date)
                    .ToList();

                listaEncargues.DataSource = encarguesFiltrados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar encargues: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            LoadEncarguesPorFecha(dtpFecha.Value);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
