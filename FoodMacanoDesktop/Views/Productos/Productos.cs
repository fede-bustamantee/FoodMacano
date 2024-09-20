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
using System.Windows.Media.Media3D;

namespace FoodMacanoDesktop.Views.Productos
{
    public partial class Productos : Form
    {
        GenericService<Categoria> categoriaService = new GenericService<Categoria>();

        ProductoService productoService = new ProductoService();

        BindingSource listaProductos = new BindingSource();
        BindingSource listaCategorias = new BindingSource();
        public Productos()
        {
            InitializeComponent();
            dataGridProductos.DataSource = listaProductos;
            cboCategorias.DataSource = listaCategorias;
            CargarCboCategorias();
            CargarDatosGrilla();
        }
        private async void CargarCboCategorias()
        {
            listaCategorias.DataSource = await categoriaService.GetAllAsync();
            cboCategorias.DisplayMember = "Nombre";
            cboCategorias.ValueMember = "Id";
            CargarDatosGrilla();
        }

        private async void CargarDatosGrilla()
        {
            if (cboCategorias.SelectedValue != null && cboCategorias.SelectedValue is int idCategoria)
            {
                var productos = await productoService.GetByCategoriaAsync(idCategoria);
                listaProductos.DataSource = productos;
            }
        }

        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosGrilla();
        }
    }
}
