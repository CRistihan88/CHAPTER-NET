using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fábrica de notificadores\nElige un tipo: email, sms, teams");
            var tipo = args.Length > 0 ? args[0] : Console.ReadLine() ?? string.Empty;

            try
            {
                var notificador = NotificadorFactory.Crear(tipo);
                notificador.Enviar("destinatario@ejemplo.com", "Hola desde la fábrica de notificadores");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
