using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System.Text.Json;

namespace FoodMacanoDesktop.Views.Encargues.Web
{
    public partial class EditarWebView : Form
    {
        private readonly DesktopWebService _webService;
        private readonly Encargue _encargue;
        private readonly ProductoService _productoService;

        public EditarWebView(Encargue encargue)
        {
            InitializeComponent();
            _webService = new DesktopWebService();
            _productoService = new ProductoService();
            _encargue = encargue;
            ConfigureForm();
            CargarDatosEncargue();
            CargarProductos();
        }

        private void ConfigureForm()
        {
            this.Text = "Editar Encargue";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Configurar layout
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                ColumnCount = 2,
                RowCount = 6
            };

            // Crear controles
            lblNumeroEncargue = new Label { Text = "Número:" };
            txtNumeroEncargue = new TextBox { Enabled = false };

            lblFechaEncargue = new Label { Text = "Fecha:" };
            dtpFechaEncargue = new DateTimePicker();

            lblCantidad = new Label { Text = "Cantidad:" };
            numCantidad = new NumericUpDown
            {
                Minimum = 1,
                Maximum = 100,
                Value = 1
            };

            lblProducto = new Label { Text = "Producto:" };
            cboProductos = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 200
            };

            btnGuardar = new Button
            {
                Text = "Guardar",
                DialogResult = DialogResult.OK
            };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel
            };

            // Agregar controles al layout
            tableLayoutPanel.Controls.Add(lblNumeroEncargue, 0, 0);
            tableLayoutPanel.Controls.Add(txtNumeroEncargue, 1, 0);
            tableLayoutPanel.Controls.Add(lblFechaEncargue, 0, 1);
            tableLayoutPanel.Controls.Add(dtpFechaEncargue, 1, 1);
            tableLayoutPanel.Controls.Add(lblCantidad, 0, 2);
            tableLayoutPanel.Controls.Add(numCantidad, 1, 2);
            tableLayoutPanel.Controls.Add(lblProducto, 0, 3);
            tableLayoutPanel.Controls.Add(cboProductos, 1, 3);

            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 40,
                Padding = new Padding(0, 5, 0, 0)
            };


            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(buttonPanel);
        }

        private async void CargarProductos()
        {
            try
            {
                var productos = await _productoService.GetAllAsync();
                cboProductos.DataSource = productos;
                cboProductos.DisplayMember = "Nombre";
                cboProductos.ValueMember = "Id";

                if (_encargue.ProductoId > 0)
                {
                    cboProductos.SelectedValue = _encargue.ProductoId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEncargue()
        {
            txtNumeroEncargue.Text = _encargue.NumeroEncargue.ToString();
            dtpFechaEncargue.Value = _encargue.FechaEncargue;
            numCantidad.Value = _encargue.Cantidad;
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            _encargue.FechaEncargue = dtpFechaEncargue.Value;
            _encargue.Cantidad = (int)numCantidad.Value;
            _encargue.ProductoId = (int)cboProductos.SelectedValue;

            await _webService.UpdateEncargueAsync(_encargue);
            DialogResult = DialogResult.OK;
            Close();     
        }
    }
}