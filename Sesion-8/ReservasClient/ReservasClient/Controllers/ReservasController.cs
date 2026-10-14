using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservasClient.Models;
using ReservasClient.DTOs;

namespace ReservasClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ReservasController : ControllerBase
    {
         private static readonly List<Reserva> _reservas = new();
       
        [HttpGet]
        public IActionResult GetReservas([FromQuery] DateTime? fecha)
        {
            var query = _reservas.AsQueryable();
                        
            if (fecha.HasValue)
            {
                query = query.Where(r => r.FechaReserva.Date == fecha.Value.Date);
            }

            return Ok(query.Select(MapToResponse).ToList());
        }

       
        [HttpGet("{id}")]
        public IActionResult GetReservaById(Guid id)
        {
            var reserva = _reservas.FirstOrDefault(r => r.Id == id);
                        
            if (reserva == null) return NotFound(new { message = "Reserva no encontrada." });

            return Ok(MapToResponse(reserva));
        }

     
        [HttpPost]
        [Authorize] // Protegido por Token
        public IActionResult CreateReserva([FromBody] ReservaRequestDto request)
        {
           
            var nuevaReserva = new Reserva
            {
                Id = Guid.NewGuid(),
                NombreSala = request.NombreSala,
                FechaReserva = request.FechaReserva,
                HoraInicio = request.HoraInicio,
                HoraFin = request.HoraFin,
                Responsable = request.Responsable,
                CantidadAsistentes = request.CantidadAsistentes,
                Motivo = request.Motivo,
                Estado = EstadoReserva.Pendiente
            };

            _reservas.Add(nuevaReserva);
            return CreatedAtAction(nameof(GetReservaById), new { id = nuevaReserva.Id }, MapToResponse(nuevaReserva));
        }

       
        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult UpdateReserva(Guid id, [FromBody] ReservaRequestDto request)
        {
            var reserva = _reservas.FirstOrDefault(r => r.Id == id);

            if (reserva == null) return NotFound(new { message = "Reserva no encontrada." });

            reserva.NombreSala = request.NombreSala;
            reserva.FechaReserva = request.FechaReserva;
            reserva.HoraInicio = request.HoraInicio;
            reserva.HoraFin = request.HoraFin;
            reserva.Responsable = request.Responsable;
            reserva.CantidadAsistentes = request.CantidadAsistentes;
            reserva.Motivo = request.Motivo;

            return Ok(MapToResponse(reserva));
        }

       
        [HttpDelete("{id}")]
       // [Authorize]
        public IActionResult DeleteReserva(Guid id)
        {
            var reserva = _reservas.FirstOrDefault(r => r.Id == id);

            if (reserva == null) return NotFound(new { message = "Reserva no encontrada." });

            
            reserva.Estado = EstadoReserva.Cancelada;
            return Ok(new { message = "Reserva cancelada exitosamente." });
        }

       
        private static ReservaResponseDto MapToResponse(Reserva reserva)
        {
            return new ReservaResponseDto
            {
                Id = reserva.Id,
                NombreSala = reserva.NombreSala,
                FechaReserva = reserva.FechaReserva,
                HoraInicio = reserva.HoraInicio,
                HoraFin = reserva.HoraFin,
                Responsable = reserva.Responsable,
                CantidadAsistentes = reserva.CantidadAsistentes,
                Motivo = reserva.Motivo,
                Estado = reserva.Estado.ToString()
            };
        }
    }
}