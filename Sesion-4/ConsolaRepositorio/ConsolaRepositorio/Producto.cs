using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaRepositorio
{
    public  class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public override string ToString() => $"[Id: {Id}] {Nombre} - ${Precio}";
       
    }
}
