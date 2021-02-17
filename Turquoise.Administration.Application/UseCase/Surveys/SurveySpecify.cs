using System;
using System.Linq.Expressions;

namespace Turquoise.Administration.Application.UseCase.Surveys
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Survey;
    using Turquoise.Administration.Application.UseCase.Surveys.DTO;
    public sealed class SurveySpecify : Specification<Survey, SurveyViewModel>
    {
        public SurveySpecify(SurveyViewModel filterClause) : base(filterClause)
        {
        }

        /// <summary>
        /// Get expressions
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<Survey, bool>> GetExpressions()
        {
            return e => IsThereNoFilter() || 
            (string.IsNullOrEmpty(FilterClause.Title) || e.Title.Contains(FilterClause.Title)) &&
            (FilterClause.BranchId == Guid.Empty || e.BranchId == FilterClause.BranchId);
        }
    }
}
