using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVC.Models
{
    public  class Cliente
    {
        public int ClienteID { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public List<Orden> Ordenes { get; set; }

    }
}
