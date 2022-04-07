using Newtonsoft.Json;

namespace Application.ViewModel.Request
{
    public class PostServicosAssociadoViewModel
    {

        [JsonProperty("ServicosAssociado_id")]
        public long Id { get; set; }


        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
