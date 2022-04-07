using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(name: "Endereco", Schema = "dbo")]
    public class Endereco
    {

        public long Id { get; set; }

        public eTipoEndereco TipoEndereco { get; set; }

        public long AssociadoId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string CEP { get; set; }

        public string UF { get; set; }

        public string Complemento { get; set; }

        public string Pais { get; set; }
    }
}
