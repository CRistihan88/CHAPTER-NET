using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaRepositorio
{
    public  interface IProductoRepository
    {
        IEnumerable<Producto> GetAll();
        Producto GetById(int id);
        void Add(Producto producto);
        void Update(Producto producto);
        void Delete(int id);

    }

    public class ProductoRepository : IProductoRepository
    {
        private readonly List<Producto> _productos;
        private int _nextId;
        public ProductoRepository()
        {
            _productos = new List<Producto>();
            _nextId = 1;
        }
        public IEnumerable<Producto> GetAll() => _productos;
        public Producto GetById(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Producto producto)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));
            _productos.Add(producto);
        }
        public void Update(Producto producto)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));
            var existingProducto = GetById(producto.Id);
            if (existingProducto != null)
            {
                existingProducto.Nombre = producto.Nombre;
                existingProducto.Precio = producto.Precio;
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
