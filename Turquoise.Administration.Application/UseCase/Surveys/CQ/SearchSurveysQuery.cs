using MediatR;

namespace Turquoise.Administration.Application.UseCase.Surveys.CQ
{
    using Turquoise.Administration.Domain.Aggregate.Common;
    using Turquoise.Administration.Application.UseCase.Surveys.DTO;
    public sealed class SearchSurveysQuery : IRequest<SurveyViewModel[]>
    {
        public Pagination Pagination { get; set; }
        public SurveyViewModel Filters { get; set; }
    }
}
