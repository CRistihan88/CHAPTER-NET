using System;
using System.Collections.Generic;

namespace GestorDeNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numeros = new List<double>();

            Console.WriteLine("=== GESTOR DE NÚMEROS ===");
            Console.Write("¿Cuántos números deseas ingresar? ");

            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Cantidad no válida. Saliendo del programa...");
                return;
            }

            // Ciclo para capturar los números
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Ingresa el número {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    numeros.Add(num);
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Intenta de nuevo.");
                    i--; // Repetir el intento para este índice
                }
            }

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ DE OPCIONES ---");
                Console.WriteLine("1. Mostrar número mayor y menor");
                Console.WriteLine("2. Calcular el promedio");
                Console.WriteLine("3. Ordenar ascendente y mostrar");
                Console.WriteLine("4. Ordenar descendente y mostrar");
                Console.WriteLine("5. Buscar un número (Búsqueda Lineal)");
                Console.WriteLine("6. Salir");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarMayorYMenor(numeros);
                        break;
                    case "2":
                        CalcularPromedio(numeros);
                        break;
                    case "3":
                        numeros.Sort();
                        Console.WriteLine("Lista en orden ascendente: " + string.Join(", ", numeros));
                        break;
                    case "4":
                        numeros.Sort();
                        numeros.Reverse();
                        Console.WriteLine("Lista en orden descendente: " + string.Join(", ", numeros));
                        break;
                    case "5":
                        BuscarNumero(numeros);
                        break;
                    case "6":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        // Método para encontrar Mayor y Menor usando ciclos (sin LINQ)
        static void MostrarMayorYMenor(List<double> lista)
        {
            double mayor = lista[0];
            double menor = lista[0];

            foreach (double num in lista)
            {
                if (num > mayor) mayor = num;
                if (num < menor) menor = num;
            }

            Console.WriteLine($"\nEl número mayor es: {mayor}");
            Console.WriteLine($"El número menor es: {menor}");
        }

        // Método para calcular el promedio manualmente
        static void CalcularPromedio(List<double> lista)
        {
            double suma = 0;
            foreach (double num in lista)
            {
                suma += num;
            }

            double promedio = suma / lista.Count;
            Console.WriteLine($"\nEl promedio de los números es: {promedio:F2}");
        }

        // Método que implementa una Búsqueda Lineal
        static void BuscarNumero(List<double> lista)
        {
            Console.Write("\nIngresa el número que deseas buscar: ");
            if (double.TryParse(Console.ReadLine(), out double objetivo))
            {
                bool encontrado = false;

                // Búsqueda lineal básica
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i] == objetivo)
                    {
                        Console.WriteLine($"Número {objetivo} encontrado en la posición {i + 1} (índice {i}).");
                        encontrado = true;
                        break; // Detenemos la búsqueda al encontrar la primera coincidencia
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine($"El número {objetivo} no se encuentra en la lista.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
            }
        }
    }
}