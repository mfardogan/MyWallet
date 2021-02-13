using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Surveys.CQ
{
    public sealed class DeleteSurveyCommand : IRequest
    {
        public DeleteSurveyCommand()
        {
        }

        public DeleteSurveyCommand(Guid surveyId) => SurveyId = surveyId;

        public Guid SurveyId { get; set; }
    }
}
