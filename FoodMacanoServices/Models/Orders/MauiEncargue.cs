namespace FoodMacanoServices.Models.Orders
{
    public class MauiEncargue
    {
        public int Id { get; set; }
        public DateTime FechaEncargue { get; set; }
        public decimal Total { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserDisplayName { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public virtual ICollection<MauiEncargueDetalle> Detalles { get; set; } = new List<MauiEncargueDetalle>();
    }
}