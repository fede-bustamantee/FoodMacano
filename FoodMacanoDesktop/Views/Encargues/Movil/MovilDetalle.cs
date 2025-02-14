using FoodMacanoServices.Models;
using System;
using System.Windows.Forms;

namespace FoodMacanoDesktop.Views.Encargues
{
    public partial class MovilDetalle : Form
    {
        private readonly MauiEncargue _encargue;

        public MovilDetalle(MauiEncargue encargue)
        {
            InitializeComponent();
            _encargue = encargue;
            LoadData();
        }

        private void LoadData()
        {
            labelId.Text = $"Encargue #{_encargue.Id}";

            dataGridViewDetalles.DataSource = _encargue.Detalles;
        }
    }
}
