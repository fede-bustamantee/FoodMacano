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
            
        }
    }
}