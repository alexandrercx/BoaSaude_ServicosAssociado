﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Response
{
    public class ResponseEnderecoViewModel
    {
        public long Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}
