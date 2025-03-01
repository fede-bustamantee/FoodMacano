using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Services.Common;

namespace FoodMacanoDesktop.Views.Configuracion.Datos
{
    public partial class AgregarEditarDatosView : Form
    {
        GenericService<Negocio> negocioService = new GenericService<Negocio>();
        GenericService<RedesSocial> redesService = new GenericService<RedesSocial>();
        Negocio negocio;
        RedesSocial redesSocial;
        public AgregarEditarDatosView()
        {
            InitializeComponent();

            negocio = new Negocio();
            redesSocial = new RedesSocial();
        }

        public AgregarEditarDatosView(Negocio negocio)
        {
            InitializeComponent();
            this.negocio = negocio;
            this.redesSocial = negocio.RedesSocial ?? new RedesSocial();

            // Cargar datos del negocio
            txtNombre.Text = negocio.Nombre;
            txtDireccion.Text = negocio.Direccion;
            txtTelefono.Text = negocio.Telefono;
            txtHorario.Text = negocio.Horario;
            txtMapaIframe.Text = negocio.MapaIframe;

            // Cargar datos de redes sociales
            if (negocio.RedesSocial != null)
            {
                txtInstagram.Text = negocio.RedesSocial.Instagram;
                txtFacebook.Text = negocio.RedesSocial.Facebook;
                txtWhatsapp.Text = negocio.RedesSocial.Whatsapp;
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Deshabilitar el botón mientras se procesa
                btnGuardar.Enabled = false;

                // Actualizar datos de redes sociales
                redesSocial.Instagram = txtFacebook.Text;
                redesSocial.Facebook = txtFacebook.Text;
                redesSocial.Whatsapp = txtWhatsapp.Text;

                // Si es nuevo registro o actualización de redes sociales
                if (redesSocial.Id == 0)
                {
                    var nuevaRed = new RedesSocial
                    {
                        Instagram = redesSocial.Instagram,
                        Facebook = redesSocial.Facebook,
                        Whatsapp = redesSocial.Whatsapp
                    };

                    redesSocial = await redesService.AddAsync(nuevaRed);
                }
                else
                {
                    await redesService.UpdateAsync(redesSocial);
                }

                // Crear objeto limpio de negocio para enviar
                var negocioToSave = new Negocio
                {
                    Id = negocio.Id,
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Horario = txtHorario.Text,
                    MapaIframe = txtMapaIframe.Text,
                    RedesSocialId = redesSocial.Id
                };

                if (negocio.Id == 0) // Modo agregar
                {
                    await negocioService.AddAsync(negocioToSave);
                }
                else // Modo editar
                {
                    await negocioService.UpdateAsync(negocioToSave);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}