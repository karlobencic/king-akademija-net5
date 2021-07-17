using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KingICT.Academy2021.DddFileSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace KingICT.Academy2021.DddFileSystem.Repository
{
    public abstract class RepositoryBase<T, TId> where T : EntityBase<TId>, IAggregateRoot
    {
        protected readonly DbContext Db;

        protected RepositoryBase(DbContext db)
        {
            Db = db;
        }

        public virtual async Task<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = Db.Set<T>().Where(predicate);

            foreach (var includeExpression in includeExpressions)
            {
                query = query.Include(includeExpression);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = Db.Set<T>();

            foreach (var includeExpression in includeExpressions)
            {
                query = query.Include(includeExpression);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAllBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = Db.Set<T>().Where(predicate);

            foreach (var includeExpression in includeExpressions)
            {
                query = query.Include(includeExpression);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<T> Add(T entity)
        {
            await Db.Set<T>().AddAsync(entity);

            await Db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
        {
            var entitiesList = entities.ToList();

            await Db.Set<T>().AddRangeAsync(entitiesList);
            await Db.SaveChangesAsync();
            return entitiesList;
        }

        public virtual async Task<T> Update(T entity)
        {
            if (Db.Entry(entity).State == EntityState.Detached)
            {
                Db.Attach(entity);
                Db.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                Db.Entry(entity).CurrentValues.SetValues(entity);
            }

            await Db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Remove(T entity)
        {
            if (Db.Entry(entity).State == EntityState.Detached)
            {
                Db.Attach(entity);
            }

            Db.Set<T>().Remove(entity);

            await Db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> RemoveRange(IEnumerable<T> entities)
        {
            var entitiesList = entities.ToList();

            foreach (var entity in entitiesList)
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                {
                    Db.Attach(entity);
                }
            }

            Db.Set<T>().RemoveRange(entitiesList);

            await Db.SaveChangesAsync();
            return entitiesList;
        }
    }
}
