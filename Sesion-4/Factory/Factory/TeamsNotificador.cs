using System;

namespace Factory
{
    public class TeamsNotificador : INotificador
    {
        public string Nombre => "Teams";

        public void Enviar(string destinatario, string mensaje)
        {
            Console.WriteLine($"[Teams] Canal/Usuario: {destinatario} - Mensaje: {mensaje}");
            
        }
    }
}
