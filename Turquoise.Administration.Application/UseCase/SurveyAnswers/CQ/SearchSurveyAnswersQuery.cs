using MediatR;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.CQ
{
    using Turquoise.Administration.Domain.Aggregate.Common;
    using Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO;

    public sealed class SearchSurveyAnswersQuery : IRequest<SurveyAnswerViewModel[]>
    {
        public Pagination Pagination { get; set; }
        public SurveyAnswerViewModel Filters { get; set; }
    }
}
