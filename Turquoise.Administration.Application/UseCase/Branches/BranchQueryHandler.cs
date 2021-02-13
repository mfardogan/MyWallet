using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Branches
{
    using Turquoise.Administration.Domain.Aggregation.Branch;
    using Turquoise.Administration.Application.UseCase.Branches.CQ;
    using Turquoise.Administration.Application.UseCase.Branches.DTO;

    public partial class BranchCQHandler :
        IRequestHandler<GetBranchByIdQuery, BranchViewModel>,
        IRequestHandler<SearchBranchesQuery, BranchViewModel[]>
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BranchViewModel> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            Branch branch = dAO.Get(request.BranchId);
            BranchViewModel branchViewModel = branch.Map<BranchViewModel>();
            return service.Success(branchViewModel);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BranchViewModel[]> Handle(SearchBranchesQuery request, CancellationToken cancellationToken)
        {
            BranchSpecify specify = new BranchSpecify(request.Filters);
            BranchViewModel[] branchViewModels =
               dAO.Get(specify.GetExpressions(), request.Pagination)
               .Map<BranchViewModel>()
               .ToArray();

            return service.Success(branchViewModels);
        }
    }
}
