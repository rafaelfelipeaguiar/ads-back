using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudVeiculos.Entities
{
    [Table("CorpoDoscente")]
    public class CorpoDoscente
    {
        [Key]
        public int Id { get; set; }

        // Lista de FKs para Servidor
        public List<int> ServidorIds { get; set; } = new();

        // Navegação para os Servidores
        [ForeignKey("ServidorIds")]
        public List<Servidor> Servidores { get; set; } = new();
    }
}