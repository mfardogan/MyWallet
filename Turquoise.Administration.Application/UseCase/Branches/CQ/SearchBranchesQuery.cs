using MediatR;

namespace Turquoise.Administration.Application.UseCase.Branches.CQ
{
    using Turquoise.Administration.Domain.Aggregate.Common;
    using Turquoise.Administration.Application.UseCase.Branches.DTO;

    public class SearchBranchesQuery : IRequest<BranchViewModel[]>
    {
        public Pagination Pagination { get; set; }
        public BranchViewModel Filters { get; set; }
    }
}
