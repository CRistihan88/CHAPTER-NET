using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVC.Models
{
    public  class Producto
    {
        public int ProductoID { get; set; }
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        // Propiedad de navegación
        public Categoria Categoria { get; set; }
        public List<OrdenDetalle> OrdenDetalles { get; set; }
    }
}
