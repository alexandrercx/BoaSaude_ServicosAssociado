using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TipoAtendimento", Schema = "dbo")]
    public class TipoAtendimento
    {
        public long Id { get; set; }
        public string Nome { get; set; }
    }
}
