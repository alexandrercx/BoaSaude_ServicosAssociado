using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Conveniado", Schema = "dbo")]
   public class Conveniado
   {
      public long Id { get; set; }
      public long Documento { get; set; }
      public string Nome { get; set; }
      public string DocProfissional { get; set; }
      public DateTime DataCadastro { get; set; }
      public DateTime DataAtualizacao { get; set; }
   }
}
