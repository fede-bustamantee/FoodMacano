using FoodMacanoServices.Models;

namespace FoodMacanoServices.Interfaces
{
    public interface IMauiEncargueService : IGenericService<MauiEncargue>
    {
        Task<List<MauiEncargue>> GetEncarguesAsync(string firebaseUserId);
        Task AddEncargueAsync(MauiEncargue encargue);
        Task<MauiEncargue> GetEncargueByIdAsync(int id);
        Task UpdateEncargueAsync(MauiEncargue encargue);
        Task DeleteEncargueAsync(int id);
    }
}