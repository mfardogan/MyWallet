using System;

namespace Turquoise.Administration.Domain.Aggregation.Branch
{
    using Turquoise.Administration.Domain.Aggregation.Common;

    public interface IBranchDAO :
        ICommand<Branch, Guid>, 
        IQuery<Branch, Guid>
    {
    }
}
