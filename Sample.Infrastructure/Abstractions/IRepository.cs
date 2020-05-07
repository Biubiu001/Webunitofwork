using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sample.Infrastructure.Interfaces.Abstractions
{
   public  interface IRepository<T> where T:class
    {
        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }

        List<T> GetAll();

        List<T> GetMultiple(Expression<Func<T, bool>> predicate);

        List<T> GetMultipleAsc<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector);

        List<T> GetMultipleDesc<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector);

        //PagedList<T> GetPagedList(int pageIndex, int pageSize);

        //PagedList<T> GetPagedListAsc<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, int pageIndex, int pageSize);

        //PagedList<T> GetPagedListDesc<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, int pageIndex, int pageSize);

        T GetSingle(Expression<Func<T, bool>> predicate);

        void Insert(T entity);
        void Insert(IEnumerable<T> entity);
        void InsertRange(params T[] entity);

        void Update(T entity);
        void UpdateRange(params T[] entity);
        //void Update(T entity, bool update, params string[] properties);
        //void Update<TProperty>(T entity, bool update, params Expression<Func<T, TProperty>>[] properties);

        void Delete(T entity);
        void Delete(IEnumerable<T> enetity);
        //void Delete(object id);
    }
}
