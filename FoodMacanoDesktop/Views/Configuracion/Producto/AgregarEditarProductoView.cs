using FoodMacanoServices.Models;
using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Services.Common;

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
            producto.DescripcionProducto = new DescripcionProducto();
            txtCategoria.Text = categoria.Nombre;
            CargarCategorias();  

            cboCategorias.Visible = true;  // Muestra el ComboBox de categorías.
            txtCategoria.Visible = false;  // Oculta el TextBox que muestra el nombre de la categoría.
        }

        // Constructor para editar un producto (modo de editar)
        public AgregarEditarProductoView(Producto producto)
        {
            InitializeComponent();

            this.producto = producto;  // Asigna el producto recibido a la variable de instancia.
            // Rellena los campos con los valores del producto existente.
            txtCategoria.Text = producto?.Categoria?.Nombre;
            txtProducto.Text = producto?.Nombre;
            txtImagen.Text = producto?.ImagenUrl;
            txtPrecio.Text = producto?.Precio.ToString();
            txtCalidad.Text = producto?.Calidad;
            txtCalorias.Text = producto?.Calorias.ToString();
            txtDescripcionCorta.Text = producto?.DescripcionProducto?.DescripcionCorta;
            txtDescripcionLarga.Text = producto?.DescripcionProducto?.DescripcionLarga;

            cboCategorias.Visible = false;  // Oculta el ComboBox de categorías.
            txtCategoria.Visible = true;  // Muestra el TextBox que muestra el nombre de la categoría.
        }

        // Método asincrónico para cargar las categorías en el ComboBox.
        private async void CargarCategorias()
        {
            var categoriaService = new CategoriaService();  // Crea una instancia del servicio para obtener las categorías.
            var categorias = await categoriaService.GetAllAsync();  // Obtiene todas las categorías de manera asincrónica.

            cboCategorias.DataSource = categorias;  // Asocia la lista de categorías al ComboBox.
            cboCategorias.DisplayMember = "Nombre";
            cboCategorias.ValueMember = "Id"; 
            cboCategorias.DropDownStyle = ComboBoxStyle.DropDownList;  // Configura el ComboBox para que se muestre como una lista desplegable.
        }

        // Evento que se dispara cuando el usuario selecciona una categoría en el ComboBox.
        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica que haya una categoría seleccionada.
            if (cboCategorias.SelectedItem != null)
            {
                // Obtiene la categoría seleccionada.
                var categoriaSeleccionada = (Categoria)cboCategorias.SelectedItem;

                // Actualiza el producto con la categoría seleccionada.
                producto.CategoriaId = categoriaSeleccionada.Id;
                txtCategoria.Text = categoriaSeleccionada.Nombre;  // Actualiza el TextBox con el nombre de la categoría seleccionada.
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Asigna los valores ingresados en los campos de texto al producto.
            producto.Nombre = txtProducto.Text;
            producto.ImagenUrl = txtImagen.Text;
            producto.Precio = Convert.ToInt32(txtPrecio.Text);
            producto.Calidad = txtCalidad.Text;
            producto.Calorias = Convert.ToInt32(txtCalorias.Text);
            producto.DescripcionProducto.DescripcionCorta = txtDescripcionCorta.Text;
            producto.DescripcionProducto.DescripcionLarga = txtDescripcionLarga.Text;

            // Verifica si el producto es nuevo (modo agregar).
            if (producto.Id == 0)
            {
                // Si el producto es nuevo, se verifica si se ha seleccionado una categoría.
                if (cboCategorias.SelectedItem != null)
                {
                    var categoriaSeleccionada = (Categoria)cboCategorias.SelectedItem;
                    producto.CategoriaId = categoriaSeleccionada.Id;  // Asocia el producto a la categoría seleccionada.
                }

                // Llama al servicio para agregar el producto de manera asincrónica.
                await productoService.AddAsync(producto);
            }
            else  // Modo editar
            {
                // En el caso de editar, se asegura que la categoría del producto no se modifique accidentalmente.
                if (producto.CategoriaId == 0)  // Si el producto no tiene categoría asignada.
                {
                    var categoriaService = new CategoriaService();  // Crea una instancia del servicio para obtener las categorías.
                    var categorias = await categoriaService.GetAllAsync();  // Obtiene todas las categorías de manera asincrónica.
                    var categoriaExistente = categorias.FirstOrDefault(c => c.Nombre == txtCategoria.Text);  // Busca la categoría por nombre.

                    // Si se encuentra una categoría con ese nombre, se asigna al producto.
                    if (categoriaExistente != null)
                    {
                        producto.CategoriaId = categoriaExistente.Id;
                    }
                }

                // Llama al servicio para actualizar el producto de manera asincrónica.
                await productoService.UpdateAsync(producto);
            }

            this.Close();  // Cierra el formulario después de guardar los cambios.
        }
    }
}