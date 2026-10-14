namespace HistorialNavegador
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<string> historial = new Stack<string>();
            bool salir = false;
            Console.WriteLine("=== Simulador de Historial Web (LIFO) ===");

            while (!salir)
            {
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Agregar URL al historial");
                Console.WriteLine("2. Retroceder a la URL anterior");
                Console.WriteLine("3. Mostrar Pagina Actual");
                Console.WriteLine("4. Mostrar historial");
                Console.WriteLine("5. Salir");
                Console.Write("Opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese la URL:");
                        string url = Console.ReadLine();
                        historial.Push(url);
                        Console.WriteLine("URL agregada al historial:  {url}");
                        break;

                    case "2":
                        if (historial.Count > 1)
                        {
                            string paginaCerrada = historial.Pop();
                            Console.WriteLine("Saliste de la Página cerrada: " + paginaCerrada);

                            Console.WriteLine($"[Actual] Ahora estás en: {historial.Peek()}");
                        }
                        else if (historial.Count == 1)
                        {
                            string paginaCerrada = historial.Pop();
                            Console.WriteLine("Saliste de la Página cerrada: " + paginaCerrada);
                            Console.WriteLine("No hay más páginas en el historial, Abre una nueva.");
                        }
                        else
                        {
                            Console.WriteLine("No hay páginas en el historial.");
                        }
                        break;


                    case "3":
                        
                        if(historial.Count > 0)
                        {
                            Console.WriteLine($"[Actual] Estás en: {historial.Peek()}");
                        }
                        else
                        {
                            Console.WriteLine("No hay páginas en el historial.");
                        }
                        break;

                    case "4":
                        if (historial.Count > 0)
                        {
                            Console.WriteLine("Historial de páginas visitadas:");
                            foreach (string pagina in historial)
                            {
                                Console.WriteLine(pagina);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay páginas en el historial.");
                        }
                        break;

                    case "5":
                        salir = true;
                        Console.WriteLine("Cerrando el navegador...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }



         }
    }
}
