using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups.CQ
{
    public class DeleteChoiceGroup : IRequest
    {
        public Guid ChoiceGroupId { get; set; }

        public DeleteChoiceGroup(Guid choiceGroupId)
        {
            ChoiceGroupId = choiceGroupId;
        }

        public DeleteChoiceGroup()
        {
        }
    }
}
