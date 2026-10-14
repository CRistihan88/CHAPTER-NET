using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorSolid
{
    public class ProcesoReporte
    {
        public readonly Reporte reporte;
        public readonly Datos datos;
        public readonly Correo correo;
        public readonly Archivo archivo;

        public ProcesoReporte()
        {
            reporte = new Reporte();
            datos = new Datos();
            correo = new Correo();
            archivo = new Archivo();
        }

        public void EjecutarProceso()
        {
            Console.WriteLine("Iniciando proceso de reporte...");
            datos.ConsultarDatos();
            reporte.GenerarReporte();
            correo.EnviarCorreo();
            archivo.GuardarArchivo();
            Console.WriteLine("Proceso de reporte finalizado.");
        }

    }
}
