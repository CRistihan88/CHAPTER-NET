using AppRepositorio;

class Program
{
    static void Main(string[] args)
    {
        
        IProductoRepository repository = new ProductoRepository();

        
        repository.Add(new Producto { Nombre = "Laptop", Precio = 1200.50m });
        repository.Add(new Producto { Nombre = "Teclado Mecánico", Precio = 85.00m });
        repository.Add(new Producto { Nombre = "Ratón Inalámbrico", Precio = 45.99m });

        Console.WriteLine("--- Productos Agregados ---");
        MostrarProductos(repository);

        
        Console.WriteLine("\n--- Buscar Producto por Id (2) ---");
        var productoEncontrado = repository.GetById(2);
        if (productoEncontrado != null)
        {
            Console.WriteLine($"Encontrado: {productoEncontrado.Nombre} - ${productoEncontrado.Precio}");
        }

        
        Console.WriteLine("\n--- Actualizar Producto (Id 2) ---");
        if (productoEncontrado != null)
        {
            productoEncontrado.Precio = 75.00m; 
            productoEncontrado.Nombre = "Teclado Mecánico (Oferta)";
            repository.Update(productoEncontrado);
        }
        MostrarProductos(repository);

       
        Console.WriteLine("\n--- Eliminar Producto (Id 3) ---");
        repository.Delete(3);
        MostrarProductos(repository);

        Console.ReadLine();
    }

    
    static void MostrarProductos(IProductoRepository repo)
    {
        var productos = repo.GetAll();
        foreach (var p in productos)
        {
            Console.WriteLine($"[{p.Id}] {p.Nombre} - ${p.Precio}");
        }
    }
}
