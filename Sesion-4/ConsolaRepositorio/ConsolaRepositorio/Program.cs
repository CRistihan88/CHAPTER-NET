using ConsolaRepositorio;

class Program
{
    static void Main(string[] args)
    {
        IProductoRepository productoRepository = new ProductoRepository();

        Console.WriteLine("Bienvenido al sistema de gestión de productos.");

        productoRepository.Add(new Producto { Id = 1, Nombre = "Producto 1", Precio = 10.99m });
        productoRepository.Add(new Producto { Id = 2, Nombre = "Producto 2", Precio = 20.50m });
        productoRepository.Add(new Producto { Id = 3, Nombre = "Producto 3", Precio = 15.75m });
        productoRepository.Add(new Producto { Id = 4, Nombre = "Producto 4", Precio = 5.99m });

        Console.WriteLine("Lista de productos:");
        productoRepository.GetAll().ToList().ForEach(p => Console.WriteLine(p));

        Console.WriteLine("\n--- Buscando el Producto con ID 2 ---");
        var productoBuscado = productoRepository.GetById(2);
        Console.WriteLine(productoBuscado != null ? productoBuscado.ToString() : "No encontrado");

        Console.WriteLine("\n--- Actualizando el Precio del Producto 2 ---");
        if (productoBuscado != null)
        {
            productoBuscado.Precio = 22.50m;
            productoRepository.Update(productoBuscado);
        }

        Console.WriteLine("\nLista de productos después de la actualización:");
        productoRepository.GetAll().ToList().ForEach(p => Console.WriteLine(p));

        Console.WriteLine("\n--- Eliminando el Producto con ID 3 ---");
        productoRepository.Delete(3);


        Console.WriteLine("\nLista de productos después de la Eliminacion:");
        productoRepository.GetAll().ToList().ForEach(p => Console.WriteLine(p));


    }
}