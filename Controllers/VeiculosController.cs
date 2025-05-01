using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("api/veiculos")]
    public class VeiculosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VeiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Veiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetAll()
        {
            var veiculos = await _context.Veiculos
            .ToListAsync();

            return Ok(veiculos);
        }

        // GET: api/Veiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetById(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }

        // POST: api/Veiculos
        [HttpPost]
        public async Task<ActionResult<Veiculo>> Add([FromBody] VeiculoCreateDTO veiculoDTO)
        {
            // Primeiro, recupere as entidades relacionadas do banco de dados
            var marcaVeiculo = await _context.MarcasVeiculo.FindAsync(veiculoDTO.IdMarca);

            if (marcaVeiculo == null)
            {
                return BadRequest("Marca não encontrada");
            }

            var cor = await _context.Cores.FindAsync(veiculoDTO.IdCor);

            if (cor == null)
            {
                return BadRequest("Cor não encontrada");
            }

            var veiculo = new Veiculo
            {
                Placa = veiculoDTO.Placa,
                AnoFabricacaoModelo = veiculoDTO.AnoFabricacaoModelo,
                Modelo = veiculoDTO.Modelo,
                Chassis = veiculoDTO.Chassis,
                RenavamVeiculo = veiculoDTO.RenavamVeiculo,
                MarcaVeiculo = marcaVeiculo,
                Cor = cor
            };

            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = veiculo.IdVeiculo }, veiculo);
        }

        // Patch: api/Veiculos/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VeiculoUpdateDTO veiculoDTO)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(veiculoDTO.Placa))
            {
                veiculo.Placa = veiculoDTO.Placa;
            }

            if (!string.IsNullOrEmpty(veiculoDTO.AnoFabricacaoModelo))
            {
                veiculo.AnoFabricacaoModelo = veiculoDTO.AnoFabricacaoModelo;
            }

            if (!string.IsNullOrEmpty(veiculoDTO.Modelo))
            {
                veiculo.Modelo = veiculoDTO.Modelo;
            }

            if (!string.IsNullOrEmpty(veiculoDTO.Chassis))
            {
                veiculo.Chassis = veiculoDTO.Chassis;
            }

            if (!string.IsNullOrEmpty(veiculoDTO.RenavamVeiculo))
            {
                veiculo.RenavamVeiculo = veiculoDTO.RenavamVeiculo;
            }

            if (veiculoDTO.IdMarca.HasValue)
            {
                var marcaVeiculo = await _context.MarcasVeiculo.FindAsync(veiculoDTO.IdMarca.Value);

                if (marcaVeiculo == null)
                {
                    return BadRequest("Marca não encontrada");
                }

                veiculo.MarcaVeiculo = marcaVeiculo;
            }

            if (veiculoDTO.IdCor.HasValue)
            {
                var cor = await _context.Cores.FindAsync(veiculoDTO.IdCor.Value);

                if (cor == null)
                {
                    return BadRequest("Cor não encontrada");
                }

                veiculo.Cor = cor;
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = veiculo.IdVeiculo }, veiculo);
        }

        // DELETE: api/Veiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
