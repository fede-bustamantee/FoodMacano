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
            var existingItem = cartItems.FirstOrDefault(item => item.ProductoId == producto.Id);
            if (existingItem != null)
            {
                existingItem.Cantidad++;
                await _carritoService.UpdateAsync(existingItem);
            }
            else
            {
                var newItem = new CarritoCompra
                {
                    ProductoId = producto.Id,
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
                    ProductoId = item.ProductoId,
                    NombreProducto = item.Producto?.Nombre ?? "Unknown",
                    Precio = item.Producto?.Precio ?? 0, 
                    Cantidad = item.Cantidad,
                };
                await _encargueService.AddAsync(encargue);
                await _carritoService.DeleteAsync(item.Id);
            }
        }
        public async Task UpdateAsync(CarritoCompra carritoCompra)
        {
            await _carritoService.UpdateAsync(carritoCompra);
        }

        public async Task<int> GetTotalItemCountAsync()
        {
            var cartItems = await GetCartItemsAsync();
            return cartItems.Sum(item => item.Cantidad);
        }

        public async Task<int> GetUniqueItemCountAsync()
        {
            var cartItems = await GetCartItemsAsync();
            return cartItems.Count;
        }
    }
}
