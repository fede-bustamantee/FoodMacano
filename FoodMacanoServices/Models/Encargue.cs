using FoodMacanoServices.Models;
using System.ComponentModel.DataAnnotations;

public class Encargue
{
    public int Id { get; set; }

    [Required]
    public int ProductoId { get; set; }

    [Required]
    public int UsuarioId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }

    public DateTime FechaEncargue { get; set; }

    // Marcar las propiedades de navegación como opcionales
    public virtual Producto? Producto { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public int NumeroEncargue { get; set; } // Nuevo campo para el número de encargue
}