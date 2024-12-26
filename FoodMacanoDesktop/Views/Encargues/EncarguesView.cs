using FoodMacanoServices.Models;
using FoodMacanoServices.Services;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class EncarguesView : Form
    {
        private List<Encargue> encargues = new List<Encargue>();
        private EncarguesService encarguesService;

        public EncarguesView()
        {
            InitializeComponent();
            InitializeServices();
            CargarEncargues();
        }

        private void InitializeServices()
        {
            encarguesService = new EncarguesService();
        }

        private async void CargarEncargues()
        {
            encargues = await encarguesService.GetEncarguesAsync();
            ActualizarListBoxEncargues();
        }

        private void ActualizarListBoxEncargues()
        {
            listBoxEncargues.Items.Clear(); // Limpia el ListBox

            if (encargues.Any())
            {
                // Añade todos los encargues al ListBox
                foreach (var encargue in encargues)
                {
                    listBoxEncargues.Items.Add($"{encargue.Cantidad}x {encargue.Producto.Nombre} - ${encargue.Producto.Precio * encargue.Cantidad}");
                }
            }
            else
            {
                // Si no hay encargues, limpiar los labels
                lblDatosEncargue.Text = "No hay encargues disponibles.";
                lblFecha.Text = string.Empty;
            }
        }

        // Evento para mostrar detalles del encargue seleccionado en el ListBox
        private void listBoxEncargues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEncargues.SelectedIndex >= 0)
            {
                var encargueSeleccionado = encargues[listBoxEncargues.SelectedIndex];
                MostrarEncargue(encargueSeleccionado);
            }
        }

        private void MostrarEncargue(Encargue encargue)
        {
            if (encargue != null)
            {
                // Actualiza los labels con los datos del encargue seleccionado
                lblDatosEncargue.Text = $"{encargue.Cantidad}x {encargue.Producto.Nombre} - ${encargue.Producto.Precio * encargue.Cantidad}";
                lblFecha.Text = encargue.FechaEncargue.ToString("dd/MM/yyyy HH:mm");

                // Limpia los eventos previos del botón para evitar múltiples asignaciones
                btnCancelar.Click -= btnCancelar_Click;

                // Asigna un nuevo evento al botón de cancelar
                btnCancelar.Click += btnCancelar_Click;
            }
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            if (listBoxEncargues.SelectedIndex >= 0 && listBoxEncargues.SelectedIndex < encargues.Count)
            {
                var encargue = encargues[listBoxEncargues.SelectedIndex];
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas cancelar este encargue?",
                                                    "Confirmar Cancelación",
                                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    await encarguesService.DeleteEncargueAsync(encargue.Id);
                    encargues.Remove(encargue);
                    MessageBox.Show("Encargue cancelado.");

                    // Actualiza la lista de encargues
                    ActualizarListBoxEncargues();
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un encargue válido para cancelar.");
            }
        }
    }
}

