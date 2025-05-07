using System.ComponentModel.DataAnnotations;

namespace GestaoAcademica.DTOs
{
    public class ServidorCreateDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "CPF inválido")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression("Administrador|Professor", ErrorMessage = "Tipo inválido")]
        public required string Tipo { get; set; }

        // Relacionamentos seguindo padrão do exemplo
        public int? FkIdCorpoDocente { get; set; }
    }
}

public class ServidorUpdateDTO : ServidorCreateDTO
{
    [Required(ErrorMessage = "O ID é obrigatório")]
    public required int Id { get; set; }
}