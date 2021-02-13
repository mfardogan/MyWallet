using MediatR;

namespace Turquoise.Administration.Application.UseCase.Branches.CQ
{
    using Turquoise.Administration.Application.UseCase.Branches.DTO;
    public class UpdateBranchCommand : IRequest
    {
        public BranchViewModel BranchViewModel { get; set; }
    }
}
