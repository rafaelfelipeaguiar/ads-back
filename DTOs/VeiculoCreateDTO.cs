using System.ComponentModel.DataAnnotations;

namespace CrudVeiculos.DTOs
{
    public class VeiculoCreateDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "O campo {0} deve ter {1} caracteres")]
        [RegularExpression(@"^[A-Z]{3}\d{4}$", ErrorMessage = "O campo {0} deve estar no formato AAA1234")]
        public required string Placa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "O campo {0} deve ter {1} caracteres")]
        public required string AnoFabricacaoModelo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public required string Modelo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "O campo {0} deve ter {1} caracteres")]
        public required string Chassis { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public required string RenavamVeiculo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public required int IdMarca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public required int IdCor { get; set; }
    }
}
