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

namespace FoodMacanoDesktop.Views.Configuracion
{
    public partial class AgregarEditarProductoView : Form
    {
        ProductoService productoService = new ProductoService();
        Producto producto;
        public AgregarEditarProductoView(Categoria categoria)
        {
            InitializeComponent();
            producto = new Producto();
            producto.CategoriaId = categoria.Id;
            txtCategoria.Text = categoria.Nombre;
        }
        //editar
        public AgregarEditarProductoView(Producto producto)
        {
            InitializeComponent();

            this.producto = producto;

            // Si el producto tiene una categoría cargada, la mostramos
            if (producto?.Categoria != null)
            {
                txtCategoria.Text = producto.Categoria.Nombre;
            }
            else
            {
                txtCategoria.Text = "Sin categoría";  // Puedes manejar esto como prefieras
            }

            txtProducto.Text = producto?.Nombre;
            txtImagen.Text = producto?.ImagenUrl;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            producto.Nombre = txtProducto.Text;

            if (producto.Id == 0)
            {
                await productoService.AddAsync(producto);
            }
            else
            {
                await productoService.UpdateAsync(producto);
            }

            this.Close();
        }
    }
}
