using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMacanoServices.Services
{
    public class UsuarioMappingService
    {
        private readonly IGenericService<Usuario> _usuarioService;

        public UsuarioMappingService(IGenericService<Usuario> usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        // Método para obtener el UsuarioId basado en el FirebaseId
        public async Task<int> GetUsuarioIdFromFirebaseId(string firebaseId)
        {
            if (string.IsNullOrEmpty(firebaseId))
            {
                throw new ArgumentException("El FirebaseId no puede ser nulo o vacío.", nameof(firebaseId));
            }

            var usuarios = await _usuarioService.GetAllAsync(u => u.FirebaseId == firebaseId);
            var usuario = usuarios.FirstOrDefault();

            if (usuario == null)
            {
                throw new InvalidOperationException($"Usuario no encontrado para el FirebaseId: {firebaseId}");
            }

            return usuario.Id;
        }

        // Método para obtener el objeto Usuario basado en el FirebaseId
        public async Task<Usuario?> GetUsuarioByFirebaseIdAsync(string firebaseId)
        {
            if (string.IsNullOrEmpty(firebaseId))
            {
                throw new ArgumentException("El FirebaseId no puede ser nulo o vacío.", nameof(firebaseId));
            }

            var usuarios = await _usuarioService.GetAllAsync(u => u.FirebaseId == firebaseId);
            return usuarios.FirstOrDefault();
        }
    }
}
