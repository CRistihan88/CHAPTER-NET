using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepositorio
{
    public  interface IProductoRepository
    {
        IEnumerable<Producto> GetAll();
        Producto GetById(int id);
        void Add(Producto producto);
        void Update(Producto producto);
        void Delete(int id);
    }
}
