using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using CrudVeiculos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("corpo-doscente")]
    public class CorpoDoscenteController : ControllerBase
    {
        private readonly CorpoDoscenteService _corpoDoscenteService;

        public CorpoDoscenteController(CorpoDoscenteService corpoDoscenteService)
        {
            _corpoDoscenteService = corpoDoscenteService;
        }

        [HttpPost]
        public async Task<ActionResult<CorpoDoscente>> Add([FromBody] CorpoDoscenteCreateDTO dto)
        {
            var corpo = await _corpoDoscenteService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = corpo.Id }, corpo);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorpoDoscente>>> GetAll()
        {
            return Ok(await _corpoDoscenteService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CorpoDoscente>> GetById(int id)
        {
            var corpo = await _corpoDoscenteService.GetById(id);
            if (corpo == null) return NotFound();

            return Ok(corpo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _corpoDoscenteService.Delete(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
