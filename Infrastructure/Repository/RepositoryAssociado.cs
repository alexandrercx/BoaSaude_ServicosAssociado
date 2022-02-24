using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
   public class RepositoryAssociado : RepositoryGenerics<Associado>, IAssociado
   {
      public RepositoryAssociado(Contexto context)
      {
         base.SetContext(context);
      }
   }
}
