using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    using Turquoise.Administration.Domain.Aggregation.Common;
    public abstract class CrudService<TEntity, TPk> : BaseService where TEntity : Entity<TPk>
    {
        public DbSet<TEntity> Repository { get; set; }
        public CrudService() => Repository = DbContext.Set<TEntity>();

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Delete(TPk id)
        {
            TEntity entity = Repository.Single(e => e.Id.Equals(id));
            Repository.Remove(entity);
            return entity;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TEntity Insert(TEntity entity)
        {
            return Repository.Add(entity).Entity;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TEntity Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            return entity;

        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Get(Guid id)
        {
            return Repository.SingleOrDefault(e => e.Id.Equals(id));
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public virtual TEntity[] Get(Expression<Func<TEntity, bool>> expression = null, Pagination pagination = null)
        {
            var (skip, rows) = ((pagination.Page - 1) * pagination.Rows, pagination.Rows);
            return Repository.Where(expression)
                .Skip(skip)
                .Take(rows)
                .ToArray();
        }
    }
}
