using System;

namespace PatronesFactory
{

    public enum TipoNotificador
    {
        Email,
        SMS,
        Teams
    }

    public interface INotificador
    {
        void Enviar(string mensaje);
    }

    
    public class Email : INotificador
    {
        public void Enviar(string mensaje)
        {
            Console.WriteLine($"[Email] Enviando correo: {mensaje}");
        }
    }

    public class SMS : INotificador
    {
        public void Enviar(string mensaje)
        {
            Console.WriteLine($"[SMS] Enviando mensaje de texto: {mensaje}");
        }
    }

    public class Teams : INotificador
    {
        public void Enviar(string mensaje)
        {
            Console.WriteLine($"[Teams] Enviando mensaje al canal: {mensaje}");
        }
    }

   
   
    public class NotificadorFactory
    {
        public static INotificador CrearNotificador(TipoNotificador tipo)
        {
            return tipo switch
            {
                TipoNotificador.Email => new Email(),
                TipoNotificador.SMS => new SMS(),
                TipoNotificador.Teams => new Teams(),
                _ => throw new ArgumentException($"El tipo de notificación '{tipo}' no está soportado.")
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Sistema de Notificaciones (Patrón Factory) ---\n");

            INotificador notificadorEmail = NotificadorFactory.CrearNotificador(TipoNotificador.Email);
            notificadorEmail.Enviar("Bienvenido a la plataforma.");

            INotificador notificadorSms = NotificadorFactory.CrearNotificador(TipoNotificador.SMS);
            notificadorSms.Enviar("Tu código de seguridad es 8492.");

            INotificador notificadorTeams = NotificadorFactory.CrearNotificador(TipoNotificador.Teams);
            notificadorTeams.Enviar("Alerta: Se detectó un pico de tráfico en el servidor principal.");

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}