using FoodMacanoServices.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoServices.Models.FireAuth
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string User { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public string Email { get; set; } = string.Empty;

        public TipoUsuarioEnum TipoUsuario { get; set; }

        [Required(ErrorMessage = "El FirebaseId es requerido")]
        public string FirebaseId { get; set; } = string.Empty;

        // Constructor para convertir desde Usuario
        public static UsuarioDTO FromUsuario(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                User = usuario.User,
                Email = usuario.Email,
                TipoUsuario = usuario.TipoUsuario,
                FirebaseId = usuario.FirebaseId
            };
        }
    }
}