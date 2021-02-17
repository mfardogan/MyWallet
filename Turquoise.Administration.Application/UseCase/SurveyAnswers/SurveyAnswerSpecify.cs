using System;
using System.Linq.Expressions;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.SurveyAnswer;
    using Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO;

    public sealed class SurveyAnswerSpecify : Specification<SurveyAnswer, SurveyAnswerViewModel>
    {
        public SurveyAnswerSpecify(SurveyAnswerViewModel filterClause) : base(filterClause)
        {
        }

        /// <summary>
        /// Get expressions
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<SurveyAnswer, bool>> GetExpressions()
        {
            return e => true;
        }
    }
}
