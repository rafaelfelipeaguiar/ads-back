
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;

namespace ApiLocadora.Controllers
{
    [Route("Estudio")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private static List<Estudio> listaEstudios = [
            new Estudio() {
                Nome = "Marvel"
            },
            new Estudio
            {
                Nome = "DC"
            },
            new Estudio
            {
                Nome = "Warner"
            }
        ];


        [HttpGet]
        public IActionResult Buscar()
        {
            return Ok(listaEstudios);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] EstudioDto item)
        {
            var estudio = new Estudio();
            estudio.Nome = item.Nome;

            listaEstudios.Add(estudio);

            return Ok(estudio);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] EstudioDto item)
        {
            var estudioExistente = listaEstudios.FirstOrDefault(f => f.Id == id);

            if (estudioExistente == null)
            {
                return NotFound("Estúdio não encontrado.");
            }
            estudioExistente.Nome = item.Nome;

            return Ok(estudioExistente);
        }


        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            var estudioExistente = listaEstudios.FirstOrDefault(f => f.Id == id);

            if (estudioExistente == null)
            {
                return NotFound("Estúdio não encontrado.");
            }

            listaEstudios.Remove(estudioExistente);

            return Ok();
        }


    }
}
