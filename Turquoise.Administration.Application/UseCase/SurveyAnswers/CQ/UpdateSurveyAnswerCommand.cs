﻿using MediatR;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.CQ
{
    using Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO;
    public sealed class UpdateSurveyAnswerCommand : IRequest
    {
        public SurveyAnswerViewModel SurveyAnswerViewModel { get; set; }
    }
}
