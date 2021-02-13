using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Branches.CQ
{
    using Turquoise.Administration.Application.UseCase.Branches.DTO;
    public class GetBranchByIdQuery : IRequest<BranchViewModel>
    {
        public GetBranchByIdQuery()
        {
        }

        public GetBranchByIdQuery(Guid branchId)
        {
            BranchId = branchId;
        }

        public Guid BranchId { get; set; }
    }
}
