using Microsoft.EntityFrameworkCore;
using VehiculosApi.Models;

namespace VehiculosApi.Data
{
    public class VehiculosContext : DbContext
    {
        public VehiculosContext(DbContextOptions<VehiculosContext> options) : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Nombre = "Rojo" },
                new Color { Id = 2, Nombre = "Azul" },
                new Color { Id = 3, Nombre = "Negro" },
                new Color { Id = 4, Nombre = "Blanco" },
                new Color { Id = 5, Nombre = "Gris" }
            );

            modelBuilder.Entity<Marca>().HasData(
                new Marca { Id = 1, Nombre = "Toyota" },
                new Marca { Id = 2, Nombre = "Ford" },
                new Marca { Id = 3, Nombre = "Chevrolet" },
                new Marca { Id = 4, Nombre = "Honda" },
                new Marca { Id = 5, Nombre = "BMW" },
                new Marca { Id = 6, Nombre = "Audi" }
            );
        }
    }
}
