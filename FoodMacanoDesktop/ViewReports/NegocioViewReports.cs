using FoodMacanoDesktop.Views.Menu;
using FoodMacanoServices.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodMacanoDesktop.ViewReports
{
    public partial class NegocioViewReports : Form
    {
        ReportViewer reporte;
        private List<Negocio> _negocio;
        public NegocioViewReports(MenuPrincipalView menuPrincipalView, List<Negocio> negocio)
        {
            InitializeComponent();
            _negocio = negocio;
            this.MdiParent = menuPrincipalView;
            this.WindowState = FormWindowState.Maximized;
            reporte = new ReportViewer();

            reporte.Dock = DockStyle.Fill;

            Controls.Add(reporte);
        }

        private void NegocioViewReports_Load(object sender, EventArgs e)
        {
            reporte.LocalReport.ReportEmbeddedResource = "FoodMacanoDesktop.Reportes.NegocioReport.rdlc";

            // Extraigo los datos que necesito para el reporte de productos, incluyendo las relaciones
            var negocioDetallados = _negocio.Select(x => new
            {
                Nombre = x.Nombre,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Horario = x.Horario,
                MapaIframe = x.MapaIframe,
                Instagram = x.RedesSocial?.Instagram ?? "No disponible",
                Facebook = x.RedesSocial?.Facebook ?? "No disponible",
                Whatsapp = x.RedesSocial?.Whatsapp ?? "No disponible"
            })
            .OrderBy(x => x.Nombre)
            .ToList();

            reporte.LocalReport.DataSources.Add(new ReportDataSource("DSNegocio", negocioDetallados));
            reporte.SetDisplayMode(DisplayMode.Normal);
            reporte.RefreshReport();
        }
    }
}
