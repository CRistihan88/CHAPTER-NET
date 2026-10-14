namespace ReservasClient.Models
{
    

        public class Reserva
        {
            public Guid Id { get; set; }
            public string NombreSala { get; set; } = string.Empty;
            public DateTime FechaReserva { get; set; }
            public TimeSpan HoraInicio { get; set; }
            public TimeSpan HoraFin { get; set; }
            public string Responsable { get; set; } = string.Empty;
            public int CantidadAsistentes { get; set; }
            public string Motivo { get; set; } = string.Empty;
            public EstadoReserva Estado { get; set; }
        }
    
    
}
