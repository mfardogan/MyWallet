using System;
using System.Linq.Expressions;

namespace Turquoise.Administration.Application.UseCase.Branches
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Branch;
    using Turquoise.Administration.Application.UseCase.Branches.DTO;
    public sealed class BranchSpecify : Specification<Branch, BranchViewModel>
    {
        public BranchSpecify(BranchViewModel filterClause) : base(filterClause)
        {
        }

        /// <summary>
        /// Get filters
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<Branch, bool>> GetExpressions()
        {
            return filter => IsThereNoFilter() || 
            (string.IsNullOrEmpty(FilterClause.Name) || filter.Name == FilterClause.Name) &&
            (string.IsNullOrEmpty(FilterClause.Code) || filter.Code == FilterClause.Code);
        }
    }
}
