using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.DatosDelNegocio
{
    public partial class DatosView : Form
    {
        private readonly GenericService<Negocio> negocioService = new GenericService<Negocio>();

        public DatosView()
        {
            InitializeComponent();
            CargarDatosNegocioAsync();
        }

        private async void CargarDatosNegocioAsync()
        {
            try
            {
                var negocios = await negocioService.GetAllAsync();
                var negocio = negocios.FirstOrDefault();

                if (negocio != null)
                {
                    // Mostrar datos básicos del negocio
                    lblNombre.Text = "Nombre: " + negocio.Nombre;
                    lblDireccion.Text = "Dirección: " + negocio.Direccion;
                    lblTelefono.Text = "Teléfono: " + negocio.Telefono;

                    // Mostrar horarios
                    listViewHorarios.Items.Clear();
                    foreach (var horario in negocio.Horarios)
                    {
                        var item = new ListViewItem(horario.Dia);
                        item.SubItems.Add(horario.HoraApertura);
                        item.SubItems.Add(horario.HoraCierre);
                        listViewHorarios.Items.Add(item);
                    }

                    // Mostrar redes sociales
                    lblInstagram.Text = "Instagram: " + negocio.RedesSocial?.Instagram;
                    lblFacebook.Text = "Facebook: " + negocio.RedesSocial?.Facebook;
                    lblWhatsapp.Text = "WhatsApp: " + negocio.RedesSocial?.Whatsapp;

                    // Si tienes un control para mostrar el mapa, descomenta y ajusta esta línea
                    // webBrowserMapa.DocumentText = negocio.MapaIframe;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos del negocio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}