using System;
using System.Linq.Expressions;

namespace MyWallet.Administration.Application.UseCase
{
    public abstract class Specification<TEntity,TViewModel>
    {
        public TViewModel FilterCaluses { get; }
        protected Specification(TViewModel filterCaluses) => FilterCaluses = filterCaluses;

        public virtual bool IsEmptyFilter()
        {
            return FilterCaluses == null;
        }

        /// <summary>
        /// Get expression
        /// </summary>
        /// <returns></returns>
        public abstract Expression<Func<TEntity, bool>> Build();
    }
}
