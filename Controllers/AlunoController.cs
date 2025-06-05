using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using CrudVeiculos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAll()
        {
            return Ok(await _alunoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servidor>> GetById(int id)
        {
            var servidor = await _servidorService.GetById(id);
            if (servidor == null) return NotFound();

            return Ok(servidor);
        }

        [HttpPost]
        public async Task<ActionResult<Servidor>> Add([FromBody] ServidorCreateDTO dto)
        {
            var servidor = await _servidorService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = servidor.IdServidor }, servidor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServidorUpdateDTO dto)
        {
            var updated = await _servidorService.Update(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _servidorService.Delete(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
