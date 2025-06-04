using CrudVeiculos.Data;
using CrudVeiculos.Entities;
using CrudVeiculos.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("corpo-doscente")]
    public class CorpoDocenteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CorpoDocenteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorpoDocente>>> GetAll()
        {
            var list = await _context.CorpoDocente
                .Include(cd => cd.Servidor)
                .ToListAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CorpoDocente>> GetById(int id)
        {
            var corpo = await _context.CorpoDocente
                .Include(cd => cd.Servidor)
                .FirstOrDefaultAsync(cd => cd.Id == id);

            if (corpo == null)
                return NotFound();

            return Ok(corpo);
        }

        [HttpPost]
        public async Task<ActionResult<CorpoDocente>> Add([FromBody] CorpoDocenteCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _context.CorpoDocente
              .AnyAsync(c => c.ServidorId == dto.ServidorId))
                return Conflict("Servidor já possui registro em CorpoDocente.");

            // Verifica se o servidor existe
            var servidor = await _context.Servidor.FindAsync(dto.ServidorId);
            if (servidor == null)
                return BadRequest($"Servidor com Id {dto.ServidorId} não encontrado.");

            // Mapeia DTO para entidade
            var corpo = new CorpoDocente
            {
                ServidorId = dto.ServidorId,
                Disciplina = dto.Disciplina
            };

            _context.CorpoDocente.Add(corpo);
            await _context.SaveChangesAsync();

            // Carrega a navegação para retornar no CreatedAtAction
            await _context.Entry(corpo).Reference(c => c.Servidor).LoadAsync();

            return CreatedAtAction(nameof(GetById), new { id = corpo.Id }, corpo);
        }

        // DELETE: corpo-doscente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var corpo = await _context.CorpoDocente.FindAsync(id);
            if (corpo == null)
                return NotFound();

            _context.CorpoDocente.Remove(corpo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}