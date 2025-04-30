using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAds.Models
{
    [Table("servidores")]
    public class Servidor
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
