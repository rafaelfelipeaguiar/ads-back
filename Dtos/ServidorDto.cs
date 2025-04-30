using System.ComponentModel.DataAnnotations;

namespace ApiAds.Dtos
{
    public class ServidorDto
    {
        [Required]
        public required string Nome { get; set; }
    }
}
