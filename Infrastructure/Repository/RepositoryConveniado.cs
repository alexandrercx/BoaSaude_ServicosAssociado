using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
   public class RepositoryConveniado : RepositoryGenerics<Conveniado>, IConveniado
   {
      public RepositoryConveniado(Contexto context)
      {
         base.SetContext(context);
      }
   }
}
