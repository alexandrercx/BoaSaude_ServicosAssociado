using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Response
{
    public class ResponseConveniadoViewModel
    {
        public long Id { get; set; }
        public long Documento { get; set; }
        public string Nome { get; set; }
        public string DocProfissional { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
