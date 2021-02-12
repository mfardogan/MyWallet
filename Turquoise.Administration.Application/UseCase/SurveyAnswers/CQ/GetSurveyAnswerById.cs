using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.CQ
{
    using Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO;

    public sealed class GetSurveyAnswerById : IRequest<SurveyAnswerViewModel>
    {
        public Guid SurveyAnswerId { get; set; }

        public GetSurveyAnswerById()
        {
        }

        public GetSurveyAnswerById(Guid surveyAnswerId)
        {
            SurveyAnswerId = surveyAnswerId;
        }
    }
}
