using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepositorio
{
    public   class ProductoRepository : IProductoRepository
    {
        // Simulamos la base de datos con una lista privada
        private readonly List<Producto> _productos;
        private int _nextId = 1;

        public ProductoRepository()
        {
            _productos = new List<Producto>();
        }

        public IEnumerable<Producto> GetAll()
        {
            return _productos;
        }

        public Producto GetById(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Producto producto)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));

            producto.Id = _nextId++;
            _productos.Add(producto);
        }

        public void Update(Producto producto)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));

            var index = _productos.FindIndex(p => p.Id == producto.Id);
            if (index != -1)
            {
                _productos[index] = producto;
            }
            else
            {
                throw new KeyNotFoundException($"No se encontró el producto con Id {producto.Id}");
            }
        }

        public void Delete(int id)
        {
            var producto = GetById(id);
            if (producto != null)
            {
                _productos.Remove(producto);
            }
        }

    }
}
