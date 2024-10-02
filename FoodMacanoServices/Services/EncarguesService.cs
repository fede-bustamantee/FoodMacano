using FoodMacanoServices.Models;
using FoodMacanoServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodMacanoServices.Services
{
    public class EncarguesService
    {
        private readonly IGenericService<Encargue> _encargueService;

        public EncarguesService()
        {
            _encargueService = new GenericService<Encargue>();
        }

        // Obtener todos los encargues
        public async Task<List<Encargue>> GetEncarguesAsync()
        {
            return await _encargueService.GetAllAsync() ?? new List<Encargue>();
        }

        // Agregar un nuevo encargue
        public async Task AddEncargueAsync(Encargue nuevoEncargue)
        {
            await _encargueService.AddAsync(nuevoEncargue);
        }

        // Eliminar un encargue por su Id
        public async Task DeleteEncargueAsync(int id)
        {
            await _encargueService.DeleteAsync(id);
        }

        // Actualizar un encargue existente
        public async Task UpdateEncargueAsync(Encargue encargue)
        {
            await _encargueService.UpdateAsync(encargue);
        }

        // Obtener un encargue por su Id
        public async Task<Encargue> GetEncargueByIdAsync(int id)
        {
            return await _encargueService.GetByIdAsync(id);
        }
    }
}
