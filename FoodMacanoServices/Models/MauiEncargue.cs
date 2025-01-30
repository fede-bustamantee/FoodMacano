namespace FoodMacanoServices.Models
{
    public class MauiEncargue
    {
        public int Id { get; set; }
        public DateTime FechaEncargue { get; set; }
        public string Estado { get; set; } = "Pendiente"; // Estado por defecto
        public decimal Total { get; set; }
        public string UserId { get; set; } = string.Empty;

        public List<MauiEncargueDetalle> Detalles { get; set; } = new List<MauiEncargueDetalle>();
    }
}