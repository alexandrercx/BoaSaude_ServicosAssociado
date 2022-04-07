using System;

namespace Application.ViewModel.Response
{
    public class ResponseAssociadoViewModel
    {
        public long Id { get; set; }
        public long Documento { get; set; }
        public string Nome { get; set; }
        public string Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
