using System.Collections.Generic;
using System.ComponentModel;

namespace DiccionarioProducto
{
    class Program
    {
        static Dictionary<int, Producto> productos = new Dictionary<int, Producto>();

        static void Main(string[] args)
        {
            // Agregar productos al diccionario
            productos.Add(1, new Producto(1, "Manzanas", 0.5m, 100));
            productos.Add(2, new Producto(2, "Naranjas", 0.6m, 80));
            productos.Add(3, new Producto(3, "Plátanos", 0.4m, 120));
            // Mostrar todos los productos
            Console.WriteLine("Lista de Productos:");
            foreach (var producto in productos.Values)
            {
                Console.WriteLine(producto);
            }
            // Buscar un producto por ID
            int idBusqueda = 2;
            if (productos.TryGetValue(idBusqueda, out Producto productoEncontrado))
            {
                Console.WriteLine($"\nProducto encontrado: {productoEncontrado}");
            }
            else
            {
                Console.WriteLine($"\nProducto con ID {idBusqueda} no encontrado.");
            }

            //  Actualizar el stock de un producto
            Console.WriteLine("\n--- ACTUALIZANDO STOCK DEL ID 1 ---");
            ActualizarStock(1, 20);

            //  Eliminar un producto
            Console.WriteLine("\n--- ELIMINANDO PRODUCTO CON ID 2 ---");
            EliminarProducto(2);

            // Mostrar productos con stock bajo (menor a 10)
            Console.WriteLine("\n--- PRODUCTOS CON STOCK BAJO (< 150) ---");
            MostrarStockBajo(150);

            Console.WriteLine("\n--- INVENTARIO FINAL ---");
            MostrarInventario();
        }

        static void ActualizarStock(int id, int cantidad)
        {
            if (productos.TryGetValue(id, out Producto producto))
            {
                producto.Stock += cantidad; // requiere que Producto tenga la propiedad Stock pública y mutable
                Console.WriteLine($"Stock actualizado: {producto}");
            }
            else
            {
                Console.WriteLine($"Producto con ID {id} no encontrado.");
            }
        }

        static void EliminarProducto(int id)
        {
            if (productos.Remove(id))
            {
                Console.WriteLine($"Producto con ID {id} eliminado.");
            }
            else
            {
                Console.WriteLine($"Producto con ID {id} no encontrado.");
            }
        }

        static void MostrarStockBajo(int umbral)
        {

            var productosBajoStock = productos.Values.Where(p => p.Stock < umbral).ToList();

            if (productosBajoStock.Count > 0)
            {
                foreach (var producto in productosBajoStock)
                {
                    Console.WriteLine(producto);

                }
            }
            else
            {
                Console.WriteLine("No hay productos con stock bajo.");
            }

        }

        static void MostrarInventario()
        {
            foreach (var producto in productos.Values)
            {
                Console.WriteLine(producto);
            }
        }
    }
}