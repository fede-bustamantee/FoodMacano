namespace FoodMacanoServices.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        public Task<List<T>?> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task<T?> AddAsync(T? entity);
        public Task UpdateAsync(T? entity);
        public Task DeleteAsync(int id);

        Task<List<T>> GetAllAsync(Func<T, bool> predicate);
        public Task<List<T>?> GetRandomAsync(int count);
    }
}
