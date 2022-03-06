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
                .ForMember(dst => dst.SeqlAgendamento, map => map.MapFrom(src => src.Seql_Agendamento))
                .ForMember(dst => dst.InstAgendamento, map => map.MapFrom(src => src.Inst_Agendamento))
                .ForMember(dst => dst.InstAtendimento, map => map.MapFrom(src => src.Inst_Atendimento))
                //.ForMember(dst => dst.CodTipoAtendimento, map => map.MapFrom(src => src.Cod_TipoAtendimento))
             .ReverseMap();
            CreateMap<Endereco, ResponseEnderecoViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Seql_Endereco))
                .ForMember(dst => dst.NomBairro, map => map.MapFrom(src => src.Nom_Bairro))
                .ForMember(dst => dst.NomCidade, map => map.MapFrom(src => src.Nom_Cidade))
                .ForMember(dst => dst.NomComplemento, map => map.MapFrom(src => src.Nom_Complemento))
                .ForMember(dst => dst.NomEndereco, map => map.MapFrom(src => src.Nom_Endereco))
                .ForMember(dst => dst.NomNumero, map => map.MapFrom(src => src.Nom_Numero))
                .ForMember(dst => dst.NomUf, map => map.MapFrom(src => src.Nom_Uf))
                .ForMember(dst => dst.NumCep, map => map.MapFrom(src => src.Num_Cep))
             .ReverseMap();
            CreateMap<Associado, ResponseAssociadoViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Seql_Associado))
                .ForMember(dst => dst.IndAtivo, map => map.MapFrom(src => src.Ind_Ativo))
                .ForMember(dst => dst.InstAtualizacao, map => map.MapFrom(src => src.Inst_Atualização))
                .ForMember(dst => dst.InstCadastro, map => map.MapFrom(src => src.Inst_Cadastro))
                .ForMember(dst => dst.NomAssociado, map => map.MapFrom(src => src.Nom_Associado))
                .ForMember(dst => dst.NumDocumento, map => map.MapFrom(src => src.Num_Documento))
             .ReverseMap();
            CreateMap<Conveniado, ResponseConveniadoViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Seql_Conveniado))
                .ForMember(dst => dst.InstAtualização, map => map.MapFrom(src => src.Inst_Atualização))
                .ForMember(dst => dst.InstCadastro, map => map.MapFrom(src => src.Inst_Cadastro))
                .ForMember(dst => dst.NomConveniado, map => map.MapFrom(src => src.Nom_Conveniado))
                .ForMember(dst => dst.NumDocProfissional, map => map.MapFrom(src => src.Num_DocProfissional))
                .ForMember(dst => dst.NumDocumento, map => map.MapFrom(src => src.Num_Documento));
            CreateMap<TipoAtendimento, ResponseTipoAtendimentoViewModel>()
                .ForMember(dst => dst.CodTipoAtendimento, map => map.MapFrom(src => src.Cod_TipoAtendimento))
                .ForMember(dst => dst.NomTipoAtendimento, map => map.MapFrom(src => src.Nom_TipoAtendimento))
             .ReverseMap();

        }
    }
}
