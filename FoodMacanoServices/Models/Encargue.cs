using FoodMacanoServices.Models;
using System.ComponentModel.DataAnnotations;

public class Encargue
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaEncargue { get; set; }
    public int NumeroEncargue { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public virtual ICollection<EncargueDetalle> EncargueDetalles { get; set; } = new List<EncargueDetalle>();
}