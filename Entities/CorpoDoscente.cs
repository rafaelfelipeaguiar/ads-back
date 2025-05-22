/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudVeiculos.Entities
{
    [Table("CorpoDoscente")]
    public class CorpoDoscente
    {
        [Key]
        public int Id { get; set; }

        public int ServidorId { get; set; }

        [ForeignKey("ServidorId")]
        public required Servidor Servidor { get; set; }

        public required string Disciplina { get; set; }
    }
}*/