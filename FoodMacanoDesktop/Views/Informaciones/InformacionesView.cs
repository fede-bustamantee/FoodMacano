using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Informaciones
{
    public partial class InformacionesView : Form
    {
        public InformacionesView(string nombre, string imagenUrl, string descripcionLarga)
        {
            InitializeComponent();
            CargarInformacionProducto(nombre, imagenUrl, descripcionLarga);
        }

        private void CargarInformacionProducto(string nombre, string imagenUrl, string descripcionLarga)
        {
            lblNombre.Text = nombre;

            if (!string.IsNullOrEmpty(imagenUrl))
                picImagen.Load(imagenUrl);

            txtDescripcion.Text = descripcionLarga;
        }
    }

}
