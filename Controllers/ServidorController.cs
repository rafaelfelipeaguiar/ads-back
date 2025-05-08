using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("servidor")]
    public class ServidorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServidorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Servidor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servidor>>> GetAll()
        {
            var servidor = await _context.Servidor
            .ToListAsync();

            return Ok(servidor);
        }

        // GET: api/Servidor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servidor>> GetById(int id)
        {
            var servidor = await _context.Servidor.FindAsync(id);

            if (servidor == null)
            {
                return NotFound();
            }

            return Ok(servidor);
        }

        // POST: api/Servidor
        [HttpPost]
        public async Task<ActionResult<Servidor>> Add([FromBody] ServidorCreateDTO servidorDTO)
        {
           
            var servidor = new Servidor
            {
                Nome = servidorDTO.Nome,
                Cpf = servidorDTO.Cpf,
                Email = servidorDTO.Email,
                Senha = servidorDTO.Senha,
                Tipo = servidorDTO.Tipo
            };

            _context.Servidor.Add(servidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = servidor.IdServidor }, servidor);
        }

        // DELETE: api/Servidor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var servidor = await _context.Servidor.FindAsync(id);
            if (servidor == null)
            {
                return NotFound();
            }

            _context.Servidor.Remove(servidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}