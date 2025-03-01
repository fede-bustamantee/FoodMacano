using FoodMacanoServices.Enums;
using FoodMacanoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoServices.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CrearUsuarioAsync(Usuario usuario);
        Task<Usuario> ObtenerUsuarioPorFirebaseIdAsync(string firebaseId);
        Task<Usuario> CrearUsuarioSiNoExisteAsync(string firebaseId, string email, string nombreUsuario, string password, TipoUsuarioEnum tipoUsuario); // Modificada
        Task<List<Usuario>> ObtenerTodosLosUsuariosAsync();
        Task ActualizarUsuarioAsync(Usuario usuario);
        Task EliminarUsuarioAsync(int id);
        Task<Usuario> ObtenerUsuarioPorEmailAsync(string email);
    }


}
