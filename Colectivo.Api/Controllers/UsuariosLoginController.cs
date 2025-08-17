using Colectivo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Colectivo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosLoginController : ControllerBase
    {
        private readonly ColectivoDbContext _context;
        public UsuariosLoginController(ColectivoDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioLogin>>> GetAll() => await _context.UsuariosLogin.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioLogin>> Get(int id)
        {
            var usuario = await _context.UsuariosLogin.FindAsync(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioLogin>> Create(UsuarioLogin usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.UsuariosLogin.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UsuarioLogin usuario)
        {
            if (id != usuario.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Entry(usuario).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.UsuariosLogin.Any(e => e.Id == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.UsuariosLogin.FindAsync(id);
            if (usuario == null) return NotFound();
            _context.UsuariosLogin.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
