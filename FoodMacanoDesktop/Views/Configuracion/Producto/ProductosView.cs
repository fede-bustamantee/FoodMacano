using FoodMacanoDesktop.Views.Configuracion;
using FoodMacanoDesktop.Views.Menu;
using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Services.Common;

namespace FoodMacanoDesktop.Views.Productos
{
    public partial class ProductosView : Form
    {
        GenericService<Categoria> categoriaService = new GenericService<Categoria>();
        ProductoService productoService = new ProductoService();

        // Fuentes de enlace de datos para los productos y categorías
        public BindingSource listaProductos = new BindingSource();
        public BindingSource listaCategorias = new BindingSource();
        public ProductosView()
        {
            InitializeComponent();
            dataGridProductos.DataSource = listaProductos;  // Enlaza el DataGrid con la lista de productos
            cboCategorias.DataSource = listaCategorias;  // Enlaza el ComboBox con la lista de categorías
            CargarCboCategorias();
            CargarDatosGrilla();
        }

        // Método asíncrono para cargar las categorías en el ComboBox
        private async void CargarCboCategorias()
        {
            listaCategorias.DataSource = await categoriaService.GetAllAsync();  // Obtiene todas las categorías
            cboCategorias.DisplayMember = "Nombre";  
            cboCategorias.ValueMember = "Id"; 
            CargarDatosGrilla();
        }
        private async void CargarDatosGrilla()
        {
            if (cboCategorias.SelectedValue != null && cboCategorias.SelectedValue is int idCategoria)
            {
                // Obtiene los productos de la categoría seleccionada
                var productos = await productoService.GetByCategoriaAsync(idCategoria);
                listaProductos.DataSource = productos;  // Enlaza los productos con el DataGrid
                OcultarColumnas();  // Oculta las columnas no necesarias en el DataGrid
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (listaCategorias.Current is not Categoria categoria) return;

            // Abre el formulario de agregar/editar producto para la categoría seleccionada
            AgregarEditarProductoView agregarEditarProductoView = new AgregarEditarProductoView(categoria);

            // Verifica si el formulario principal (MenuPrincipalView) está abierto
            MenuPrincipalView? menuPrincipal = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();

            if (menuPrincipal != null)
            {
                // Si está abierto, lo utiliza para agregar el formulario hijo
                menuPrincipal.AbrirFormulariosHijos(agregarEditarProductoView);
                agregarEditarProductoView.FormClosed += (s, args) => CargarDatosGrilla();  // Recarga los productos al cerrar el formulario
            }
            else
            {
                // Si no está abierto, muestra el formulario como un diálogo modal
                agregarEditarProductoView.ShowDialog();
                CargarDatosGrilla();  // Recarga los productos después de cerrar el formulario
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listaProductos.Current is not Producto producto) return;//asegurarse que es de tipo producto

            // Abre el formulario de agregar/editar producto para el producto seleccionado
            AgregarEditarProductoView agregarEditarProductoView = new AgregarEditarProductoView(producto);

            // Verifica si el formulario principal (MenuPrincipalView) está abierto
            MenuPrincipalView? menuPrincipal = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();

            if (menuPrincipal != null)
            {
                // Si está abierto, lo utiliza para agregar el formulario hijo
                menuPrincipal.AbrirFormulariosHijos(agregarEditarProductoView);
                agregarEditarProductoView.FormClosed += (s, args) => CargarDatosGrilla();  // Recarga los productos al cerrar el formulario
            }
            else
            {
                // Si no está abierto, muestra el formulario como un diálogo modal
                agregarEditarProductoView.ShowDialog();
                CargarDatosGrilla();  // Recarga los productos después de cerrar el formulario
            }
        }

        // Método asíncrono para eliminar un producto seleccionado
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var producto = (Producto)listaProductos.Current;
            var respuesta = MessageBox.Show($"¿Está seguro que quiere eliminar el producto {producto.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                // Llama al servicio para eliminar el producto y luego recarga los productos
                await productoService.DeleteAsync(producto.Id);
                CargarDatosGrilla();
            }
        }

        // Método que se ejecuta cuando se cambia la categoría seleccionada en el ComboBox
        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosGrilla();  // Recarga los productos de la categoría seleccionada
        }
        private void OcultarColumnas()
        {
            if (dataGridProductos.Columns.Count == 0) return; // Evita el error si no hay columnas

            if (dataGridProductos.Columns.Contains("Id"))
                dataGridProductos.Columns["Id"].Visible = false;
            if (dataGridProductos.Columns.Contains("Categoria"))
                dataGridProductos.Columns["Categoria"].Visible = false;
            if (dataGridProductos.Columns.Contains("CategoriaId"))
                dataGridProductos.Columns["CategoriaId"].Visible = false;
            if (dataGridProductos.Columns.Contains("DescripcionProductoId"))
                dataGridProductos.Columns["DescripcionProductoId"].Visible = false;
        }
    }
}
