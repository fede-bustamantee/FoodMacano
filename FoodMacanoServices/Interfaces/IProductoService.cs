using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models.Common;

namespace FoodMacanoServices.Interfaces
{
    public interface IProductoService : IGenericService<Producto>
    {
        public Task<List<Producto>?> GetByCategoriaAsync(int? id);
    }
}
