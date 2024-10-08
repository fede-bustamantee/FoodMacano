using FoodMacanoDesktop.Views.Configuracion;
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

namespace FoodMacanoDesktop.Views.Productos
{
    public partial class ProductosView : Form
    {
        GenericService<Categoria> categoriaService = new GenericService<Categoria>();

        ProductoService productoService = new ProductoService();

        BindingSource listaProductos = new BindingSource();
        BindingSource listaCategorias = new BindingSource();
        public ProductosView()
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
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var producto = (Producto)listaProductos.Current;
            var respuesta = MessageBox.Show($"¿Está seguro que quiere eliminar el producto {producto.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                await productoService.DeleteAsync(producto.Id);
                CargarDatosGrilla();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var categoria = (Categoria)listaCategorias.Current;
            AgregarEditarProductoView agregarEditarProductoView = new AgregarEditarProductoView(categoria);
            agregarEditarProductoView.ShowDialog();
            CargarDatosGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var producto = (Producto)listaProductos.Current;
            AgregarEditarProductoView agregarEditarProductoView = new AgregarEditarProductoView(producto);
            agregarEditarProductoView.ShowDialog();
            CargarDatosGrilla();
        }
    }
}
