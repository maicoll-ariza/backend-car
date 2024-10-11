using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculosApi.Data;
using VehiculosApi.Models;


namespace VehiculosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly VehiculosContext _context;

        public VehiculosController(VehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
        {
            return await _context.Vehiculos.Include(v => v.Marca).Include(v => v.Color).ToListAsync();
        }

        // GET: api/Vehiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos
                .Include(v => v.Marca)
                .Include(v => v.Color)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo;
        }

        // POST: api/Vehiculos
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
            // Validaciones
            if (string.IsNullOrEmpty(vehiculo.Modelo) || vehiculo.Modelo.Length < 3)
            {
                return BadRequest("El modelo del vehículo debe tener al menos 3 caracteres.");
            }

            if (!_context.Marcas.Any(m => m.Id == vehiculo.MarcaId))
            {
                return BadRequest("La marca seleccionada no es válida.");
            }

            if (!_context.Colores.Any(c => c.Id == vehiculo.ColorId))
            {
                return BadRequest("El color seleccionado no es válido.");
            }

            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();

            // Opcionalmente, incluir el objeto completo con las relaciones de Marca y Color
            await _context.Entry(vehiculo).Reference(v => v.Marca).LoadAsync();
            await _context.Entry(vehiculo).Reference(v => v.Color).LoadAsync();

            return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.Id }, vehiculo);
        }


        // PUT: api/Vehiculos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return BadRequest("El ID del vehículo no coincide.");
            }

            // Validaciones
            if (string.IsNullOrEmpty(vehiculo.Modelo) || vehiculo.Modelo.Length < 3)
            {
                return BadRequest("El modelo del vehículo debe tener al menos 3 caracteres.");
            }

            if (!_context.Marcas.Any(m => m.Id == vehiculo.MarcaId))
            {
                return BadRequest("La marca seleccionada no es válida.");
            }

            if (!_context.Colores.Any(c => c.Id == vehiculo.ColorId))
            {
                return BadRequest("El color seleccionado no es válido.");
            }

            _context.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Vehiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
