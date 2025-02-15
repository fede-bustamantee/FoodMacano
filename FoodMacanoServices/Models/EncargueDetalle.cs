using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoServices.Models
{
    public class EncargueDetalle
    {
        public int Id { get; set; }
        public int EncargueId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public virtual Producto? Producto { get; set; }
        public virtual Encargue? Encargue { get; set; }
    }
}
