using AutoMapper;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO
{
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;
    public sealed class ChoiceGroupViewModelMapper : Profile
    {
        public ChoiceGroupViewModelMapper()
        {
            CreateMap<ChoiceGroup, ChoiceGroupViewModel>();
            CreateMap<ChoiceGroupViewModel, ChoiceGroup>();

            CreateMap<Choice, ChoiceViewModel>();
            CreateMap<ChoiceViewModel, Choice>();
        }
    }
}
