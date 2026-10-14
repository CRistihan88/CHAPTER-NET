
namespace SistemaOrdenes
{

    public delegate void OrdenesNotificaciones(string mensaje);

    public class OrdenesProceso
    {
        public event OrdenesNotificaciones Notificar;
        public void ProcesarOrden(int OrdenId, string ProductoName)
        {
           
            System.Threading.Thread.Sleep(2000); // Simula el procesamiento de la orden

            String mensaje = $"La orden '{OrdenId}' con producto '{ProductoName}' ha sido procesada.";

            Notificar?.Invoke(mensaje);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrdenesProceso ordenesProceso = new OrdenesProceso();
            ordenesProceso.Notificar += MostrarNotificacion;
            Console.WriteLine("Procesando orden...");
            ordenesProceso.ProcesarOrden(123, "Producto A");
        }
        static void MostrarNotificacion(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }






}
