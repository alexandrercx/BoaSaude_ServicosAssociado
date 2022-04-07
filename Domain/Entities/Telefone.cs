using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(name: "Telefone", Schema = "dbo")]
    public class Telefone
    {
        public long Id { get; set; }

        [Required]
        public long AssociadoId { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string DDI { get; set; }

        [Required]
        public string DDD { get; set; }

        [Required]
        public string TipoTelefone { get; set; }
    }
}
