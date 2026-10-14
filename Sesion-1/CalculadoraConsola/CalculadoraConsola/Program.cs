using System;

namespace CalculadoraConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            // Ciclo que mantiene la aplicación ejecutándose hasta que el usuario decida salir
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== CALCULADORA BÁSICA ===");

                // Variables y llamadas a métodos para obtener los números
                double numero1 = SolicitarNumero("Ingrese el primer número: ");
                double numero2 = SolicitarNumero("Ingrese el segundo número: ");

                Console.WriteLine("\nSeleccione una operación:");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.Write("Opción (1-4): ");

                string opcion = Console.ReadLine();

                Console.WriteLine("\n--- RESULTADO ---");

                // Condicional múltiple para evaluar la opción elegida
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine($"{numero1} + {numero2} = {Sumar(numero1, numero2)}");
                        break;
                    case "2":
                        Console.WriteLine($"{numero1} - {numero2} = {Restar(numero1, numero2)}");
                        break;
                    case "3":
                        Console.WriteLine($"{numero1} * {numero2} = {Multiplicar(numero1, numero2)}");
                        break;
                    case "4":
                        RealizarDivision(numero1, numero2);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione un número del 1 al 4.");
                        break;
                }

                Console.WriteLine("-----------------");
                Console.Write("\n¿Desea realizar otra operación? (s/n): ");

                string respuesta = Console.ReadLine()?.ToLower();
                if (respuesta != "s")
                {
                    continuar = false;
                    Console.WriteLine("Saliendo de la aplicación...");
                }
            }
        }

        // --- MÉTODOS DE LA APLICACIÓN ---

        /// <summary>
        /// Método para solicitar un número y validar que la entrada sea correcta mediante un ciclo.
        /// </summary>
        static double SolicitarNumero(string mensaje)
        {
            double numero;
            Console.Write(mensaje);

            // TryParse intenta convertir el texto a número. Si falla, repite el ciclo.
            while (!double.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Error: Entrada inválida. Debe ingresar un número.");
                Console.Write(mensaje);
            }

            return numero;
        }

        static double Sumar(double a, double b)
        {
            return a + b;
        }

        static double Restar(double a, double b)
        {
            return a - b;
        }

        static double Multiplicar(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Método para dividir que incluye la condicional de validación por cero.
        /// </summary>
        static void RealizarDivision(double a, double b)
        {
            // Condicional para evitar la excepción de división por cero
            if (b == 0)
            {
                Console.WriteLine("Error: No se puede dividir entre cero.");
            }
            else
            {
                Console.WriteLine($"{a} / {b} = {a / b}");
            }
        }
    }
}