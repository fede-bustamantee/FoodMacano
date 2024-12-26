using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMacanoServices.Enums;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;

namespace FoodMacanoServices.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericService<Usuario> _usuarioService;
        private readonly FirebaseAuthService _authService;

        public UsuarioService(
            IGenericService<Usuario> usuarioService,
            FirebaseAuthService authService)
        {
            _usuarioService = usuarioService;
            _authService = authService;
        }

        // Implementar el método de la interfaz
        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            var usuarioExistente = await ObtenerUsuarioPorFirebaseIdAsync(usuario.FirebaseId);

            if (usuarioExistente != null)
            {
                return usuarioExistente; // El usuario ya existe
            }

            // Crear un nuevo usuario si no existe
            await _usuarioService.AddAsync(usuario);
            return usuario;
        }

        // Obtener el usuario basado en FirebaseId
        public async Task<Usuario> ObtenerUsuarioPorFirebaseIdAsync(string firebaseId)
        {
            var usuarios = await _usuarioService.GetAllAsync(u => u.FirebaseId == firebaseId);
            return usuarios.FirstOrDefault();
        }

        // Crear un nuevo usuario si no existe
        public async Task<Usuario> CrearUsuarioSiNoExisteAsync(string firebaseId, string email, string nombreUsuario, string password, TipoUsuarioEnum tipoUsuario)
        {
            var usuarioExistente = await ObtenerUsuarioPorFirebaseIdAsync(firebaseId);

            if (usuarioExistente != null)
            {
                return usuarioExistente; // El usuario ya existe, devolverlo
            }

            // Crear un nuevo usuario si no existe
            var nuevoUsuario = new Usuario
            {
                FirebaseId = firebaseId,
                Email = email,
                User = nombreUsuario,
                Password = password, // En producción, utiliza contraseñas encriptadas
                TipoUsuario = tipoUsuario
            };

            await _usuarioService.AddAsync(nuevoUsuario);
            return nuevoUsuario;
        }

        // Obtener todos los usuarios
        public async Task<List<Usuario>> ObtenerTodosLosUsuariosAsync()
        {
            return await _usuarioService.GetAllAsync();
        }

        // Actualizar un usuario existente
        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            await _usuarioService.UpdateAsync(usuario);
        }

        // Eliminar un usuario
        public async Task EliminarUsuarioAsync(int id)
        {
            await _usuarioService.DeleteAsync(id);
        }
    }
}
