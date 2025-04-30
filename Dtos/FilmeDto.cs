using System.ComponentModel.DataAnnotations;

namespace ApiAds.Dtos
{
    public class FilmeDto
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Genero { get; set; }
        
        [Required]
        public required DateTime AnoLancamento { get; set; }
    }
}
