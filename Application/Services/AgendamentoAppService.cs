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
            ResponseAgendamentoViewModel response = null;

            await _Agendamento.Add(request);

            if (request.Id > 0)
            {
                response = await Get(request.Id);
            }

            return response;
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
