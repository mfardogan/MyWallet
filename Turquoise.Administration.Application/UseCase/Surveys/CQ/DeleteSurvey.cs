using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Surveys.CQ
{
    public sealed class DeleteSurvey : IRequest
    {
        public DeleteSurvey()
        {
        }

        public DeleteSurvey(Guid surveyId) => SurveyId = surveyId;

        public Guid SurveyId { get; set; }
    }
}
