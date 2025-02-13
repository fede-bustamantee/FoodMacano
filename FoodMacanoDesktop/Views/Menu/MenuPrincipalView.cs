using FoodMacanoDesktop.Views.Login;
using FoodMacanoDesktop.Views.Productos;
using FoodMacanoDesktop.Views.DatosDelNegocio;
using FoodMacanoDesktop.Views.Encargues;
using FoodMacanoDesktop.Views.Configuracion.Categorias;
using FoodMacanoDesktop.ViewReports;
using FoodMacanoServices.Services;

namespace FoodMacanoDesktop.Views.Menu
{
    public partial class MenuPrincipalView : Form
    {
        bool logueado = false;
        // Asegúrate de que este panel esté definido
        private Button botonActual;
        private ProductoService productoService;
        private NegocioService negocioService;


        public MenuPrincipalView()
        {
            InitializeComponent();
            SubMenu();
            productoService = new ProductoService();
            negocioService = new NegocioService();
            this.IsMdiContainer = true;
        }
        private void MenuPrincipalView_Activated(object sender, EventArgs e)
        {
            if (!logueado)
            {
                IniciarSesionView iniciarSesionView = new IniciarSesionView();
                iniciarSesionView.ShowDialog(); // Muestra el formulario de inicio de sesión
                if (!iniciarSesionView.loginSuccessfull)
                {
                    Application.Exit(); // Cierra la aplicación si no se inicia sesión
                }
                else
                {
                    logueado = true; // Marca al usuario como logueado
                }
            }
        }
        //Metodo sin retorno que oculta todos los submenus cuando se llama
        private void SubMenu()
        {
            SubmenuPedidos.Visible = false;//establece que la propiedad bool en false
            SubmenuEncargues.Visible = false;
            SubmenuDatos.Visible = false;
            SubmenuLocalidades.Visible = false;
            SubmenuConfiguracion.Visible = false;
            SubmenuInfo.Visible = false;
            SubmenuSalir.Visible = false;
            SubmenuReabastecimiento.Visible = false;
        }

        //Metodo de tipo vacio oculta cualquier submenú que esté visible. se va a utilizar en los botones
        private void OcultarSubmenu()
        {
            //Verifica si cada submenú está visible y lo oculta si es necesario.
            if (SubmenuPedidos.Visible == true) SubmenuPedidos.Visible = false;
            if (SubmenuEncargues.Visible == true) SubmenuEncargues.Visible = false;
            if (SubmenuDatos.Visible == true) SubmenuDatos.Visible = false;
            if (SubmenuLocalidades.Visible == true) SubmenuLocalidades.Visible = false;
            if (SubmenuConfiguracion.Visible == true) SubmenuConfiguracion.Visible = false;
            if (SubmenuInfo.Visible == true) SubmenuInfo.Visible = false;
            if (SubmenuSalir.Visible == true) SubmenuSalir.Visible = false;
            if (SubmenuReabastecimiento.Visible == true) SubmenuReabastecimiento.Visible = false;
        }

        //Metodo de tipo vacio para alternar visibilidad de los submenus
        private void MostrarSubmenu(Panel Submenu) // se pasa el parámetro de tipo Panel que representa el submenú
        {
            if (Submenu.Visible == false)//si esta oculto el submenu
            {
                OcultarSubmenu();// oculta todos los demás 
                Submenu.Visible = true;//muestra el especifico
            }
            else Submenu.Visible = false;//si es visible lo oculta
        }

