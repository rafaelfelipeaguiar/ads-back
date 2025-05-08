using System.ComponentModel.DataAnnotations;

namespace CrudVeiculos.DTOs
{
    public class ServidorUpdateDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdServidor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O campo {0} deve conter 11 dígitos")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} deve ser um endereço de email válido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(6, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public required string Tipo { get; set; }
    }
}