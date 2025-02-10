using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodMacanoServices.Services;
using FoodMacanoServices.Models;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class EncarguesView : Form
    {
        private ComboBox cboMesas;
        private DesktopEncargueService _encargueService;
        private List<DesktopEncargue> _allEncargues;

        public EncarguesView()
        {
            _encargueService = new DesktopEncargueService();
            InitializeComponent();

            // Wire up events
            cboMesas.SelectedIndexChanged += cboMesas_SelectedIndexChanged;

            // Load mesas when form opens
            LoadMesasAsync();
        }

        private async void LoadMesasAsync()
        {
            try
            {
                _allEncargues = await _encargueService.GetEncarguesAsync();

                var mesasList = _allEncargues
                    .Select(e => e.NumeroMesa)
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();

                cboMesas.Items.Clear();
                cboMesas.Items.AddRange(mesasList.ToArray());

                // Optional: Add a default "Seleccione Mesa" item
                cboMesas.Items.Insert(0, "Seleccione Mesa");
                cboMesas.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar mesas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMesas.SelectedIndex <= 0)
            {
                dgvEncargues.DataSource = null;
                return;
            }

            string selectedMesa = cboMesas.SelectedItem.ToString();
            ShowMesaDetails(selectedMesa);
        }

        private void ShowMesaDetails(string mesaNumero)
        {
            var mesaEncargues = _allEncargues
                .Where(e => e.NumeroMesa == mesaNumero)
                .ToList();

            dgvEncargues.DataSource = mesaEncargues;

            decimal total = mesaEncargues.Sum(e => e.Total);
        }
    }
}