        //metodo para abrir los formularios hijos en el panel contenedor
        private Form? FormularioActivo = null; //variable que almacena el formulario que se abre
        public void AbrirFormulariosHijos(Form formularioHijos)//parametro que representa el formulario hijo que se debe abrir
        {
            if (FormularioActivo != null) FormularioActivo.Close(); //si hay algun formulario activo se cierra

            //La variable FormularioActivo se actualiza para referenciar al nuevo formulario hijo que se está abriendo.
            FormularioActivo = formularioHijos; //se guarda el formulario que se abre en la variable

            //Indica que el formulario no es de nivel superior si no que se comporta como un control en el frm primcpal y no independientemenete
            formularioHijos.TopLevel = false;
            formularioHijos.FormBorderStyle = FormBorderStyle.None;//sacamos el borde haciendolo parecer parte del frm
            formularioHijos.Dock = DockStyle.Fill;//llenamos el panel contenedor
            PanelFormulario.Controls.Add(formularioHijos);//agregamos el panel a la lista de conrtoles de panel controlador
            PanelFormulario.Tag = formularioHijos; //asosciamos el formulario con el panel controlador
            formularioHijos.BringToFront();//ya que uso un logo traigo el formulario para enfrente
            formularioHijos.Show(); //mostramos el formulario hijo
        }
        private void ResaltarBoton(Button botonSeleccionado)
        {
            // Si ya hay un botón resaltado, restablece su color
            if (botonActual != null)
            {
                botonActual.BackColor = Color.Transparent; // O el color original que quieras
            }

            // Resaltar el nuevo botón
            botonSeleccionado.BackColor = Color.Gold; // Color para el botón seleccionado

            // Actualiza la referencia del botón actual
            botonActual = botonSeleccionado;
        }
        private void ResaltarEncabezadosAbiertos()
        {
            // Restablece el color de fondo de los botones
            btnPedidos.BackColor =
            btnEncargues.BackColor =
            btnNosotros.BackColor =
            btnConfiguracion.BackColor = Color.Empty;

            // Resalta el encabezado si los submenús son visibles
            if (SubmenuPedidos.Visible) btnPedidos.BackColor = Color.Pink;
            if (SubmenuEncargues.Visible) btnEncargues.BackColor = Color.Pink;
            if (SubmenuDatos.Visible) btnNosotros.BackColor = Color.Pink;
            if (SubmenuConfiguracion.Visible) btnConfiguracion.BackColor = Color.Pink;
        }

        //botones que abren los submenus y formularios hijos
        private void btnPedidos_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuPedidos);
            ResaltarEncabezadosAbiertos();
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            AbrirFormulariosHijos(new TodosLosProductos());
            ResaltarBoton(btnTodos);
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulariosHijos(new PorCategoriaView());
            ResaltarBoton(btnCategoria);
        }

        private void btnEncargues_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuEncargues);
            ResaltarEncabezadosAbiertos();
        }

        private void btnListaEncargues_Click(object sender, EventArgs e)
        {
            AbrirFormulariosHijos(new EncarguesView());
            ResaltarBoton(btnEncargusNegocio);
        }

        private void btnNosotros_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuDatos);
            ResaltarEncabezadosAbiertos();
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            AbrirFormulariosHijos(new DatosView());
            ResaltarBoton(btnDatos);
        }

        private void btnConfiguracion_Click_1(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuConfiguracion);
            ResaltarEncabezadosAbiertos();
        }

        private void btnConfigProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulariosHijos(new ProductosView());
            ResaltarBoton(btnConfigProductos);
        }

        private void btnEncargusMovil_Click(object sender, EventArgs e)
        {
            AbrirFormulariosHijos(new MovilView());
            ResaltarBoton(btnConfigProductos);
        }

        private void btnEncargusWeb_Click(object sender, EventArgs e)
        {
            AbrirFormulariosHijos(new WebView());
            ResaltarBoton(btnConfigProductos);
        }

        private void btnConfigEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulariosHijos(new CategoriasView());
            ResaltarBoton(btnConfigEmpleados);
        }

        private void btnConfigSector_Click(object sender, EventArgs e)
        {
            AbrirFormulariosHijos(new DatosView());
            ResaltarBoton(btnConfigSector);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuSalir);
            ResaltarEncabezadosAbiertos();
        }

        private void btnSalirDelSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
            ResaltarBoton(btnSalirDelSistema);
        }

        private async void btnArchivoLocalidades_Click(object sender, EventArgs e)
        {
            // Obtener la lista de productos directamente desde el servicio
            var productos = await productoService.GetAllAsync();
            ProductosViewReports reporteProductos = new ProductosViewReports(this, productos);
            AbrirFormulariosHijos(reporteProductos); // Muestra el formulario de reporte
            ResaltarBoton(btnArchivoLocalidades); // Resalta el botón si es necesario

        }

        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuLocalidades);
            ResaltarEncabezadosAbiertos();
        }

        private async void btnInforme_Click(object sender, EventArgs e)
        {
            // Obtener la lista de productos directamente desde el servicio
            var negocio = await negocioService.GetAllAsync();
            NegocioViewReports reporteNegocio = new NegocioViewReports(this, negocio);
            AbrirFormulariosHijos(reporteNegocio); // Muestra el formulario de reporte
            ResaltarBoton(btnInforme); // Resalta el botón si es necesario
        }

        private void btnReabastecimiento_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuReabastecimiento);
            ResaltarEncabezadosAbiertos();
        }
    }
}
