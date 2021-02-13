using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Surveys.CQ
{
    using Turquoise.Administration.Application.UseCase.Surveys.DTO;
    public sealed class GetSurveyByIdQuery : IRequest<SurveyViewModel>
    {
        public GetSurveyByIdQuery()
        {
        }

        public GetSurveyByIdQuery(Guid surveyId) => SurveyId = surveyId;

        public Guid SurveyId { get; set; }
    }
}
