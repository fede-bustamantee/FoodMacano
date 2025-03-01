using FoodMacanoServices.Enums;
using FoodMacanoServices.Models;
using FoodMacanoServices.Models.FireAuth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodMacanoServices.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CrearUsuarioAsync(Usuario usuario);
        Task<Usuario> ObtenerUsuarioPorFirebaseIdAsync(string firebaseId);
        Task<Usuario> CrearUsuarioSiNoExisteAsync(string firebaseId, string email, string nombreUsuario, string password, TipoUsuarioEnum tipoUsuario);
        Task<List<Usuario>> ObtenerTodosLosUsuariosAsync();
        Task<List<UsuarioDTO>> ObtenerTodosLosUsuariosDTOAsync();
        Task ActualizarUsuarioAsync(Usuario usuario);
        Task EliminarUsuarioAsync(int id);
        Task<Usuario> ObtenerUsuarioPorEmailAsync(string email);
        Task<UsuarioDTO> ObtenerUsuarioDTOPorIdAsync(int id);
    }
}