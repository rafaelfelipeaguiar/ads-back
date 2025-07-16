using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ads.DTOs
{
    public class MatrizCurricularUpdateDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Ano é obrigatório")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Informe ao menos uma disciplina")]
        public List<int> DisciplinaIds { get; set; }
            = new List<int>();
    }
}
