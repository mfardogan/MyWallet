using System;
using System.Linq.Expressions;

namespace MyWallet.Administration.Domain.Aggregation.Common
{
    public interface IQuery<TEntity, TPk> where TEntity : Entity<TPk>
    {
        TEntity Get(TPk id);
        TEntity[] Get(Expression<Func<TEntity, bool>> expression = null, Pagination pagination = null);
    }
}
