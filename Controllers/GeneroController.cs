
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;

namespace ApiLocadora.Controllers
{
    [Route("Genero")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private static List<Genero> listaGeneros = [
            new Genero() {
                Nome = "Ação"
            },
            new Genero
            {
                Nome = "Comédia"
            },
            new Genero
            {
                Nome = "Drama"
            }
        ];

        [HttpGet]
        public IActionResult Buscar()
        {
            return Ok(listaGeneros);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] GeneroDto item)
        {
            var genero = new Genero();
            genero.Nome = item.Nome;

            listaGeneros.Add(genero);

            return Ok(genero);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] GeneroDto item)
        {
            var generoExistente = listaGeneros.FirstOrDefault(f => f.Id == id);

            if (generoExistente == null)
            {
                return NotFound("Gênero não encontrado.");
            }
            generoExistente.Nome = item.Nome;

            return Ok(generoExistente);
        }


        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            var generoExistente = listaGeneros.FirstOrDefault(f => f.Id == id);

            if (generoExistente == null)
            {
                return NotFound("Gênero não encontrado.");
            }

            listaGeneros.Remove(generoExistente);

            return Ok();
        }


    }
}
