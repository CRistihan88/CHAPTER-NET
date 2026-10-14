using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVC.Models
{
    public  class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Propiedad de navegación
        public List<Producto> Productos { get; set; }
    }
}
