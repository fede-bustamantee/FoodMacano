using FoodMacanoServices.Models;
using FoodMacanoServices.Services;

namespace FoodMacanoDesktop.Views.Configuracion
{
    public partial class AgregarEditarProductoView : Form
    {
        ProductoService productoService = new ProductoService();
        Producto producto;

        //agregar
        public AgregarEditarProductoView(Categoria categoria)
        {
            InitializeComponent();
            producto = new Producto();
            producto.CategoriaId = categoria.Id;
            producto.DescripcionProducto = new DescripcionProducto();  // Aseguramos la inicialización
            txtCategoria.Text = categoria.Nombre;
            CargarCategorias();

            cboCategorias.Visible = true;
            txtCategoria.Visible = false;
        }
        //editar
        public AgregarEditarProductoView(Producto producto)
        {
            InitializeComponent();

            this.producto = producto;
            txtCategoria.Text = producto?.Categoria?.Nombre;
            txtProducto.Text = producto?.Nombre;
            txtImagen.Text = producto?.ImagenUrl;
            txtPrecio.Text = producto?.Precio.ToString();
            txtCalidad.Text = producto?.Calidad;
            txtCalorias.Text = producto?.Calorias.ToString();
            txtDescripcionCorta.Text = producto?.DescripcionProducto?.DescripcionCorta;
            txtDescripcionLarga.Text = producto?.DescripcionProducto?.DescripcionLarga;

            cboCategorias.Visible = false;
            txtCategoria.Visible = true;
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

            if (producto.Id == 0) // Modo agregar
            {
                if (cboCategorias.SelectedItem != null)
                {
                    var categoriaSeleccionada = (Categoria)cboCategorias.SelectedItem;
                    producto.CategoriaId = categoriaSeleccionada.Id;
                }

                await productoService.AddAsync(producto);
            }
            else // Modo editar
            {
                // No cambiamos la categoría en edición, solo aseguramos que se mantenga
                if (producto.CategoriaId == 0) // En caso de que no tenga categoría asignada
                {
                    var categoriaService = new CategoriaService();
                    var categorias = await categoriaService.GetAllAsync();
                    var categoriaExistente = categorias.FirstOrDefault(c => c.Nombre == txtCategoria.Text);

                    if (categoriaExistente != null)
                    {
                        producto.CategoriaId = categoriaExistente.Id;
                    }
                }

                await productoService.UpdateAsync(producto);
            }

            this.Close();
        }


        private async void CargarCategorias()
        {
            var categoriaService = new CategoriaService();
            var categorias = await categoriaService.GetAllAsync();

            cboCategorias.DataSource = categorias;
            cboCategorias.DisplayMember = "Nombre"; // Lo que se mostrará en el ComboBox
            cboCategorias.ValueMember = "Id"; // Lo que se usará como valor seleccionado
            cboCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que haya una categoría seleccionada
            if (cboCategorias.SelectedItem != null)
            {
                // Obtener la categoría seleccionada
                var categoriaSeleccionada = (Categoria)cboCategorias.SelectedItem;

                // Actualizar el producto con la categoría seleccionada
                producto.CategoriaId = categoriaSeleccionada.Id;
                txtCategoria.Text = categoriaSeleccionada.Nombre; // Actualizar el TextBox con el nombre de la categoría
            }
        }
    }
}
