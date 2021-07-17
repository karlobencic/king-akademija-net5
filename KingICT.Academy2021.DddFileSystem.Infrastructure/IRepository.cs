using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KingICT.Academy2021.DddFileSystem.Infrastructure
{
    public interface IRepository<T, TId> where T : IAggregateRoot
    {
        Task<T> Add(T entity);
        Task<IEnumerable<T>> AddRange(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<T> Remove(T entity);
        Task<IEnumerable<T>> RemoveRange(IEnumerable<T> entities);
        Task<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
        Task<IEnumerable<T>> FindAll(params Expression<Func<T, object>>[] includeExpressions);
        Task<IEnumerable<T>> FindAllBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
    }
}
