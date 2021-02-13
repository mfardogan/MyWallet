using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups.CQ
{
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO;

    public class GetChoiceGroupByIdQuery : IRequest<ChoiceGroupViewModel>
    {
        public Guid ChoiceGroupId { get; set; }

        public GetChoiceGroupByIdQuery(Guid choiceGroupId)
        {
            ChoiceGroupId = choiceGroupId;
        }

        public GetChoiceGroupByIdQuery()
        {
        }
    }
}
