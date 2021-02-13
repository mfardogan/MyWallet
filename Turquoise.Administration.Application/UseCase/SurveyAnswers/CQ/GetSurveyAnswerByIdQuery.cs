using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.CQ
{
    using Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO;

    public sealed class GetSurveyAnswerByIdQuery : IRequest<SurveyAnswerViewModel>
    {
        public Guid SurveyAnswerId { get; set; }

        public GetSurveyAnswerByIdQuery()
        {
        }

        public GetSurveyAnswerByIdQuery(Guid surveyAnswerId)
        {
            SurveyAnswerId = surveyAnswerId;
        }
    }
}
