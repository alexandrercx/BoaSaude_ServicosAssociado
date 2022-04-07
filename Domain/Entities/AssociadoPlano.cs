using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(name: "AssociadoPlano", Schema = "dbo")]
    public class AssociadoPlano
    {
        public long Id { get; set; }

        [Required]
        public long AssociadoId { get; set; }

        [Required]
        public long PlanoId { get; set; }

        public long PlanoFaixaEtariaId { get; set; }

        [Required]
        public Decimal ValorContratado { get; set; }

        [Required]
        public DateTime DataAtivacao { get; set; }

        public DateTime? DataInativacao { get; set; }
    }
}
