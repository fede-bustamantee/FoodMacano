using System.ComponentModel.DataAnnotations;

public class Encargue
{
    [Required(ErrorMessage = "El ProductoId es requerido.")]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "El UsuarioId es requerido.")]
    public int UsuarioId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
    public int Cantidad { get; set; }

    public DateTime FechaEncargue { get; set; }
}
