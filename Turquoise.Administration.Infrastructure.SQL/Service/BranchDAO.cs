using System;
using Turquoise.Administration.Domain.Aggregate.Branch;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    public class BranchDAO : CrudService<Branch, Guid>, IBranchDAO
    {
    }
}
