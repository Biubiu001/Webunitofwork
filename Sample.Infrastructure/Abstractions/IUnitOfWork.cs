using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Interfaces.Abstractions
{
   public interface IUnitOfWork
    {
        IRepository<T> CreateRepository<T>() where T : class;

        bool SaveChanges();

        Task<bool> SaveChangesAsync();
    }
}
