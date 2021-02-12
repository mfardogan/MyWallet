using System;
using System.Linq.Expressions;

namespace Turquoise.Administration.Domain.Abstraction
{
    using Turquoise.Administration.Domain.Aggregation.Common;
    public abstract class Specification<TEntity, TViewModel> where TEntity : Entity<Guid> where TViewModel : class, new()
    {
        public TViewModel FilterClause { get; }
        protected Specification(TViewModel filterClause) => FilterClause = filterClause;

        /// <summary>
        /// Is empty filter
        /// </summary>
        /// <returns></returns>
        public bool IsThereNoFilter() => FilterClause is null;

        /// <summary>
        /// Create expressions
        /// </summary>
        /// <returns></returns>
        public abstract Expression<Func<TEntity, bool>> GetExpressions();
    }
}
