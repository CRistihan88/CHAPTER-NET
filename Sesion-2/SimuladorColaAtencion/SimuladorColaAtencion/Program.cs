using System.Collections.Generic;

namespace SimuladorColaAtencion
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> colaAtencion = new Queue<string>();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n=== SISTEMA DE ATENCIÓN (FIFO) ===");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Agregar persona a la cola");
                Console.WriteLine("2. Atender al primero");
                Console.WriteLine("3. Mostrar cantidad de pendientes");
                Console.WriteLine("4. Mostrar siguiente persona");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese el nombre de la persona:");
                        string nombre = Console.ReadLine();
                        colaAtencion.Enqueue(nombre);
                        Console.WriteLine($"{nombre} ha sido agregado a la cola.");
                        break;

                    case "2":
                        if (colaAtencion.Count > 0)
                        {
                            string atendido = colaAtencion.Dequeue();
                            Console.WriteLine($"{atendido} ha sido atendido.");
                        }
                        else
                        {
                            Console.WriteLine("No hay personas en la cola.");
                        }
                        break;

                    case "3":
                        if (colaAtencion.Count > 0)
                        {
                            Console.WriteLine("Personas en la cola:");
                            foreach (string persona in colaAtencion)
                            {
                                Console.WriteLine(persona);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay personas en la cola.");
                        }
                        break;

                    case "4":
                        if (colaAtencion.Count > 0)
                        {
                            string siguiente = colaAtencion.Peek();
                            Console.WriteLine($"La siguiente persona en la cola es: {siguiente}");
                        }
                        else
                        {
                            Console.WriteLine("No hay personas en la cola.");
                        }
                        break;

                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente nuevamente.");
                        break;
                }
            }



        }

    }

}