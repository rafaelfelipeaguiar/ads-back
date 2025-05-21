using CrudVeiculos.Data;
using CrudVeiculos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("corpodoscente")]
    public class CorpoDoscenteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CorpoDoscenteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: corpodoscente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorpoDoscente>>> GetAll()
        {
            var lista = await _context.CorpoDoscente
                .Include(cd => cd.Servidores)
                .ToListAsync();
            return Ok(lista);
        }

        // GET: corpodoscente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CorpoDoscente>> GetById(int id)
        {
            var corpo = await _context.CorpoDoscente
                .Include(cd => cd.Servidores)
                .FirstOrDefaultAsync(cd => cd.Id == id);

            if (corpo == null)
                return NotFound();

            return Ok(corpo);
        }

        // POST: corpodoscente
        [HttpPost]
        public async Task<ActionResult<CorpoDoscente>> Add([FromBody] CorpoDoscente corpoDTO)
        {
            // Busca os servidores pelo id
            var servidores = await _context.Servidor
                .Where(s => corpoDTO.ServidorIds.Contains(s.IdServidor))
                .ToListAsync();

            if (servidores.Count != corpoDTO.ServidorIds.Count)
                return BadRequest("Um ou mais ServidorIds são inválidos.");

            var corpo = new CorpoDoscente
            {
                ServidorIds = corpoDTO.ServidorIds,
                Servidores = servidores
            };

            _context.CorpoDoscente.Add(corpo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = corpo.Id }, corpo);
        }

        // DELETE: corpodoscente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var corpo = await _context.CorpoDoscente.FindAsync(id);
            if (corpo == null)
                return NotFound();

            _context.CorpoDoscente.Remove(corpo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}