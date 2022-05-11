using System.Collections.Generic;

namespace Application.ViewModel.Response
{
    public class ResponseRelatorioViewModel
    {
        public ResponseRelatorioViewModel()
        {
            Detalhes = new List<ResponseDetalheRelatorioViewModel>();
        }

        public int CodigoHttp { get; set; }

        public string Status { get; set; }

        public List<ResponseDetalheRelatorioViewModel> Detalhes { get; set; }
    }
}