using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Surveys.CQ
{
    using Turquoise.Administration.Application.UseCase.Surveys.DTO;
    public sealed class GetSurveyById : IRequest<SurveyViewModel>
    {
        public GetSurveyById()
        {
        }

        public GetSurveyById(Guid surveyId) => SurveyId = surveyId;

        public Guid SurveyId { get; set; }
    }
}
