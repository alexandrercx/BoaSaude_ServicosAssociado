using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryGenerics<TEntity> : IServGenerics<TEntity>, IDisposable where TEntity : class
    {
        public readonly DbContextOptions<Contexto> _OptionBuilder;
        private Contexto _ContextBase;

        public RepositoryGenerics()
        {
            _OptionBuilder = new DbContextOptions<Contexto>();
        }

        public void SetContext(Contexto ContextBase)
        {
            _ContextBase = ContextBase;
        }

        public virtual async Task Add(TEntity entity)
        {
            await _ContextBase.Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete(TEntity entity)
        {
            _ContextBase.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<TEntity> Get(int Id)
        {
            return await _ContextBase.Set<TEntity>().FindAsync(Id);
        }

        public virtual async Task<List<TEntity>> List(Expression<Func<TEntity, bool>> expression)
        {
            if (expression != null)
                return await _ContextBase.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync();
            else
                return await _ContextBase.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _ContextBase.Set<TEntity>().Update(entity);
        }

        #region "Dispose"

        //Font: https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose

        // To detect redundant calls
        private bool _disposed = false;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                // Dispose managed state (managed objects).
                _safeHandle?.Dispose();

            _disposed = true;
        }

        #endregion
    }
}
