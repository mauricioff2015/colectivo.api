using Colectivo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Colectivo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MiembrosController : ControllerBase
    {
        private readonly ColectivoDbContext _context;
        public MiembrosController(ColectivoDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Miembro>>> GetAll() => await _context.Miembros.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Miembro>> Get(int id)
        {
            var miembro = await _context.Miembros.FindAsync(id);
            return miembro == null ? NotFound() : Ok(miembro);
        }

        [HttpPost]
        public async Task<ActionResult<Miembro>> Create(Miembro miembro)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            miembro.FechaRegistro = DateTime.UtcNow;
            _context.Miembros.Add(miembro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = miembro.Id }, miembro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Miembro miembro)
        {
            if (id != miembro.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Entry(miembro).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Miembros.Any(e => e.Id == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var miembro = await _context.Miembros.FindAsync(id);
            if (miembro == null) return NotFound();
            _context.Miembros.Remove(miembro);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Miembro>>> Search(
            [FromQuery] string territorio,
            [FromQuery] string? query = null,
            [FromQuery] string? sector = null,
            [FromQuery] bool? trabajoMesas = null,
            [FromQuery] bool? empleado = null,
            [FromQuery] bool? trabajaraMesaGenerales2025 = null)
        {
            if (string.IsNullOrWhiteSpace(territorio))
                return BadRequest("El parámetro 'territorio' es obligatorio.");
            var q = _context.Miembros.AsQueryable();
            q = q.Where(m => m.Territorio == territorio);
            if (!string.IsNullOrWhiteSpace(query))
                q = q.Where(m => m.Nombre.Contains(query) || m.Dni.Contains(query) || (m.ProfesionOficio ?? "").Contains(query));
            if (!string.IsNullOrWhiteSpace(sector))
                q = q.Where(m => m.Sector == sector);
            if (trabajoMesas.HasValue)
                q = q.Where(m => m.TrabajoMesas == trabajoMesas);
            if (empleado.HasValue)
                q = q.Where(m => m.Empleado == empleado);
            if (trabajaraMesaGenerales2025.HasValue)
                q = q.Where(m => m.TrabajaraMesaGenerales2025 == trabajaraMesaGenerales2025);
            var result = await q.ToListAsync();
            return Ok(result);
        }
    }
}
