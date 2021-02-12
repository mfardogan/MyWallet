using System;
using System.Linq.Expressions;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO;

    public sealed class ChoiceGroupSpecify : Specification<ChoiceGroup, ChoiceGroupViewModel>
    {
        public ChoiceGroupSpecify(ChoiceGroupViewModel filterClause) : base(filterClause)
        {
        }

        /// <summary>
        /// Get expressions
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<ChoiceGroup, bool>> GetExpressions()
        {
            return filter => IsThereNoFilter() ||
                (string.IsNullOrEmpty(FilterClause.Name) || filter.Name == FilterClause.Name) &&
                (string.IsNullOrEmpty(FilterClause.Code) || filter.Code == FilterClause.Code);
        }
    }
}
