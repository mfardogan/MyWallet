using FluentValidation;

namespace Turquoise.Administration.Application.UseCase.Surveys.DTO
{
    public sealed class SurveyViewModelValidator : AbstractValidator<SurveyViewModel>
    {
        public SurveyViewModelValidator()
        {
            RuleFor(x => x.Title).MaximumLength(100);
            RuleFor(x => x.Body).MaximumLength(1000);
        }
    }
}
