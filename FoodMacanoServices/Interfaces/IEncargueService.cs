using FoodMacanoServices.Models;

namespace FoodMacanoServices.Interfaces
{
    public interface IEncargueService : IGenericService<Encargue>
    {
        Task<List<Encargue>> GetEncarguesAsync(string firebaseUserId);
        Task AddEncargueAsync(Encargue encargue);
        Task<Encargue> GetEncargueByIdAsync(int id);
        Task UpdateEncargueAsync(Encargue encargue);
        Task DeleteEncargueAsync(int id);
        Task<int> GetNextEncargueNumberAsync();
    }
}