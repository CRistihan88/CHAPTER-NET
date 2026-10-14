namespace InterfacesNotificaciones
{

    public interface INotificacion
    {
        void Enviar(string mensaje);
    }


    public class NotificacionEmail : INotificacion
    {
        public void Enviar(string mensaje)
        {
            Console.WriteLine($"Enviando notificación por correo electrónico: {mensaje}");
        }
    }

    public class NotificacionSMS : INotificacion
    {
        public void Enviar(string mensaje)
        {
            Console.WriteLine($"Enviando notificación por SMS: {mensaje}");
        }
    }

    public class NotificadorTeams : INotificacion
    {
        public void Enviar(string mensaje)
        {
            Console.WriteLine($"Enviando notificación por Teams: {mensaje}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            INotificacion notificacionEmail = new NotificacionEmail();
            INotificacion notificacionSMS = new NotificacionSMS();
            INotificacion notificadorTeams = new NotificadorTeams();
            notificacionEmail.Enviar("Hola, este es un mensaje de prueba por correo electrónico.");
            notificacionSMS.Enviar("Hola, este es un mensaje de prueba por SMS.");
            notificadorTeams.Enviar("Hola, este es un mensaje de prueba por Teams.");
            */

            Console.WriteLine("Iniciando Sistemas de notificación:");

            List<INotificacion> Listanotificaciones = new List<INotificacion>
            {
                new NotificacionEmail(),
                new NotificacionSMS(),
                new NotificadorTeams()
            };

            foreach (INotificacion notificacion in Listanotificaciones)
            {
                notificacion.Enviar("Hola, este es un mensaje de prueba.");
            }

            Console.WriteLine("\nNotificaciones enviadas correctamente");
            Console.ReadKey();


        }
    }





}
