using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Entities
{
   [Table("Endereco", Schema = "dbo")]
   public class Endereco
   {
      public int Seql_Endereco { get; set; }
      public int Num_Cep { get; set; }
      public string Nom_Endereco { get; set; }
      public string Nom_Numero { get; set; }
      public string Nom_Complemento { get; set; }
      public string Nom_Bairro { get; set; }
      public string Nom_Cidade { get; set; }
      public string Nom_Uf { get; set; }
   }
}
