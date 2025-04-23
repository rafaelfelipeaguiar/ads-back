using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Dtos
{
    public class EstudioDto
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Distribuidor { get; set; }
    }
}