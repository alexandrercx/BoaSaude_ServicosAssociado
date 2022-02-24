using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
   public class RepositoryEndereco : RepositoryGenerics<Endereco>, IEndereco
   {
      public RepositoryEndereco(Contexto context)
      {
         base.SetContext(context);
      }
   }
}
