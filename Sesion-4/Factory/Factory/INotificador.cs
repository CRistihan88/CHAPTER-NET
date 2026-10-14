namespace Factory
{
    public interface INotificador
    {
        string Nombre { get; }
        void Enviar(string destinatario, string mensaje);
    }
}
