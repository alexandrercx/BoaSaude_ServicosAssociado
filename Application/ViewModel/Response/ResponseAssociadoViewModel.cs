using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Response
{
    public class ResponseAssociadoViewModel
    {
        public int Id { get; set; }
        public long NumDocumento { get; set; }
        public string NomAssociado { get; set; }
        public string IndAtivo { get; set; }
        public DateTime InstCadastro { get; set; }
        public DateTime InstAtualizacao { get; set; }
    }
}
