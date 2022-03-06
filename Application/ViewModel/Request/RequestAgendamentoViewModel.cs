using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Application.ViewModel.Request
{
    [DataContract]
    public class RequestAgendamentoViewModel : IValidatableObject
    {
        /// <summary>
        /// Tipo de atendimento
        /// </summary>
        [DataMember(Name = "tipoAtendimento")]
        [JsonProperty(PropertyName = "tipoAtendimento")]
        public eTipoAtendimento CodTipoAtendimento { get; set; }

        /// <summary>
        /// Identificador do associado
        /// </summary>
        [DataMember(Name = "idAssociado")]
        [JsonProperty(PropertyName = "idAssociado")]
        public int SeqlAssociado { get; set; }

        /// <summary>
        /// Identificador do conveniado que realizará o atendimento
        /// </summary>
        [DataMember(Name = "idConveniado")]
        [JsonProperty(PropertyName = "idConveniado")]
        public int SeqlConveniado { get; set; }

        /// <summary>
        /// Identificador do endereço onde será feito o atendimento
        /// </summary>
        [DataMember(Name = "idEndereco")]
        [JsonProperty(PropertyName = "idEndereco")]
        public int SeqlEndereco { get; set; }

        /// <summary>
        /// Data que será realizado o atendimento
        /// </summary>
        [DataMember(Name = "dataHora")]
        [JsonProperty(PropertyName = "dataHora")]
        public DateTime InstAtendimento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> retorno = new List<ValidationResult>();
            var valoresTipoAtendimento = from int n in Enum.GetValues(typeof(eTipoAtendimento)).Cast<int>() select (int)n;
            var nomesTipoAtendimento = from string n in Enum.GetNames(typeof(eTipoAtendimento)).Cast<string>() select (string)n;

            if (!new RequiredAttribute().IsValid(CodTipoAtendimento))
                retorno.Add(new ValidationResult("Atributo obrigatório.", new List<string> { nameof(CodTipoAtendimento) }));
            else if (!valoresTipoAtendimento.ToList<int>().Contains((int)CodTipoAtendimento) && !nomesTipoAtendimento.ToList<string>().Contains(CodTipoAtendimento.ToString()))
                retorno.Add(new ValidationResult("Atributo inválido.", new List<string> { nameof(CodTipoAtendimento) }));

            if (!new RequiredAttribute().IsValid(SeqlAssociado))
                retorno.Add(new ValidationResult("Atributo obrigatório.", new List<string> { nameof(SeqlAssociado) }));
            else if(SeqlAssociado<=0)
                retorno.Add(new ValidationResult("Atributo inválido. (Seql_Associado > 0).", new List<string> { nameof(SeqlAssociado) }));

            if (!new RequiredAttribute().IsValid(SeqlConveniado))
                retorno.Add(new ValidationResult("Atributo obrigatório.", new List<string> { nameof(SeqlConveniado) }));
            else if (SeqlConveniado <= 0)
                retorno.Add(new ValidationResult("Atributo inválido. (Seql_Conveniado > 0).", new List<string> { nameof(SeqlConveniado) }));

            if (!new RequiredAttribute().IsValid(SeqlEndereco))
                retorno.Add(new ValidationResult("Atributo obrigatório.", new List<string> { nameof(SeqlEndereco) }));
            else if (SeqlEndereco <= 0)
                retorno.Add(new ValidationResult("Atributo inválido. (Seql_Endereco > 0).", new List<string> { nameof(SeqlEndereco) }));

            if (!new RequiredAttribute().IsValid(InstAtendimento))
                retorno.Add(new ValidationResult("Atributo obrigatório.", new List<string> { nameof(InstAtendimento) }));
            else if (DateTime.Now.AddMinutes(30) >= InstAtendimento)
                retorno.Add(new ValidationResult("Atributo inválido. (Inst_Atendimento > DataHoraAtual + 30 minutos).", new List<string> { nameof(InstAtendimento) }));


            return retorno;
        }
    }
}
