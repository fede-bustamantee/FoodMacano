using FoodMacanoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodMacanoServices.Services
{
    public class DesktopCarrito
    {
        // Instancia única (Singleton)
        private static DesktopCarrito instance;
        private static readonly object lockObject = new object();
        public string NumeroMesa { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaPedido { get; set; }


        // Propiedades
        public List<CarritoCompra> Items { get; private set; }
        public decimal Total { get; private set; }

        // Evento para notificar cambios en el carrito
        public event EventHandler CarritoActualizado;

        // Constructor privado (parte del patrón Singleton)
        private DesktopCarrito()
        {
            Items = new List<CarritoCompra>();
            Total = 0;
        }

        // Propiedad para obtener la instancia única
        public static DesktopCarrito Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance ??= new DesktopCarrito();
                    }
                }
                return instance;
            }
        }

        // Método para agregar productos al carrito
        public void AgregarProducto(Producto producto)
        {
            var itemExistente = Items.FirstOrDefault(i => i.Producto.Id == producto.Id);

            if (itemExistente != null)
            {
                itemExistente.Cantidad++;
            }
            else
            {
                Items.Add(new CarritoCompra
                {
                    Producto = producto,
                    Cantidad = 1
                });
            }

            ActualizarTotal();
            CarritoActualizado?.Invoke(this, EventArgs.Empty);
        }

        // Método para remover productos del carrito
        public void RemoverProducto(CarritoCompra item)
        {
            Items.Remove(item);
            ActualizarTotal();
            CarritoActualizado?.Invoke(this, EventArgs.Empty);
        }

        // Método para limpiar todo el carrito
        public void LimpiarCarrito()
        {
            Items.Clear();
            Total = 0;
            CarritoActualizado?.Invoke(this, EventArgs.Empty);
        }

        // Método privado para actualizar el total
        private void ActualizarTotal()
        {
            Total = Items.Sum(item => item.Producto.Precio * item.Cantidad);
        }
    }
}