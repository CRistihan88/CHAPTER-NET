using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AppMVC
{
    public class SistemaVentasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenDetalle> OrdenDetalles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configura la cadena de conexión a tu base de datos
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SistemaVentas;Integrated Security=True;TrustServerCertificate=True");
                                          
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre Orden y OrdenDetalle
            modelBuilder.Entity<OrdenDetalle>()
                .HasKey(od => new { od.OrdenID, od.ProductoID });
           /* modelBuilder.Entity<OrdenDetalle>()
                .HasOne(od => od.Orden)
                .WithMany(o => o.OrdenDetalles)
                .HasForeignKey(od => od.OrdenID);
            modelBuilder.Entity<OrdenDetalle>()
                .HasOne(od => od.Producto)
                .WithMany(p => p.OrdenDetalles)
                .HasForeignKey(od => od.ProductoID);

            // Configuración de la Clave Primaria Compuesta para OrdenDetalle
            modelBuilder.Entity<OrdenDetalle>()
                .HasKey(od => new { od.OrdenID, od.ProductoID });
           */
            // (Opcional) Especificar precisiones decimales para evitar advertencias
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Orden>()
                .Property(o => o.Total).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<OrdenDetalle>()
                .Property(od => od.PrecioUnitario).HasColumnType("decimal(10,2)");

        }
    }
}
