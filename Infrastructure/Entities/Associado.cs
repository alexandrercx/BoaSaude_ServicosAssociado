using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Entities
{
   [Table("Associado", Schema = "dbo")]
   public class Associado
   {
      public int Seql_Associado { get; set; }
      public long Num_Documento { get; set; }
      public string Nom_Associado { get; set; }
      public bool Ind_Ativo { get; set; }
      public DateTime Inst_Cadastro { get; set; }
      public DateTime Inst_Atualização { get; set; }
   }
}
