//using FoodMacanoApp.Class;
//using FoodMacanoServices.Models;
//using FoodMacanoServices.Services;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FoodMacanoApp.ViewModels
//{
//    public class InicioViewModel : NotificationObject
//    {
//        private GenericService<Producto> _productoService;
//        private GenericService<Categoria> _categoriaService;
//        private CarritoComprasService _carritoComprasService;
//        private ObservableCollection<Producto> _todosLosProductos;
//        public event EventHandler DatosCargados;

//        private int _cantidadEnCarrito;
//        public int CantidadEnCarrito
//        {
//            get => _cantidadEnCarrito;
//            set
//            {
//                _cantidadEnCarrito = value;
//                OnPropertyChanged();
//            }
//        }
//        public ObservableCollection<Producto> TodosLosProductos
//        {
//            get => _todosLosProductos;
//            set
//            {
//                _todosLosProductos = value;
//                OnPropertyChanged();
//            }
//        }

//        private ObservableCollection<Producto> _ofertasEspeciales;
//        public ObservableCollection<Producto> OfertasEspeciales
//        {
//            get => _ofertasEspeciales;
//            set
//            {
//                _ofertasEspeciales = value;
//                OnPropertyChanged();
//            }
//        }

//        private ObservableCollection<Producto> _productosFiltrados;
//        public ObservableCollection<Producto> ProductosFiltrados
//        {
//            get => _productosFiltrados;
//            set
//            {
//                _productosFiltrados = value;
//                OnPropertyChanged();
//            }
//        }

//        private ObservableCollection<Categoria> _categorias;
//        public ObservableCollection<Categoria> Categorias
//        {
//            get => _categorias;
//            set
//            {
//                _categorias = value;
//                OnPropertyChanged();
//            }
//        }

//        public InicioViewModel()
//        {
//            _productoService = new GenericService<Producto>();
//            _categoriaService = new GenericService<Categoria>();
//            _carritoComprasService = new CarritoComprasService(
//                new GenericService<CarritoCompra>(),
//                new GenericService<Encargue>(),
//                new HttpClient(),
//                null
//            );

//            OfertasEspeciales = new ObservableCollection<Producto>();
//            ProductosFiltrados = new ObservableCollection<Producto>();
//            Categorias = new ObservableCollection<Categoria>();
//            TodosLosProductos = new ObservableCollection<Producto>();

//            CargarDatosIniciales();
//        }

//        private async Task CargarDatosIniciales()
//        {
//            await CargarOfertasAleatorias();
//            await CargarCategorias();
//            await CargarTodosLosProductos();

//            // Filtrar productos por la primera categoría cargada
//            if (Categorias.Count > 0)
//            {
//                var primeraCategoria = Categorias.FirstOrDefault();
//                FiltrarProductosPorCategoria(primeraCategoria);
//            }
//            CantidadEnCarrito = await _carritoComprasService.GetUniqueItemCountAsync();

//            // Notificar que los datos han sido cargados
//            DatosCargados?.Invoke(this, EventArgs.Empty);
//        }

//        private async Task CargarTodosLosProductos()
//        {
//            var productos = await _productoService.GetAllAsync();
//            if (productos != null)
//            {
//                TodosLosProductos.Clear();
//                foreach (var producto in productos)
//                {
//                    TodosLosProductos.Add(producto);
//                }
//            }
//        }

//        private async Task CargarOfertasAleatorias()
//        {
//            var ofertas = await _productoService.GetRandomAsync(8);
//            if (ofertas != null)
//            {
//                OfertasEspeciales.Clear();
//                foreach (var oferta in ofertas)
//                {
//                    OfertasEspeciales.Add(oferta);
//                }
//            }
//        }

//        private async Task CargarCategorias()
//        {
//            var categorias = await _categoriaService.GetAllAsync();
//            if (categorias != null)
//            {
//                Categorias.Clear();
//                foreach (var categoria in categorias)
//                {
//                    Categorias.Add(categoria);
//                }
//            }
//        }

//        public void FiltrarProductosPorCategoria(Categoria categoria)
//        {
//            if (categoria == null) return;

//            ProductosFiltrados.Clear();

//            foreach (var producto in TodosLosProductos)
//            {
//                if (producto.CategoriaId == categoria.Id)
//                {
//                    ProductosFiltrados.Add(producto);
//                }
//            }
//        }

//        public async Task AgregarAlCarrito(Producto producto)
//        {
//            try
//            {
//                await _carritoComprasService.AddToCartAsync(producto);
//                CantidadEnCarrito = await _carritoComprasService.GetUniqueItemCountAsync();
//            }
//            catch (Exception ex)
//            {
//                throw; 
//            }
//        }

//    }
//}