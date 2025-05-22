using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudVeiculos.Entities
{
    [Table("CorpoDoscente")]
    public class CorpoDoscente
    {
        [Key]
        public int Id { get; set; }

        public required string Disciplina { get; set; }

        [ForeignKey(nameof(Servidor))]
        public int ServidorId { get; set; }

        public Servidor Servidor { get; set; }
    }
}