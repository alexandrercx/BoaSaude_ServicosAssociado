using Application.ViewModel.Request;
using Application.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAgendamentoAppService
    {
        Task<ResponseAgendamentoViewModel> Add(RequestAgendamentoViewModel atendimento);
        Task<ResponseAgendamentoViewModel> Get(long id);
        Task<List<ResponseAgendamentoViewModel>> List(long idAssociado);
        Task<bool> AssociadoAtivo(long id);
        Task<bool> ConveniadoLivre(long id, DateTime dataAtendimento);
    }
}
