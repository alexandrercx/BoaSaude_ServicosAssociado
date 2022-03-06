﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Agendamento", Schema = "dbo")]
    public class Agendamento
    {
        public int Seql_Agendamento { get; set; }
        public int Cod_TipoAtendimento { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }
        public int Seql_Associado { get; set; }
        public Associado Associado { get; set; }
        public int Seql_Conveniado { get; set; }
        public Conveniado Conveniado { get; set; }
        public int Seql_Endereco { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime Inst_Atendimento { get; set; }
        public DateTime? Inst_Agendamento { get; set; }

    }
}
