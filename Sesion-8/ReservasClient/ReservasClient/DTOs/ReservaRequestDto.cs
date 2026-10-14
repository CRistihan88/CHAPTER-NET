using System.ComponentModel.DataAnnotations;

namespace ReservasClient.DTOs
{
    public class ReservaRequestDto : IValidatableObject
    {
        [Required(ErrorMessage = "El nombre de la sala es obligatorio.")]
        public string NombreSala { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de reserva es obligatoria.")]
        public DateTime FechaReserva { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }

        [Required(ErrorMessage = "El responsable es obligatorio.")]
        public string Responsable { get; set; } = string.Empty;

        // Valida que la cantidad sea mayor a 0
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de asistentes debe ser mayor a cero.")]
        public int CantidadAsistentes { get; set; }

        public string Motivo { get; set; } = string.Empty;

        // Lógica: La hora de fin debe ser posterior a la hora de inicio
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HoraFin <= HoraInicio)
            {
                yield return new ValidationResult(
                    "La hora de fin debe ser posterior a la hora de inicio.",
                    new[] { nameof(HoraFin) }
                );
            }
        }
    }
}
