using FoodMacanoDesktop.Views.Configuracion.Datos;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.DatosDelNegocio
{
    public partial class DatosView : Form
    {
        GenericService<Negocio> negocioService = new GenericService<Negocio>();
        BindingSource listaDatos = new BindingSource();

        public DatosView()
        {
            InitializeComponent();
            dataGridDatos.DataSource = listaDatos;
            CargarDatosGrilla();
        }

        private async void CargarDatosGrilla()
        {
            var datos = await negocioService.GetAllAsync();
            listaDatos.DataSource = datos;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var negocio = (Negocio)listaDatos.Current;
            AgregarEditarDatosView agregarEditarDatosView = new AgregarEditarDatosView(negocio);
            agregarEditarDatosView.ShowDialog();
            CargarDatosGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditarDatosView agregarEditarDatosView = new AgregarEditarDatosView();
            agregarEditarDatosView.ShowDialog();
            CargarDatosGrilla();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var negocio = (Negocio)listaDatos.Current;
            var respuesta = MessageBox.Show(
                $"¿Está seguro que quiere eliminar el negocio {negocio.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                await negocioService.DeleteAsync(negocio.Id);
                CargarDatosGrilla();
            }
        }
    }

}