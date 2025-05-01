using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudVeiculos.Entities
{ 
   [Table("MarcasVeiculo")]
   public class MarcaVeiculo
    {
        [Key]
        public int IdMarca { get; set; }
        public required string NomeMarca { get; set; }
    }
}
