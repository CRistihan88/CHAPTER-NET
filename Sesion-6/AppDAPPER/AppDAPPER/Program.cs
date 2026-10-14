using System;
using AppDAPPER;

class Program
{
    static void Main(string[] args)
    {
        var productoRepository = new ProductoRepository();

        Console.WriteLine("=== INICIO CRUD CON DAPPER ===\n");

        
        Console.WriteLine("1. Insertando un nuevo producto...");
        // Insert a new product
        var newProducto = new Producto
        {
            CategoriaID = 1,
            Nombre = "Producto de prueba",
            Precio = 10.99m,
            Stock = 100
        };

        int newProductoId = productoRepository.InsertProducto(newProducto);
        Console.WriteLine($"Producto insertado con ID: {newProductoId}\n");

        Console.WriteLine("2. Obteniendo todos los productos...");
        // Get all products
        var productos = productoRepository.GetAllProductos();
        foreach (var producto in productos)
        {
            Console.WriteLine($"ID: {producto.ProductoID}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.Stock}");
        }
        Console.WriteLine();

        //actualizar producto
        Console.WriteLine("3. Actualizando el producto insertado...");
        newProducto.ProductoID = newProductoId;
        newProducto.Nombre = "Producto actualizado";
        newProducto.Precio = 12.99m;

        int rowsAffected = productoRepository.UpdateProducto(newProducto);
        Console.WriteLine($"Producto actualizado, filas afectadas: {rowsAffected}\n");

        // (Opcional) Consultar de nuevo para ver el cambio
        Console.WriteLine("-> Estado después de actualizar:");
        foreach (var prod in productoRepository.GetAllProductos())
        {
            if (prod.ProductoID == newProductoId)
                Console.WriteLine($"   Modificado -> ID: {prod.ProductoID} | Nombre: {prod.Nombre} | Nuevo Precio: ${prod.Precio}");
        }
        Console.WriteLine();


        //eliminar producto
        Console.WriteLine("4. Eliminando el producto insertado...");
        rowsAffected = productoRepository.DeleteProducto(newProductoId);
        Console.WriteLine($"Producto eliminado, filas afectadas: {rowsAffected}\n");

        Console.WriteLine("=== FIN DEL PROCESO ===");
        Console.ReadLine();



    }
}