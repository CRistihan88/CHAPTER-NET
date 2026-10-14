using System;
using System.Linq;
using AppMVC;
using AppMVC.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        
        using (var context = new SistemaVentasContext())
        {
           Console.WriteLine("=== INICIO CRUD CON ENTITY FRAMEWORK CORE ===\n");

            // 1. INSERT (Crear)
            Console.WriteLine("1. Insertando un nuevo producto...");
            var nuevoProducto = new Producto
            {
                CategoriaID = 1, 
                Nombre = "Monitor Curvo 27 pulgadas",
                Precio = 250.00m,
                Stock = 15
            };

            context.Productos.Add(nuevoProducto);
            context.SaveChanges(); 
            Console.WriteLine($"-> Producto insertado con ID: {nuevoProducto.ProductoID}\n");

            // 2. Consulta (SELECT)
            Console.WriteLine("2. Consultando productos...");
           
            var listaProductos = context.Productos
                                        .Include(p => p.Categoria)
                                        .ToList();

            foreach (var prod in listaProductos)
            {
                Console.WriteLine($"ID: {prod.ProductoID} | Nombre: {prod.Nombre} | Precio: {prod.Precio} | Cat: {prod.Categoria?.Nombre}");
            }
            Console.WriteLine();

            // 3. UPDATE (Actualizar)
            Console.WriteLine("3. Actualizando el precio del producto insertado...");
            
            var productoActualizar = context.Productos.Find(nuevoProducto.ProductoID);

            if (productoActualizar != null)
            {
                productoActualizar.Precio = 225.50m; 
                context.SaveChanges(); 
                Console.WriteLine($"-> Precio actualizado a {productoActualizar.Precio}\n");
            }

            // 4. DELETE (Eliminar)
            Console.WriteLine("4. Eliminando el producto...");
            var productoEliminar = context.Productos.Find(nuevoProducto.ProductoID);

            if (productoEliminar != null)
            {
                context.Productos.Remove(productoEliminar);
                context.SaveChanges(); 
                Console.WriteLine("-> Producto eliminado exitosamente.\n");
            }

            Console.WriteLine("=== FIN DEL PROCESO ===");
            Console.ReadLine();
        }
    }
}