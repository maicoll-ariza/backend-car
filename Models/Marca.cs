namespace VehiculosApi.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }

        // public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}
