using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVC.Models
{
    public  class OrdenDetalle
    {
        public int OrdenID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Orden Orden { get; set; }
        public Producto Producto { get; set; }
    }
}
