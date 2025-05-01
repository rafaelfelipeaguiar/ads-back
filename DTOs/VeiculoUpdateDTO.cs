using System.ComponentModel.DataAnnotations;

namespace CrudVeiculos.DTOs
{
    public class VeiculoUpdateDTO
    {
        [StringLength(7, MinimumLength = 7, ErrorMessage = "O campo {0} deve ter {1} caracteres")]
        [RegularExpression(@"^[A-Z]{3}\d{4}$", ErrorMessage = "O campo {0} deve estar no formato AAA1234")]
        public string? Placa { get; set; }

        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "O campo {0} deve ter {1} caracteres")]
        public string? AnoFabricacaoModelo { get; set; }

        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string? Modelo { get; set; }

        [StringLength(17, MinimumLength = 17, ErrorMessage = "O campo {0} deve ter {1} caracteres")]
        public string? Chassis { get; set; }

        public string? RenavamVeiculo { get; set; }

        public int? IdMarca { get; set; }

        public int? IdCor { get; set; }
    }
}
