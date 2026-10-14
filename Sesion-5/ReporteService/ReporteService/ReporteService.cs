using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteService
{
    public class DatosRepository
    {
        public void ConsultarDatos()
        {
            Console.WriteLine("Consultar datos");
        }
    }

    public class ReporteGenerador
    {
        public void GenerarReporte()
        {
            Console.WriteLine("Generar reporte");
        }
    }

    public class AlmacenamientoService
    {
        public void GuardarArchivo()
        {
            Console.WriteLine("Guardar archivo");
        }
    }

    public class EmailService
    {
        public void EnviarCorreo()
        {
            Console.WriteLine("Enviar correo");
        }
    }

}
