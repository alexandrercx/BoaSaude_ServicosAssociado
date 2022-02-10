using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class Base : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        protected virtual void Disposing(bool disposing)
        {
            Dispose();
        }
    }
}
