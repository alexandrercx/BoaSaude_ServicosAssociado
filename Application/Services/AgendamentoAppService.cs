using Application.Interface;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AgendamentoAppService : Base, IAgendamentoAppService
    {
        private readonly IMapper _Mapper;
        private readonly IServAgendamento _Agendamento;

        public AgendamentoAppService(IMapper Mapper, IServAgendamento IAgendamento)
        {
            _Mapper = Mapper;
            _Agendamento = IAgendamento;
        }

        public async Task<ResponseAgendamentoViewModel> Add(RequestAgendamentoViewModel agendamento)
        {
            var request = _Mapper.Map<Agendamento>(agendamento);
            ResponseAgendamentoViewModel response = new ResponseAgendamentoViewModel();

            if (!await _Agendamento.AssociadoAtivo(agendamento.AssociadoId))
            {
                response.Relatorio.CodigoHttp = 207;
                response.Relatorio.Status = "invalido";
                response.Relatorio.Detalhes.Add(new ResponseDetalheRelatorioViewModel()
                {
                    Atributo = nameof(agendamento.AssociadoId),
                    Mensagem = "Associado não está ativo."
                });
            }

            if (!await _Agendamento.ConveniadoLivre(agendamento.ConveniadoId, agendamento.DataAtendimento))
            {
                response.Relatorio.CodigoHttp = 207;
                response.Relatorio.Status = "invalido";
                response.Relatorio.Detalhes.Add(new ResponseDetalheRelatorioViewModel()
                {
                    Atributo = nameof(agendamento.ConveniadoId),
                    Mensagem = "Conveniado não está disponível nessa data/hora."
                });
            }

            if (response.Relatorio.Status == null)
            {
                await _Agendamento.Add(request);

                if (request.Id > 0)
                {
                    response.Relatorio.CodigoHttp = 200;
                    response = await Get(request.Id);
                }
            }

            return response;
        }

        public async Task<bool> AssociadoAtivo(long id)
        {
            return await _Agendamento.AssociadoAtivo(id);
        }

        public async Task<bool> ConveniadoLivre(long id, DateTime dataAtendimento)
        {
            return await _Agendamento.ConveniadoLivre(id, dataAtendimento);
        }

        public async Task<ResponseAgendamentoViewModel> Get(long id)
        {
            var result = await _Agendamento.Get(id);
            var response = _Mapper.Map<ResponseAgendamentoViewModel>(result);
            return response;
        }

        public async Task<List<ResponseAgendamentoViewModel>> List(long idAssociado)
        {
            var result = await _Agendamento.List(a => a.AssociadoId == idAssociado);
            var response = _Mapper.Map<List<ResponseAgendamentoViewModel>>(result);
            return response;
        }
    }
}
