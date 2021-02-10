using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups.CQ
{
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO;

    public class GetChoiceGroupById : IRequest<ChoiceGroupViewModel>
    {
        public Guid ChoiceGroupId { get; set; }

        public GetChoiceGroupById(Guid choiceGroupId)
        {
            ChoiceGroupId = choiceGroupId;
        }

        public GetChoiceGroupById()
        {
        }
    }
}
