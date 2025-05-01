using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudVeiculos.Entities
{     
    [Table("Cores")]
    public class Cor
    {
        [Key]
        public int IdCor { get; set; }
        public required string NomeCor { get; set; }
    }
}
