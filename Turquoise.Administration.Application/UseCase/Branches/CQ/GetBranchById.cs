using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Branches.CQ
{
    using Turquoise.Administration.Application.UseCase.Branches.DTO;
    public class GetBranchById : IRequest<BranchViewModel>
    {
        public GetBranchById()
        {
        }

        public GetBranchById(Guid branchId)
        {
            BranchId = branchId;
        }

        public Guid BranchId { get; set; }
    }
}
