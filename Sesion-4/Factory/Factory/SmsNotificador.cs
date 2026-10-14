using System;

namespace Factory
{
    public class SmsNotificador : INotificador
    {
        public string Nombre => "SMS";

        public void Enviar(string destinatario, string mensaje)
        {
            Console.WriteLine($"[SMS] Para: {destinatario} - Mensaje: {mensaje}");
    
        }
    }
}
