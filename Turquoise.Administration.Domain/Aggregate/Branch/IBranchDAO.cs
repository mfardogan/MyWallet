using System;

namespace Turquoise.Administration.Domain.Aggregate.Branch
{
    using System.Linq;
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;

    public interface IBranchDAO : IDataAccessObject,
        ICommand<Branch, Guid>, 
        IQuery<Branch, Guid>
    {
        IQueryable<Branch> GetQueryableBranches();
    }
}
