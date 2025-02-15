using FoodMacanoServices.Models;

namespace FoodMacanoServices.Interfaces
{
    public interface ICarritoService
    {
        Task<List<CarritoCompra>> GetCartItemsAsync();
        Task AddToCartAsync(Producto producto);
        Task RemoveFromCartAsync(int itemId);
        Task<int> GetCartItemCountAsync();
        Task CheckoutAsync();
    }
}