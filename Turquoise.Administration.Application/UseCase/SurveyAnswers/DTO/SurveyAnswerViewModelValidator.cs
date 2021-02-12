using FluentValidation;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO
{
    public sealed class SurveyAnswerViewModelValidator : AbstractValidator<SurveyAnswerViewModel>
    {
        public SurveyAnswerViewModelValidator()
        {
            RuleForEach(x => x.AnswerChoices).SetValidator(new SurveyAnswerChoiceViewModelValidator());
        }
    }
}
