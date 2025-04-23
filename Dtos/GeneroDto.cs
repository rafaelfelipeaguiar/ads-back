using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Dtos
{
    public class GeneroDto
    {
        //nome do gênero
        [Required]
        public string Nome { get; set; }
    }
}
