using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("TipoAtendimento", Schema = "dbo")]
    public class TipoAtendimento
    {
        public int Cod_TipoAtendimento { get; set; }
        public string Nom_TipoAtendimento { get; set; }
    }
}
