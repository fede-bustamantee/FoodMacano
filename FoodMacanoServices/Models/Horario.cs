namespace FoodMacanoServices.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public string Dia { get; set; } = string.Empty;
        public string HoraApertura { get; set; } = string.Empty;
        public string HoraCierre { get; set; } = string.Empty;
    }
}
