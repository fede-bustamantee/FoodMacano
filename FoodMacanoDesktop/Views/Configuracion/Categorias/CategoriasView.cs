using FoodMacanoDesktop.Views.Menu;
using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Services.Common;

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
            OcultarColumnas();
        }
        private void OcultarColumnas()
        {
            if (dataGridCategorias.Columns.Count == 0) return; // Evita el error si no hay columnas

            if (dataGridCategorias.Columns.Contains("Id"))
                dataGridCategorias.Columns["Id"].Visible = false;
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
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditarCategoriaView agregarEditarCategoriaView = new AgregarEditarCategoriaView();

            // Buscar si el formulario principal está abierto
            MenuPrincipalView? menuPrincipal = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();

            if (menuPrincipal != null)
            {
                menuPrincipal.AbrirFormulariosHijos(agregarEditarCategoriaView);
                agregarEditarCategoriaView.FormClosed += (s, args) => CargarDatosGrilla(); // Recargar la grilla al cerrar
            }
            else
            {
                agregarEditarCategoriaView.ShowDialog();
                CargarDatosGrilla();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var categoria = (Categoria)listaCategorias.Current;
            AgregarEditarCategoriaView agregarEditarCategoriaView = new AgregarEditarCategoriaView(categoria);

            // Buscar si el formulario principal está abierto
            MenuPrincipalView? menuPrincipal = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();

            if (menuPrincipal != null)
            {
                menuPrincipal.AbrirFormulariosHijos(agregarEditarCategoriaView);
                agregarEditarCategoriaView.FormClosed += (s, args) => CargarDatosGrilla(); // Recargar la grilla al cerrar
            }
            else
            {
                agregarEditarCategoriaView.ShowDialog();
                CargarDatosGrilla();
            }
        }


    }
}
