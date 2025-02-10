using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoServices.Models
{
    public class DesktopEncargue
    {
        public int Id { get; set; }
        public string NumeroMesa { get; set; }
        public List<DesktopDetalleEncargue> Detalles { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaEncargue { get; set; }
    }
}
