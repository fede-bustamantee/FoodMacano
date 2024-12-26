namespace FoodMacanoServices.Models
{
    public class Negocio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public List<Horario> Horarios { get; set; } = new List<Horario>(); // Lista de Horarios
        public string MapaIframe { get; set; } = string.Empty;
        public int RedesSocialId { get; set; }
        public RedesSocial? RedesSocial { get; set; }
    }
}
