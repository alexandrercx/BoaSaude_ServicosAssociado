using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
   public interface IServAgendamento : IServGenerics<Agendamento>
   {
        Task<bool> AssociadoAtivo(long id);
        Task<bool> ConveniadoLivre(long id, DateTime dataAtendimento);
    }
}
