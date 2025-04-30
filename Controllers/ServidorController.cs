using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiAds.Dtos;
using ApiAds.Models;
using ApiAds.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace ApiAds.Controllers
{
    [Route("servidor")]
    [ApiController]
    public class ServidorController : ControllerBase
    {
        private readonly AppDbContext _context;

      /*  public ServidorController(AppDbContext context)
        {
            _context = context;
        }*/

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {

            //var listaServidor = await _context.Servidor.ToListAsync();

            return Ok(new
            {
                    nome = "Servidor 1"
            });
        }

    }
}
