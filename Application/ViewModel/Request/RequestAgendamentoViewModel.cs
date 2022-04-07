using Domain.Entities;
using Domain.Enum;
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
        public eTipoAtendimento TipoAtendimentoId { get; set; }

        /// <summary>
        /// Identificador do associado
        /// </summary>
        [DataMember(Name = "idAssociado")]
        [JsonProperty(PropertyName = "idAssociado")]
        public long AssociadoId { get; set; }

        /// <summary>
        /// Identificador do conveniado que realizará o atendimento
        /// </summary>
        [DataMember(Name = "idConveniado")]
        [JsonProperty(PropertyName = "idConveniado")]
        public long ConveniadoId { get; set; }

        /// <summary>
        /// Identificador do endereço onde será feito o atendimento
        /// </summary>
        [DataMember(Name = "idEndereco")]
        [JsonProperty(PropertyName = "idEndereco")]
        public long EnderecoId { get; set; }

        /// <summary>
        /// Data que será realizado o atendimento
        /// </summary>
        [DataMember(Name = "dataHora")]
        [JsonProperty(PropertyName = "dataHora")]
        public DateTime DataAtendimento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> retorno = new List<ValidationResult>();
            var valoresTipoAtendimento = from long n in Enum.GetValues(typeof(eTipoAtendimento)).Cast<long>() select (long)n;
            var nomesTipoAtendimento = from string n in Enum.GetNames(typeof(eTipoAtendimento)).Cast<string>() select (string)n;

            if (!new RequiredAttribute().IsValid(TipoAtendimentoId))
                retorno.Add(new ValidationResult("Atributo obrigatório.", new List<string> { nameof(TipoAtendimentoId) }));
            else if (!valoresTipoAtendimento.ToList<long>().Contains((long)TipoAtendimentoId) && !nomesTipoAtendimento.ToList<string>().Contains(TipoAtendimentoId.ToString()))
                retorno.Add(new ValidationResult("Atributo inválido.", new List<string> { nameof(TipoAtendimentoId) }));

            if (!new RequiredAttribute().IsValid(AssociadoId))
                retorno.Add(new ValidationResult("Atributo obrigatório.", new List<string> { nameof(AssociadoId) }));
            else if(AssociadoId<=0)
                retorno.Add(new ValidationResult("Atributo inválido. (Seql_Associado > 0).", new List<string> { nameof(AssociadoId) }));

            if (!new RequiredAttribute().IsValid(ConveniadoId))
                retorno.Add(new ValidationResult("Atributo obrigatório.", new List<string> { nameof(ConveniadoId) }));
            else if (ConveniadoId <= 0)
                retorno.Add(new ValidationResult("Atributo inválido. (Seql_Conveniado > 0).", new List<string> { nameof(ConveniadoId) }));

            if (!new RequiredAttribute().IsValid(EnderecoId))
                retorno.Add(new ValidationResult("Atributo obrigatório.", new List<string> { nameof(EnderecoId) }));
            else if (EnderecoId <= 0)
                retorno.Add(new ValidationResult("Atributo inválido. (Seql_Endereco > 0).", new List<string> { nameof(EnderecoId) }));

            if (!new RequiredAttribute().IsValid(DataAtendimento))
                retorno.Add(new ValidationResult("Atributo obrigatório.", new List<string> { nameof(DataAtendimento) }));
            else if (DateTime.Now.AddMinutes(30) >= DataAtendimento)
                retorno.Add(new ValidationResult("Atributo inválido. (Inst_Atendimento > DataHoraAtual + 30 minutos).", new List<string> { nameof(DataAtendimento) }));


            return retorno;
        }
    }
}
