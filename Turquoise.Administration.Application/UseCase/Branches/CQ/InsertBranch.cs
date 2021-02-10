using MediatR;

namespace Turquoise.Administration.Application.UseCase.Branches.CQ
{
    using Turquoise.Administration.Application.UseCase.Branches.DTO;
    public class InsertBranch : IRequest
    {
        public BranchViewModel BranchViewModel { get; set; }
    }
}
