using System;

namespace Factory
{
    public static class NotificadorFactory
    {
        public static INotificador Crear(NotificadorTipo tipo)
        {
            return tipo switch
            {
                NotificadorTipo.Email => new EmailNotificador(),
                NotificadorTipo.SMS => new SmsNotificador(),
                NotificadorTipo.Teams => new TeamsNotificador(),
                _ => throw new ArgumentException("Tipo de notificador desconocido", nameof(tipo)),
            };
        }

        public static INotificador Crear(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("Debe especificar un tipo de notificador: email, sms o teams.");

            return tipo.Trim().ToLowerInvariant() switch
            {
                "email" or "e" => Crear(NotificadorTipo.Email),
                "sms" or "s" => Crear(NotificadorTipo.SMS),
                "teams" or "t" => Crear(NotificadorTipo.Teams),
                _ => throw new ArgumentException($"Tipo de notificador no soportado: {tipo}"),
            };
        }
    }
}
