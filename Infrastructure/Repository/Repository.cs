using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repository
{

    public class Repository<TEntity> : RepositoryBase, IRepository<TEntity> where TEntity : class
    {

        protected readonly Context.Contexto con;
        protected readonly DbSet<TEntity> DbSet;


        public Repository(Context.Contexto context)
        {
            con = context;
            DbSet = con.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntity GetByKey(int id)
        {
            throw new NotImplementedException();
        }
    }
}
