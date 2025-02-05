using FoodMacanoApp.Class;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using FoodMacanoServices.Interfaces;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;

namespace FoodMacanoApp.ViewModels
{
	public class InicioViewModel : NotificationObject
	{
		private readonly IGenericService<Producto> _productoService;
		private readonly IGenericService<Categoria> _categoriaService;
		public readonly MauiCarritoService _carritoService;
		private ObservableCollection<Producto> _todosLosProductos;
		public event EventHandler DatosCargados;

		private int _cantidadEnCarrito;
		public int CantidadEnCarrito
		{
			get => _cantidadEnCarrito;
			set
			{
				if (_cantidadEnCarrito != value)
				{
					_cantidadEnCarrito = value;
					OnPropertyChanged();
				}
			}
		}

		public ObservableCollection<Producto> TodosLosProductos
		{
			get => _todosLosProductos;
			set
			{
				if (_todosLosProductos != value)
				{
					_todosLosProductos = value;
					OnPropertyChanged();
				}
			}
		}

		private ObservableCollection<Producto> _ofertasEspeciales;
		public ObservableCollection<Producto> OfertasEspeciales
		{
			get => _ofertasEspeciales;
			set
			{
				if (_ofertasEspeciales != value)
				{
					_ofertasEspeciales = value;
					OnPropertyChanged();
				}
			}
		}

		private ObservableCollection<Producto> _productosFiltrados;
		public ObservableCollection<Producto> ProductosFiltrados
		{
			get => _productosFiltrados;
			set
			{
				if (_productosFiltrados != value)
				{
					_productosFiltrados = value;
					OnPropertyChanged();
				}
			}
		}

		private ObservableCollection<Categoria> _categorias;
		public ObservableCollection<Categoria> Categorias
		{
			get => _categorias;
			set
			{
				if (_categorias != value)
				{
					_categorias = value;
					OnPropertyChanged();
				}
			}
		}

		private string _mensajeError;
		public string MensajeError
		{
			get => _mensajeError;
			set
			{
				if (_mensajeError != value)
				{
					_mensajeError = value;
					OnPropertyChanged();
				}
			}
		}
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshData());
        public InicioViewModel(
			IGenericService<Producto> productoService,
			IGenericService<Categoria> categoriaService,
			MauiCarritoService carritoService)
		{
			_productoService = productoService;
			_categoriaService = categoriaService;
			_carritoService = carritoService;

			OfertasEspeciales = new ObservableCollection<Producto>();
			ProductosFiltrados = new ObservableCollection<Producto>();
			Categorias = new ObservableCollection<Categoria>();
			TodosLosProductos = new ObservableCollection<Producto>();

			Task.Run(async () => await CargarDatosIniciales());
		}

		private async Task CargarDatosIniciales()
		{
			try
			{
				await CargarOfertasAleatorias();
				await CargarCategorias();
				await CargarTodosLosProductos();

				if (Categorias.Count > 0)
				{
					var primeraCategoria = Categorias.FirstOrDefault();
					FiltrarProductosPorCategoria(primeraCategoria);
				}

				CantidadEnCarrito = await _carritoService.GetUniqueItemCountAsync();
				DatosCargados?.Invoke(this, EventArgs.Empty);
				MensajeError = string.Empty;
			}
			catch (Exception ex)
			{
				MensajeError = $"Error al cargar datos iniciales: {ex.Message}";
				Console.WriteLine($"Error en CargarDatosIniciales: {ex}");
			}
		}

		private async Task CargarTodosLosProductos()
		{
			try
			{
				var productos = await _productoService.GetAllAsync();
				if (productos != null)
				{
					TodosLosProductos.Clear();
					foreach (var producto in productos)
					{
						TodosLosProductos.Add(producto);
					}
				}
				MensajeError = string.Empty;
			}
			catch (Exception ex)
			{
				MensajeError = $"Error al cargar productos: {ex.Message}";
				Console.WriteLine($"Error en CargarTodosLosProductos: {ex}");
			}
		}

        private async Task CargarOfertasAleatorias()
        {
            try
            {
                var ofertas = await _productoService.GetRandomAsync(8);
                if (ofertas != null)
                {
                    OfertasEspeciales = new ObservableCollection<Producto>(ofertas);
                }
                MensajeError = string.Empty;
            }
            catch (Exception ex)
            {
                MensajeError = $"Error al cargar ofertas: {ex.Message}";
                Console.WriteLine($"Error en CargarOfertasAleatorias: {ex}");
            }
        }

        private async Task CargarCategorias()
		{
			try
			{
				var categorias = await _categoriaService.GetAllAsync();
				if (categorias != null)
				{
					Categorias.Clear();
					foreach (var categoria in categorias)
					{
						Categorias.Add(categoria);
					}
				}
				MensajeError = string.Empty;
			}
			catch (Exception ex)
			{
				MensajeError = $"Error al cargar categorías: {ex.Message}";
				Console.WriteLine($"Error en CargarCategorias: {ex}");
			}
		}

		public void FiltrarProductosPorCategoria(Categoria categoria)
		{
			try
			{
				if (categoria == null) return;

				ProductosFiltrados.Clear();
				var productosFiltrados = TodosLosProductos.Where(p => p.CategoriaId == categoria.Id);
				foreach (var producto in productosFiltrados)
				{
					ProductosFiltrados.Add(producto);
				}
				MensajeError = string.Empty;
			}
			catch (Exception ex)
			{
				MensajeError = $"Error al filtrar productos: {ex.Message}";
				Console.WriteLine($"Error en FiltrarProductosPorCategoria: {ex}");
			}
		}

		public async Task AgregarAlCarrito(Producto producto)
		{
			try
			{
				await _carritoService.AddToCartAsync(producto);
				CantidadEnCarrito = await _carritoService.GetUniqueItemCountAsync();
				MensajeError = string.Empty;
			}
			catch (Exception ex)
			{
				MensajeError = $"Error al agregar al carrito: {ex.Message}";
				Console.WriteLine($"Error en AgregarAlCarrito: {ex}");
				throw;
			}
		}
        private async Task RefreshData()
        {
            try
            {
                IsRefreshing = true;
                await CargarDatosIniciales();
                CantidadEnCarrito = await _carritoService.GetUniqueItemCountAsync();
            }
            catch (Exception ex)
            {
                // Handle error
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}