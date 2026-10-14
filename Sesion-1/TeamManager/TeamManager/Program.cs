using System;
using System.Collections.Generic;

namespace TeamManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicialización de la List<T>
            List<string> teamMembers = new List<string>();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- Gestión de Team Members ---");
                Console.WriteLine("1. Agregar un nombre");
                Console.WriteLine("2. Eliminar un nombre");
                Console.WriteLine("3. Buscar un nombre");
                Console.WriteLine("4. Mostrar todos los nombres (Ordenados)");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre a agregar: ");
                        string nuevoNombre = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            teamMembers.Add(nuevoNombre.Trim());
                            Console.WriteLine($"[+] '{nuevoNombre}' agregado con éxito.");
                        }
                        break;

                    case "2":
                        Console.Write("Ingrese el nombre a eliminar: ");
                        string nombreEliminar = Console.ReadLine();

                        // Remove() devuelve true si lo encuentra y elimina, false si no
                        if (teamMembers.Remove(nombreEliminar.Trim()))
                        {
                            Console.WriteLine($"[-] '{nombreEliminar}' eliminado de la lista.");
                        }
                        else
                        {
                            Console.WriteLine("[!] Nombre no encontrado.");
                        }
                        break;

                    case "3":
                        Console.Write("Ingrese el nombre a buscar: ");
                        string nombreBuscar = Console.ReadLine();

                        // Contains() devuelve true si el elemento existe
                        if (teamMembers.Contains(nombreBuscar.Trim()))
                        {
                            Console.WriteLine($"[✓] '{nombreBuscar}' sí se encuentra en el equipo.");
                        }
                        else
                        {
                            Console.WriteLine($"[x] '{nombreBuscar}' no está en la lista.");
                        }
                        break;

                    case "4":
                        if (teamMembers.Count == 0)
                        {
                            Console.WriteLine("[!] La lista de miembros está vacía.");
                        }
                        else
                        {
                            // Sort() modifica la lista original ordenándola alfabéticamente
                            teamMembers.Sort();
                            Console.WriteLine("\n--- Lista de Team Members ---");
                            foreach (string member in teamMembers)
                            {
                                Console.WriteLine($"- {member}");
                            }
                        }
                        break;

                    case "5":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}