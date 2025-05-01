using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CrudVeiculos.Entities
{ 
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int IdVeiculo { get; set; }

        public required string Placa { get; set; }  
        public required string AnoFabricacaoModelo { get; set; }
        public required string Modelo { get; set; }
        public required string Chassis { get; set; }
        public required string RenavamVeiculo { get; set; }
        
        [ForeignKey("FkIdMarca")]
        public virtual MarcaVeiculo? MarcaVeiculo { get; set; }

        [ForeignKey("FkIdCor")]
        public virtual Cor? Cor { get; set; }
    }
}
