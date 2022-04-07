using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(name: "ContaBanco", Schema = "dbo")]
    public class ContaBanco
    {
        public long Id { get; set; }

        [Required]
        public long AssociadoId { get; set; }

        [Required]
        public int BancoId { get; set; }

        [Required]
        public string Agencia { get; set; }

        public string DigitoAgencia { get; set; }

        [Required]
        public string Conta { get; set; }

        public string DigitoConta { get; set; }

        [Required]
        public string TipoConta { get; set; }
    }
}
