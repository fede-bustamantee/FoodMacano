using FoodMacanoDesktop.Views.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Menu
{
    public partial class MenuPrincipalView : Form
    {
        bool logueado = false;
        public MenuPrincipalView()
        {
            InitializeComponent();
            SubMenu();
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
            SubmenuClientes.Visible = false;//establece que la propiedad bool en false
            SubmenuProductos.Visible = false;
            SubmenuEmpleados.Visible = false;
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
            if (SubmenuClientes.Visible == true) SubmenuClientes.Visible = false;
            if (SubmenuProductos.Visible == true) SubmenuProductos.Visible = false;
            if (SubmenuEmpleados.Visible == true) SubmenuEmpleados.Visible = false;
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

        //botones que abren los submenus y formularios hijos
        private void btnClientes_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuClientes);
        }

        private void btnTodosLosClientes_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new ClientesViewFrom());
            OcultarSubmenu();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuProductos);
        }

        private void btnListaProductos_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
            //AbrirFormulariosHijos(new ProductosViewFrom());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuEmpleados);
        }

        private void btnRegistroEmpleados_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
            //AbrirFormulariosHijos(new EmpleadosViewFrom());
        }
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuConfiguracion);
        }

        private void btnConfigClientes_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new FrmConfigClientes(this));
            OcultarSubmenu();
        }

        private void btnConfigProductos_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new FrmConfigProductos(this));
            OcultarSubmenu();
        }

        private void btnConfigEmpleados_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new FrmConfigEmpleados(this));
            OcultarSubmenu();
        }

        private void btnConfigAbastecedor_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new FrmConfigAbastecedores(this));
            OcultarSubmenu();
        }

        private void btnConfigSector_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new FrmConfigSectores(this));
            OcultarSubmenu();
        }

        private void btnConfigLocalidad_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new FrmConfigLocalidades(this));
            OcultarSubmenu();
        }

        private void btnConfigProvincia_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new FrmConfigProvincias(this));
            OcultarSubmenu();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuInfo);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new FrmInformaciones());
            MostrarSubmenu(SubmenuInfo);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuSalir);
        }

        private void btnSalirDelSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
            OcultarSubmenu();
        }
        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuLocalidades);
        }

        private void btnArchivoLocalidades_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new LocalidadesViewFrom());
            OcultarSubmenu();
        }

        private void btnReabastecimiento_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(SubmenuReabastecimiento);
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            //AbrirFormulariosHijos(new AbastecedoresViewFrom());
            OcultarSubmenu();
        }
    }
}
