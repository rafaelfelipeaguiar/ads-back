using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestaoAcademica.Entities
{ 
    [Table("Servidores")]
    public class Servidor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string Nome { get; set; }  
        
        public required string Cpf { get; set; }
        
        public required string Email { get; set; }
        
        [JsonIgnore]
        public required string Senha { get; set; }
        
        public required string Tipo { get; set; } // "Administrador" ou "Professor"
        
        [ForeignKey("FkIdCorpoDocente")]
        public virtual CorpoDocente? CorpoDocente { get; set; }

        // Relacionamentos mantendo a nomenclatura do exemplo
        [ForeignKey("FkIdTcc1")]
        public virtual ICollection<Tcc1>? TccsOrientados { get; set; }
        
        [ForeignKey("FkIdEvento")]
        public virtual ICollection<Evento>? EventosResponsavel { get; set; }
        
        [ForeignKey("FkIdDocumento")]
        public virtual ICollection<Documento>? DocumentosEnviados { get; set; }
    }
}