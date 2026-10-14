using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace AppDAPPER
{
    public class ProductoRepository
    {
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=SistemaVentas;Integrated Security = True; TrustServerCertificate=True";
        // private readonly string _connectionString = "Server=localhost;Database=AppDAPPER;User Id=sa;Password=your_password;";

        public IEnumerable<Producto> GetAllProductos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var productos = connection.Query<Producto>("SELECT * FROM Productos");
                return productos;
            }
        }

        public int InsertProducto(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Productos (CategoriaID, Nombre, Precio, Stock) " +
                    "VALUES (@CategoriaID, @Nombre, @Precio, @Stock); " +
                    "SELECT CAST(SCOPE_IDENTITY() as int)";
                var productoId = connection.QuerySingle<int>(query, producto);
                return productoId;
            }
        }

        public int UpdateProducto(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Productos SET CategoriaID = @CategoriaID, " +
                    "Nombre = @Nombre, " +
                    "Precio = @Precio," +
                    " Stock = @Stock " +
                    "WHERE ProductoID = @ProductoID";
                var rowsAffected = connection.Execute(query, producto);
                return rowsAffected;
            }
        }

        public int DeleteProducto(int productoId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Productos WHERE ProductoID = @ProductoID";
                var rowsAffected = connection.Execute(query, new { ProductoID = productoId });
                return rowsAffected;
            }


        }
    }
}
