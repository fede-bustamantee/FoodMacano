using FoodMacanoDesktop.Views.Menu;
using FoodMacanoServices.Models;
using Microsoft.Reporting.WinForms;

namespace FoodMacanoDesktop.ViewReports
{
    public partial class ProductosViewReports : Form
    {
        ReportViewer reporte;
        private List<Producto> _producto;
        public ProductosViewReports(MenuPrincipalView menuPrincipalView, List<Producto> producto)
        {
            InitializeComponent();
            _producto = producto;
            this.MdiParent = menuPrincipalView;
            this.WindowState = FormWindowState.Maximized;
            reporte = new ReportViewer();

            reporte.Dock = DockStyle.Fill;

            Controls.Add(reporte);
        }

        private async void ProductosViewReports_Load(object sender, EventArgs e)
        {
            reporte.LocalReport.ReportEmbeddedResource = "FoodMacanoDesktop.Reportes.ProductosReport.rdlc";

            // Extraigo los datos que necesito para el reporte de productos, incluyendo las relaciones
            var productosDetallados = _producto.Select(x => new
            {
                Nombre = x.Nombre,
                Precio = x.Precio,
                Calidad = x.Calidad,
                Calorias = x.Calorias,
                ImagenUrl = x.ImagenUrl,
                CategoriaNombre = x.Categoria?.Nombre ?? "Sin categoría",
                DescripcionCorta = x.DescripcionProducto?.DescripcionCorta ?? "Sin descripción",
                DescripcionLarga = x.DescripcionProducto?.DescripcionLarga ?? "Sin descripción detallada"
            })
            .OrderBy(x => x.CategoriaNombre)      // Ordena primero por categoría
            .ThenBy(x => x.Nombre)               // Luego por nombre del producto
            .ToList();

            reporte.LocalReport.DataSources.Add(new ReportDataSource("DSProductos", productosDetallados));
            reporte.SetDisplayMode(DisplayMode.Normal);
            reporte.RefreshReport();
        }
    }
}