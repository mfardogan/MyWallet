using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    using Turquoise.Administration.Domain.Aggregate.Branch;
    public class BranchDAO : CrudService<Branch, Guid>, IBranchDAO
    {
        /// <summary>
        /// Search branches
        /// </summary>
        /// <returns></returns>
        public IQueryable<Branch> GetQueryableBranches() => RepositoryContext.AsNoTracking();
    }
}
