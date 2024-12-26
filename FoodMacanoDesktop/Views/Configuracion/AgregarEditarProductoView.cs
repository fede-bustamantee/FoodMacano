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
            producto.DescripcionProducto = new DescripcionProducto();  // Aseguramos la inicialización
            txtCategoria.Text = categoria.Nombre;
        }
        //editar
        public AgregarEditarProductoView(Producto producto)
        {
            InitializeComponent();

            this.producto = producto;

            // Verificamos si el producto tiene una categoría asociada
            txtCategoria.Text = producto?.Categoria?.Nombre;
            txtProducto.Text = producto?.Nombre;
            txtImagen.Text = producto?.ImagenUrl;
            txtPrecio.Text = producto?.Precio.ToString();
            txtCalidad.Text = producto?.Calidad;
            txtCalorias.Text = producto?.Calorias.ToString();
            txtDescripcionCorta.Text = producto?.DescripcionProducto?.DescripcionCorta;
            txtDescripcionLarga.Text = producto?.DescripcionProducto?.DescripcionLarga;
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            producto.Nombre = txtProducto.Text;
            producto.ImagenUrl = txtImagen.Text;
            producto.Precio = Convert.ToInt32(txtPrecio.Text);
            producto.Calidad = txtCalidad.Text;
            producto.Calorias = Convert.ToInt32(txtCalorias.Text);
            producto.DescripcionProducto.DescripcionCorta = txtDescripcionCorta.Text;
            producto.DescripcionProducto.DescripcionLarga = txtDescripcionLarga.Text;

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
