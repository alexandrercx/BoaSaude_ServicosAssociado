using Application.ViewModel.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Agendamento, ResponseAgendamentoViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.DataAgendamento, map => map.MapFrom(src => src.DataAgendamento))
                .ForMember(dst => dst.DataAtendimento, map => map.MapFrom(src => src.DataAtendimento))
                //.ForMember(dst => dst.CodTipoAtendimento, map => map.MapFrom(src => src.Cod_TipoAtendimento))
             .ReverseMap();
            CreateMap<Endereco, ResponseEnderecoViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.Bairro, map => map.MapFrom(src => src.Bairro))
                .ForMember(dst => dst.Cidade, map => map.MapFrom(src => src.Cidade))
                .ForMember(dst => dst.Complemento, map => map.MapFrom(src => src.Complemento))
                .ForMember(dst => dst.Logradouro, map => map.MapFrom(src => src.Logradouro))
                .ForMember(dst => dst.Numero, map => map.MapFrom(src => src.Numero))
                .ForMember(dst => dst.Uf, map => map.MapFrom(src => src.UF))
                .ForMember(dst => dst.Cep, map => map.MapFrom(src => src.CEP))
             .ReverseMap();
            CreateMap<Associado, ResponseAssociadoViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
                //.ForMember(dst => dst.IndAtivo, map => map.MapFrom(src => src.Ind_Ativo))
                //.ForMember(dst => dst.InstAtualizacao, map => map.MapFrom(src => src.DataAtualização))
                //.ForMember(dst => dst.InstCadastro, map => map.MapFrom(src => src.DataCadastro))
                .ForMember(dst => dst.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(dst => dst.Documento, map => map.MapFrom(src => src.CPF))
             .ReverseMap();
            CreateMap<Conveniado, ResponseConveniadoViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.DataAtualizacao, map => map.MapFrom(src => src.DataAtualizacao))
                .ForMember(dst => dst.DataCadastro, map => map.MapFrom(src => src.DataCadastro))
                .ForMember(dst => dst.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(dst => dst.DocProfissional, map => map.MapFrom(src => src.DocProfissional))
                .ForMember(dst => dst.Documento, map => map.MapFrom(src => src.Documento));
            CreateMap<TipoAtendimento, ResponseTipoAtendimentoViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.Nome, map => map.MapFrom(src => src.Nome))
             .ReverseMap();

        }
    }
}
