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

namespace FoodMacanoDesktop.Views.Configuracion.Categorias
{
    public partial class CategoriasView : Form
    {
        CategoriaService categoriaService = new CategoriaService();
        BindingSource listaCategorias = new BindingSource();
        public CategoriasView()
        {
            InitializeComponent();

            dataGridCategorias.DataSource = listaCategorias;
            CargarDatosGrilla();
        }
        private async void CargarDatosGrilla()
        {
            var categorias = await categoriaService.GetAllAsync();
            listaCategorias.DataSource = categorias;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var categoria = (Categoria)listaCategorias.Current;
            AgregarEditarCategoriaView agregarEditarCategoriaView = new AgregarEditarCategoriaView(categoria);
            agregarEditarCategoriaView.ShowDialog();
            CargarDatosGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditarCategoriaView agregarEditarCategoriaView = new AgregarEditarCategoriaView();
            agregarEditarCategoriaView.ShowDialog();
            CargarDatosGrilla();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var categoria = (Categoria)listaCategorias.Current;
            var respuesta = MessageBox.Show(
                $"¿Está seguro que quiere eliminar la categoría {categoria.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                await categoriaService.DeleteAsync(categoria.Id);
                CargarDatosGrilla();
            }
        }
    }
}
