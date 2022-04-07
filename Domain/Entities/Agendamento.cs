using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Agendamento", Schema = "dbo")]
    public class Agendamento
    {
        public long Id { get; set; }
        public long TipoAtendimentoId { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }
        public long AssociadoId { get; set; }
        public Associado Associado { get; set; }
        public long ConveniadoId { get; set; }
        public Conveniado Conveniado { get; set; }
        public long EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataAtendimento { get; set; }
        public DateTime? DataAgendamento { get; set; }

    }
}
