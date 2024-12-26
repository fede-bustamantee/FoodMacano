using FoodMacanoServices.Models;
using FoodMacanoServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodMacanoServices.Services
{
    public class EncarguesService
    {
        private readonly IGenericService<Encargue> _encargueService;

        public EncarguesService(IGenericService<Encargue> encargueService)
        {
            _encargueService = encargueService;
        }

        public async Task<List<Encargue>> GetEncarguesAsync(string userId)
        {
            // Intenta convertir el userId a un número entero
            if (int.TryParse(userId, out int parsedUserId))
            {
                // Utiliza UsuarioId en lugar de ClienteId
                return await _encargueService.GetAllAsync(e => e.UsuarioId == parsedUserId) ?? new List<Encargue>();
            }
            return new List<Encargue>();
        }

        public async Task AddEncargueAsync(Encargue nuevoEncargue)
        {
            await _encargueService.AddAsync(nuevoEncargue);
        }

        public async Task DeleteEncargueAsync(int id)
        {
            await _encargueService.DeleteAsync(id);
        }

        public async Task UpdateEncargueAsync(Encargue encargue)
        {
            await _encargueService.UpdateAsync(encargue);
        }

        public async Task<Encargue> GetEncargueByIdAsync(int id)
        {
            return await _encargueService.GetByIdAsync(id);
        }
        // Opcional: Si no se usa, podrías eliminar este método
        public async Task<List<Encargue>> GetEncarguesAsync()
        {
            return await _encargueService.GetAllAsync() ?? new List<Encargue>();
        }
    }
}
