using FoodMacanoServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class EncargueDetailsForm : Form
    {
        private readonly MauiEncargue _encargue;

        public EncargueDetailsForm(MauiEncargue encargue)
        {
            InitializeComponent();
            _encargue = encargue;
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            // Configurar el DataGridView para los detalles
            dataGridViewDetalles.AutoGenerateColumns = false;
            dataGridViewDetalles.Columns.AddRange(new DataGridViewColumn[]
            {
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Producto",
                Width = 200
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Width = 100
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioUnitario",
                HeaderText = "Precio Unit.",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            }
            });

            // Mostrar información del encargue
            labelId.Text = $"Encargue #{_encargue.Id}";
            labelFecha.Text = _encargue.FechaEncargue.ToString("dd/MM/yyyy HH:mm");
            labelUsuario.Text = _encargue.UserId;
            labelTotal.Text = _encargue.Total.ToString("C2");
            labelEstado.Text = _encargue.Estado;

            // Cargar detalles
            dataGridViewDetalles.DataSource = _encargue.Detalles;
        }
    }
}
