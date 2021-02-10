using FluentValidation;

namespace Turquoise.Administration.Application.UseCase.Branches.DTO
{
    public sealed class BranchViewModelValidator : AbstractValidator<BranchViewModel>
    {
        public BranchViewModelValidator()
        {
            RuleFor(x => x.Code).MaximumLength(3).NotNull().NotEmpty();
            RuleFor(x => x.Name).MaximumLength(20).NotNull().NotEmpty();
        }
    }
}
