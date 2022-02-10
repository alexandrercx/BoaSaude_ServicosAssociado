using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class RepositoryBase : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Dispose();
        }
    }
}
