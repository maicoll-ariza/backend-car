namespace VehiculosApi.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public required  string Modelo { get; set; }
        public int Anio { get; set; }

        public int ColorId { get; set; }
        public Color? Color { get; set; }

        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }
    }
}
