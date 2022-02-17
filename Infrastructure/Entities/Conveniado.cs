using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Entities
{
   [Table("Conveniado", Schema = "dbo")]
   public class Conveniado
   {
      public int Seql_Conveniado { get; set; }
      public long Num_Documento { get; set; }
      public string Nom_Conveniado { get; set; }
      public string Num_DocProfissional { get; set; }
      public DateTime Inst_Cadastro { get; set; }
      public DateTime Inst_Atualização { get; set; }
   }
}
