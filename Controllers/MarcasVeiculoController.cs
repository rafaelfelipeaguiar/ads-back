using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("api/marcas")]
    public class MarcasVeiculo : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MarcasVeiculo(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/marcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaVeiculo>>> GetAll()
        {
            var marcas = await _context.MarcasVeiculo
            .ToListAsync();

            return Ok(marcas);
        }
    }
}
