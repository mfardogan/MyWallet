using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.CQ
{
    public sealed class DeleteSurveyAnswer : IRequest
    {
        public Guid SurveyAnswerId { get; set; }

        public DeleteSurveyAnswer()
        {
        }

        public DeleteSurveyAnswer(Guid surveyAnswerId)
        {
            SurveyAnswerId = surveyAnswerId;
        }
    }
}
