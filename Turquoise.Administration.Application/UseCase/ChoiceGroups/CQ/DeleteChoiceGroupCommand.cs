using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups.CQ
{
    public class DeleteChoiceGroupCommand : IRequest
    {
        public Guid ChoiceGroupId { get; set; }

        public DeleteChoiceGroupCommand(Guid choiceGroupId)
        {
            ChoiceGroupId = choiceGroupId;
        }

        public DeleteChoiceGroupCommand()
        {
        }
    }
}
