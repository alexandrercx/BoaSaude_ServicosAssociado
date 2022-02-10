using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {

        TEntity Add(TEntity entity);

        TEntity GetByKey(int id);

        bool Commit();


    }
}
