using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculosApi.Data;
using VehiculosApi.Models;

namespace VehiculosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoresController : ControllerBase
    {
        private readonly VehiculosContext _context;

        public ColoresController(VehiculosContext context)
        {
            _context = context;
        }

        // GET: api/colores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> GetColores()
        {
            return await _context.Colores.ToListAsync();
        }
    }
}
