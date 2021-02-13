using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.CQ
{
    public sealed class DeleteSurveyAnswerCommand : IRequest
    {
        public Guid SurveyAnswerId { get; set; }

        public DeleteSurveyAnswerCommand()
        {
        }

        public DeleteSurveyAnswerCommand(Guid surveyAnswerId)
        {
            SurveyAnswerId = surveyAnswerId;
        }
    }
}
