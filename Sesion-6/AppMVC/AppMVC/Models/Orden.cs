using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVC.Models
{
    public  class Orden
    {
        public int OrdenID { get; set; }
        public int ClienteID { get; set; }
        public DateTime FechaOrden { get; set; }
        public decimal Total { get; set; }

        public Cliente Cliente { get; set; }
        public List<OrdenDetalle> OrdenDetalles { get; set; }
    }
}
