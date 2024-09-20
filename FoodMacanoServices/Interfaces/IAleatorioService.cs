namespace FoodMacanoServices.Interfaces
{
    public interface IAleatorioService<T> where T : class
    {
        Task<List<T>?> GetAleatoriosAsync();
    }
}
