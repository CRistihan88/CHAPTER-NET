using System;

namespace ReporteService
{
    public class ReporteOrquestador
    {
        private readonly DatosRepository _datosRepository;
        private readonly ReporteGenerador _reporteGenerador;
        private readonly AlmacenamientoService _almacenamientoService;
        private readonly EmailService _emailService;

        // Inyección de dependencias a través del constructor
        public ReporteOrquestador(
            DatosRepository datosRepository,
            ReporteGenerador reporteGenerador,
            AlmacenamientoService almacenamientoService,
            EmailService emailService)
        {
            _datosRepository = datosRepository;
            _reporteGenerador = reporteGenerador;
            _almacenamientoService = almacenamientoService;
            _emailService = emailService;
        }

        public void EjecutarProcesoCompleto()
        {
            _datosRepository.ConsultarDatos();
            _reporteGenerador.GenerarReporte();
            _almacenamientoService.GuardarArchivo();
            _emailService.EnviarCorreo();
        }
    }
}
