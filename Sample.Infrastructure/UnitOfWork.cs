using Microsoft.EntityFrameworkCore;
using Sample.Infrastructure.Interfaces.Abstractions;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Interfaces
{
   public  class UnitOfWork:IUnitOfWork
    {
        public UnitOfWork(IServiceProvider provider, DbContext dbContext)
        {
            Provider = provider;
            DbContext = dbContext;
        }

        private IServiceProvider Provider { get; }
        private DbContext DbContext { get; }

        public IRepository<T> CreateRepository<T>() where T : class =>
            Provider.GetService<IRepository<T>>();

        public bool SaveChanges() =>
            DbContext.SaveChanges() > 0 ? true : false;
        public async Task<bool> SaveChangesAsync()
        {
            var result = await DbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext.Dispose();
            }
        }
    }
}
