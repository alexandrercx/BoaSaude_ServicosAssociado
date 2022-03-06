using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServGenerics<TEntity> where TEntity : class
    {
      Task Add(TEntity value);

      Task Update(TEntity value);

      Task Delete(TEntity value);

      Task<TEntity> Get(int Id);

      Task<List<TEntity>> List(Expression<Func<TEntity, bool>> expression);
   }
}
