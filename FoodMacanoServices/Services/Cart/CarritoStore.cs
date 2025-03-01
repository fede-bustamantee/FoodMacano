using FoodMacanoServices.Models.Cart;

namespace FoodMacanoServices.Services.Cart
{
    public static class CarritoStore
    {
        private static readonly Dictionary<string, List<CarritoCompra>> _carritos = new();
        private static int _nextId = 1;

        public static List<CarritoCompra> GetCarrito(string userId)
        {
            if (!_carritos.ContainsKey(userId))
            {
                _carritos[userId] = new List<CarritoCompra>();
            }
            return _carritos[userId];
        }

        public static void ClearCarrito(string userId)
        {
            if (_carritos.ContainsKey(userId))
            {
                _carritos[userId].Clear();
            }
        }

        public static int GetNextId()
        {
            return _nextId++;
        }
    }

}
