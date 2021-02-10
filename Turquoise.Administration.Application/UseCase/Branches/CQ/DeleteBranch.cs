using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Branches.CQ
{
    public class DeleteBranch : IRequest
    {
        public DeleteBranch()
        {
        }

        public DeleteBranch(Guid branchId)
        {
            BranchId = branchId;
        }

        public Guid BranchId { get; set; }
    }
}
