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
            _usuarioService = usuarioService;
        }

        // Método para obtener el UsuarioId basado en el FirebaseId
        public async Task<int> GetUsuarioIdFromFirebaseId(string firebaseId)
        {
            var usuarios = await _usuarioService.GetAllAsync(u => u.FirebaseId == firebaseId);
            var usuario = usuarios.FirstOrDefault();

            if (usuario == null)
            {
                throw new InvalidOperationException($"Usuario no encontrado para el FirebaseId: {firebaseId}");
            }

            return usuario.Id;
        }
    }
}
