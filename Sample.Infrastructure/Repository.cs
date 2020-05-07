using Microsoft.EntityFrameworkCore;
using Sample.Infrastructure.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Interfaces
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        private DbContext DbContext { get; }
        private DbSet<T> DbSet { get; }
        public virtual IQueryable<T> Table => DbSet;
        public virtual IQueryable<T> TableNoTracking => Table.AsNoTracking();

        public List<T> GetAll() =>
            TableNoTracking.ToList();
        public List<T> GetMultiple(Expression<Func<T, bool>> predicate) =>
            TableNoTracking.Where(predicate).ToList();
        public List<T> GetMultipleAsc<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector) =>
            TableNoTracking.Where(predicate).OrderBy(keySelector).ToList();
        public List<T> GetMultipleDesc<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector) =>
            TableNoTracking.Where(predicate).OrderByDescending(keySelector).ToList();
        public Task<List<T>> GetMultipleAscAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector) =>
            TableNoTracking.Where(predicate).OrderBy(keySelector).ToListAsync();
        public Task<List<T>> GetMultipleDescAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector) =>
            TableNoTracking.Where(predicate).OrderBy(keySelector).ToListAsync();
        //public PagedList<T> GetPagedList(int pageIndex, int pageSize) =>
        //    TableNoTracking.Pagination(pageIndex, pageSize);
        public T GetSingle(Expression<Func<T, bool>> predicate) =>
            TableNoTracking.SingleOrDefault(predicate);
        public async Task<List<T>> GetAllAsync() =>
            await TableNoTracking.ToListAsync();
        public async Task<List<T>> GetMultipleAsync(Expression<Func<T, bool>> predicate) =>
            await TableNoTracking.Where(predicate).ToListAsync();
        //public async Task<PagedList<T>> GetPagedListAsync(int pageIndex, int pageSize) =>
        //   await TableNoTracking.PaginationAsync(pageIndex, pageSize);
        //public PagedList<T> GetPagedListAsc<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, int pageIndex, int pageSize) =>
        //    TableNoTracking.Where(predicate).OrderBy(keySelector).Pagination(pageIndex, pageSize);
        //public PagedList<T> GetPagedListDesc<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, int pageIndex, int pageSize) =>
        //    TableNoTracking.Where(predicate).OrderByDescending(keySelector).Pagination(pageIndex, pageSize);
        //public async Task<PagedList<T>> GetPagedListAscAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, int pageIndex, int pageSize) =>
        //    await TableNoTracking.Where(predicate).OrderBy(keySelector).PaginationAsync(pageIndex, pageSize);
        //public async Task<PagedList<T>> GetPagedListDescAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, int pageIndex, int pageSize) =>
        //   await TableNoTracking.Where(predicate).OrderByDescending(keySelector).PaginationAsync(pageIndex, pageSize);
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate) =>
           await TableNoTracking.SingleOrDefaultAsync(predicate);

        public void Insert(T entity)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
                if (prop.PropertyType == typeof(string) && prop.GetValue(entity) == null)
                    prop.SetValue(entity, string.Empty);
            DbSet.Add(entity);
        }
        public void Insert(IEnumerable<T> entity) =>
            DbSet.AddRange(entity);
        public void InsertRange(params T[] entity) =>
            DbSet.AddRange(entity);

        public void Update(T entity) =>
            DbSet.Update(entity);
        //public void Update(T entity, bool update, params string[] properties) =>
        //    DbSet.Update(entity, update, properties);
        //public void Update<TProperty>(T entity, bool update, params Expression<Func<T, TProperty>>[] properties) =>
        //    DbSet.Update(entity, update, properties);
        public void UpdateRange(params T[] entity) =>
            DbSet.UpdateRange(entity);

        public void Delete(T entity) =>
            DbSet.Remove(entity);
        public void Delete(IEnumerable<T> entity) =>
            DbSet.RemoveRange(entity);
        //public void Delete(object id) =>
        //    DbSet.Delete(id);
    }
}
