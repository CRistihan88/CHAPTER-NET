using System;
using AppADOTNET;

class Program
{
    static void Main(string[] args)
    {
        ProductoADO dal = new ProductoADO();

        // 1. SELECT inicial
        Console.WriteLine("ESTADO INICIAL DE LA BASE DE DATOS:");
        dal.ConsultarProductos();

        // 2. INSERT
        // Asume que la CategoríaID 1 ('Electrónica') existe en tu BD
        dal.InsertarProducto(1, "Teclado Mecánico RGB", 85.50m, 20);

        // Verificamos la inserción
        dal.ConsultarProductos();

        // 3. UPDATE
        // Actualiza el precio del producto recién insertado (asumiendo que su ID sea 4)
        // Nota: En un entorno real, recuperarías el ID generado con @@IDENTITY o SCOPE_IDENTITY()
        int idProductoActualizar = 6;
        dal.ActualizarPrecio(idProductoActualizar, 75.00m);

        // Verificamos la actualización
        dal.ConsultarProductos();

        // 4. DELETE
        dal.EliminarProducto(idProductoActualizar);

        // Verificamos la eliminación
        dal.ConsultarProductos();

        Console.ReadLine();
    }
}