using FoodMacanoDesktop.Views.Configuracion.Datos;
using FoodMacanoDesktop.Views.Menu;
using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Services.Common;

namespace FoodMacanoDesktop.Views.DatosDelNegocio
{
    public partial class DatosView : Form
    {
        GenericService<Negocio> negocioService = new GenericService<Negocio>();
        BindingSource listaDatos = new BindingSource();
        public DatosView()
        {
            InitializeComponent(); 
            dataGridDatos.DataSource = listaDatos;  // Asocia el BindingSource al DataGrid.
            CargarDatosGrilla();
        }

        // Método asincrónico que carga los datos de negocio en el DataGrid.
        private async void CargarDatosGrilla()
        {
            // Obtiene todos los datos de negocio de manera asincrónica.
            var datos = await negocioService.GetAllAsync();
            listaDatos.DataSource = datos;  // Asocia los datos obtenidos al BindingSource.
            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            if (dataGridDatos.Columns.Count == 0) return;  // Evita errores si no hay columnas.

            if (dataGridDatos.Columns.Contains("Id"))
                dataGridDatos.Columns["Id"].Visible = false;
            if (dataGridDatos.Columns.Contains("RedesSocialId"))
                dataGridDatos.Columns["RedesSocialId"].Visible = false;
            if (dataGridDatos.Columns.Contains("RedesSocial"))
                dataGridDatos.Columns["RedesSocial"].Visible = false;
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtiene el negocio seleccionado en la grilla.
            var negocio = (Negocio)listaDatos.Current;
            // Muestra un cuadro de diálogo de confirmación.
            var respuesta = MessageBox.Show(
                $"¿Está seguro que quiere eliminar el negocio {negocio.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Si el usuario confirma, elimina el negocio de manera asincrónica y recarga la grilla.
            if (respuesta == DialogResult.Yes)
            {
                await negocioService.DeleteAsync(negocio.Id);
                CargarDatosGrilla();  // Recarga los datos de la grilla después de eliminar el negocio.
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Obtiene el negocio seleccionado en la grilla.
            var negocio = (Negocio)listaDatos.Current;
            // Crea una instancia del formulario para agregar o editar datos.
            AgregarEditarDatosView agregarEditarDatosView = new AgregarEditarDatosView(negocio);

            // Busca si el formulario principal (MenuPrincipalView) está abierto.
            MenuPrincipalView? menuPrincipal = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();

            // Si el formulario principal está abierto, lo utiliza para abrir el formulario hijo.
            if (menuPrincipal != null)
            {
                menuPrincipal.AbrirFormulariosHijos(agregarEditarDatosView);
                // Recarga los datos en la grilla cuando el formulario hijo se cierra.
                agregarEditarDatosView.FormClosed += (s, args) => CargarDatosGrilla();
            }
            else
            {
                // Si el formulario principal no está abierto, muestra el formulario de manera modal.
                agregarEditarDatosView.ShowDialog();
                CargarDatosGrilla();  // Recarga los datos de la grilla después de cerrar el formulario.
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario para agregar nuevos datos.
            AgregarEditarDatosView agregarEditarDatosView = new AgregarEditarDatosView();

            // Busca si el formulario principal (MenuPrincipalView) está abierto.
            MenuPrincipalView? menuPrincipal = Application.OpenForms.OfType<MenuPrincipalView>().FirstOrDefault();

            // Si el formulario principal está abierto, lo utiliza para abrir el formulario hijo.
            if (menuPrincipal != null)
            {
                menuPrincipal.AbrirFormulariosHijos(agregarEditarDatosView);
                // Recarga los datos en la grilla cuando el formulario hijo se cierra.
                agregarEditarDatosView.FormClosed += (s, args) => CargarDatosGrilla();
            }
            else
            {
                // Si el formulario principal no está abierto, muestra el formulario de manera modal.
                agregarEditarDatosView.ShowDialog();
                CargarDatosGrilla();  // Recarga los datos de la grilla después de cerrar el formulario.
            }
        }
    }
}
