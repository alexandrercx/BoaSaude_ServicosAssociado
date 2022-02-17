using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Entities
{
   [Table("Agendamento", Schema ="dbo")]
   public class Agendamento
   {
      public int Seql_Agendamento { get; set; }
      public TipoAtendimento Cod_TipoAtendimento { get; set; }
      public int Seql_Associado { get; set; }
      public Associado Associado { get; set; }
      public int Seql_Conveniado { get; set; }
      public Conveniado Conveniado { get; set; }
      public int Seql_Endereco { get; set; }
      public Endereco Endereco { get; set; }
      public DateTime Inst_Atendimento { get; set; }
      public DateTime Inst_Agendamento { get; set; }

   }
}
