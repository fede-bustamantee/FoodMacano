namespace FoodMacanoServices.Models
{
    public class MauiEncargue
    {
        public int Id { get; set; }
        public DateTime FechaEncargue { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public decimal Total { get; set; }
        public string UserId { get; set; } = string.Empty;

        // Configuración explícita de la relación
        public virtual ICollection<MauiEncargueDetalle> Detalles { get; set; } = new List<MauiEncargueDetalle>();
    }
}