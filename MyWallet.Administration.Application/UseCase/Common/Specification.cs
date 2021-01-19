using System;
using System.Linq.Expressions;

namespace MyWallet.Administration.Application.UseCase
{
    public abstract class Specification<TEntity,TViewModel>
    {
        public TViewModel FilterCaluses { get; }
        protected Specification(TViewModel filterCaluses)
        {
            FilterCaluses = filterCaluses;
        }

        /// <summary>
        /// Get expression
        /// </summary>
        /// <returns></returns>
        public abstract Expression<Func<TEntity, bool>> GetExpression();
    }
}
