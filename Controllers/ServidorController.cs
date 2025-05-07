// Controllers/ServidoresController.cs
using GestaoAcademica.DTOs;
using GestaoAcademica.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.Controllers
{
    [ApiController]
    [Route("api/servidores")]
    public class ServidoresController : ControllerBase
    {
        private readonly IServidorService _servidorService;

        public ServidoresController(IServidorService servidorService)
        {
            _servidorService = servidorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servidores = await _servidorService.GetAll();
            return Ok(servidores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var servidor = await _servidorService.GetById(id);
            return servidor != null ? Ok(servidor) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServidorCreateDTO dto)
        {
            try
            {
                var servidor = await _servidorService.Create(dto);
                return CreatedAtAction(nameof(GetById), new { id = servidor.Id }, servidor);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServidorUpdateDTO dto)
        {
            try
            {
                var servidor = await _servidorService.Update(id, dto);
                return servidor != null ? Ok(servidor) : NotFound();
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _servidorService.Delete(id);
            return result ? NoContent() : NotFound();
        }
    }
}