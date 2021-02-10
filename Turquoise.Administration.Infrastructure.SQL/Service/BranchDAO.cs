using System;
using Turquoise.Administration.Domain.Aggregation.Branch;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    public class BranchDAO : CrudService<Branch, Guid>, IBranchDAO
    {

    }
}
