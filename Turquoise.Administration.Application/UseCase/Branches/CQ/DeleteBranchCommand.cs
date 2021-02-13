using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Branches.CQ
{
    public class DeleteBranchCommand : IRequest
    {
        public DeleteBranchCommand()
        {
        }

        public DeleteBranchCommand(Guid branchId)
        {
            BranchId = branchId;
        }

        public Guid BranchId { get; set; }
    }
}
