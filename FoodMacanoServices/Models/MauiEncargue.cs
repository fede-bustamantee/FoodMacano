using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoServices.Models
{
    public class MauiEncargue
    {
        public int Id { get; set; }
        public DateTime FechaEncargue { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public string UserId { get; set; }  // Relacionado con FirebaseSignInResponse.LocalId
    }

}
