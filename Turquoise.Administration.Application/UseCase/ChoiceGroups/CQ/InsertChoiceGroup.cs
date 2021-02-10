using MediatR;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups.CQ
{
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO;
    public class InsertChoiceGroup : IRequest
    {
        public ChoiceGroupViewModel ChoiceGroupViewModel { get; set; }
    }
}
