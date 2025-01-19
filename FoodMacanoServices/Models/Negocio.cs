namespace FoodMacanoServices.Models
{
    public class Negocio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Horario { get; set; } = string.Empty;
        public string MapaIframe { get; set; } = string.Empty;
        public int RedesSocialId { get; set; }
        public RedesSocial? RedesSocial { get; set; }
    }
}