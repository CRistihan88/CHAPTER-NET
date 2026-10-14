using ReporteService;

class Program
{
    static void Main(string[] args)
    {
        // Se instancian las dependencias
        var datos = new DatosRepository();
        var generador = new ReporteGenerador();
        var almacenamiento = new AlmacenamientoService();
        var email = new EmailService();

        // Se inyectan en el orquestador
        var orquestador = new ReporteOrquestador(datos, generador, almacenamiento, email);

        // Se ejecuta el flujo
        Console.WriteLine("--- Iniciando proceso de reporte ---");
        orquestador.EjecutarProcesoCompleto();
        Console.WriteLine("--- Proceso finalizado ---");
    }
}