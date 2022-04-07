using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Response
{
    public class ResponseAgendamentoViewModel
    {
        public long Id { get; set; }
        public ResponseTipoAtendimentoViewModel TipoAtendimento { get; set; }
        public ResponseAssociadoViewModel Associado { get; set; }
        public ResponseConveniadoViewModel Conveniado { get; set; }
        public ResponseEnderecoViewModel Endereco { get; set; }
        public DateTime DataAtendimento { get; set; }
        public DateTime? DataAgendamento { get; set; }
    }
}
