using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
   public class RepositoryAgendamento : RepositoryGenerics<Agendamento>, IAgendamento
   {
      public RepositoryAgendamento(Contexto context)
      {
         base.SetContext(context);
      }
   }
}
