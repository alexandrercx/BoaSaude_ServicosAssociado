using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class RepositoryEndereco : RepositoryGenerics<Endereco>, IServEndereco
    {
        public RepositoryEndereco(Contexto context)
        {
            SetContext(context);
        }
    }
}
