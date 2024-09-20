using FoodMacanoServices.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace FoodMacanoServices.Services
{
    public class CarritoComprasService
    {
        private readonly IGenericService<CarritoCompra> _carritoService;
        private readonly IGenericService<Encargue> _encargueService;

        public CarritoComprasService(
            IGenericService<CarritoCompra> carritoService,
            IGenericService<Encargue> encargueService,
            HttpClient httpClient,
            NavigationManager navigationManager)
        {
            _carritoService = carritoService;
            _encargueService = encargueService;
        }

        public async Task<List<CarritoCompra>> GetCartItemsAsync()
        {
            return await _carritoService.GetAllAsync() ?? new List<CarritoCompra>();
        }

        public async Task AddToCartAsync(Producto producto)
        {
            var cartItems = await GetCartItemsAsync();
            var existingItem = cartItems.FirstOrDefault(item => item.Nombre == producto.Nombre);
            if (existingItem != null)
            {
                existingItem.Cantidad++;
                await _carritoService.UpdateAsync(existingItem);
            }
            else
            {
                var newItem = new CarritoCompra
                {
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Cantidad = 1
                };
                await _carritoService.AddAsync(newItem);
            }
        }

        public async Task RemoveFromCartAsync(int itemId)
        {
            await _carritoService.DeleteAsync(itemId);
        }

        public async Task CheckoutAsync()
        {
            var cartItems = await GetCartItemsAsync();
            foreach (var item in cartItems)
            {
                var encargue = new Encargue
                {
                    ProductoId = item.Id,  // Asumiendo que el Id del CarritoCompra corresponde al ProductoId
                    NombreProducto = item.Nombre,
                    Precio = item.Precio,
                    Cantidad = item.Cantidad,
                };
                await _encargueService.AddAsync(encargue);
                await _carritoService.DeleteAsync(item.Id);
            }
        }
    }
}
