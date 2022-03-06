using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Response
{
    public class ResponseEnderecoViewModel
    {
        public int Id { get; set; }
        public int NumCep { get; set; }
        public string NomEndereco { get; set; }
        public string NomNumero { get; set; }
        public string NomComplemento { get; set; }
        public string NomBairro { get; set; }
        public string NomCidade { get; set; }
        public string NomUf { get; set; }
    }
}
