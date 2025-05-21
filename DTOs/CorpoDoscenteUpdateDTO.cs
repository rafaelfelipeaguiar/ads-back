using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudVeiculos.DTOs
{
    public class CorpoDoscenteUpdateDTO : IValidatableObject
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Deve haver pelo menos um Servidor associado.")]
        public List<int> ServidorIds { get; set; } = new();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ServidorIds == null || ServidorIds.Count == 0)
            {
                yield return new ValidationResult(
                    "Deve haver pelo menos um Servidor associado.",
                    new[] { nameof(ServidorIds) }
                );
            }
        }
    }
}
