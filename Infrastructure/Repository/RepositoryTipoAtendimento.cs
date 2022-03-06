using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class RepositoryTipoAtendimento : RepositoryGenerics<TipoAtendimento>, IServTipoAtendimento
    {
        private readonly Contexto _Context;
        public RepositoryTipoAtendimento(Contexto context)
        {
            _Context = context;
            SetContext(context);
        }
    }
}
