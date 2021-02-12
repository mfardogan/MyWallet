using FluentValidation;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO
{
    public sealed class SurveyAnswerChoiceViewModelValidator : AbstractValidator<SurveyAnswerChoiceViewModel>
    {
        public SurveyAnswerChoiceViewModelValidator()
        {
            RuleFor(x => (int)x.DrawingType).GreaterThanOrEqualTo(0).LessThanOrEqualTo(3);
        }
    }
}
