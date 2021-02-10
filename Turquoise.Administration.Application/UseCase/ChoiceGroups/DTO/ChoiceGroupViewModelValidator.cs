using FluentValidation;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO
{
    public sealed class ChoiceGroupViewModelValidator : AbstractValidator<ChoiceGroupViewModel>
    {
        public ChoiceGroupViewModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(20).NotNull().NotEmpty();
            RuleFor(x => x.Code).MaximumLength(3).NotNull().NotEmpty();
            RuleForEach(x => x.Choices).SetValidator(new ChoiceViewModelValidator());
        }
    }

    public sealed class ChoiceViewModelValidator : AbstractValidator<ChoiceViewModel>
    {
        public ChoiceViewModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(20).NotNull().NotEmpty();
            RuleFor(x => x.Code).MaximumLength(3).NotNull().NotEmpty();
            RuleFor(x => x.Color).MaximumLength(6).NotNull().NotEmpty();
        }
    }
}
