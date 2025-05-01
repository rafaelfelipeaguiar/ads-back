using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("api/cores")]
    public class CoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/cores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cor>>> GetAll()
        {
            var cores = await _context.Cores
            .ToListAsync();

            return Ok(cores);
        }
    }
}
