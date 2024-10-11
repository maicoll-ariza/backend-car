using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculosApi.Data;
using VehiculosApi.Models;

namespace VehiculosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly VehiculosContext _context;

        public MarcasController(VehiculosContext context)
        {
            _context = context;
        }

        // GET: api/marcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            return await _context.Marcas.ToListAsync();
        }
    }
}
