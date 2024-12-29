using FoodMacanoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoServices.Interfaces
{
    public interface ICarritoService : IGenericService<CarritoCompra>
    {
        Task<List<CarritoCompra>> GetCartItemsAsync();
        Task AddToCartAsync(Producto producto);
        Task UpdateCartItemAsync(CarritoCompra item);
        Task RemoveFromCartAsync(int itemId);
        Task<int> GetCartItemCountAsync();
        Task CheckoutAsync();
    }
}
