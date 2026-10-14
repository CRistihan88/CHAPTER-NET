using System;

namespace Factory
{
    public class EmailNotificador : INotificador
    {
        public string Nombre => "Email";

        public void Enviar(string destinatario, string mensaje)
        {
            Console.WriteLine($"[Email] Para: {destinatario} - Mensaje: {mensaje}");
           
        }
    }
}
