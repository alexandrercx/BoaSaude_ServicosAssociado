using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Response
{
    public class ResponseConveniadoViewModel
    {
        public int Id { get; set; }
        public long NumDocumento { get; set; }
        public string NomConveniado { get; set; }
        public string NumDocProfissional { get; set; }
        public DateTime InstCadastro { get; set; }
        public DateTime InstAtualização { get; set; }
    }
}
