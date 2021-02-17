using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Branches
{
    using Turquoise.Administration.Domain.Aggregate.Branch;
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
            return bussines.Success(branchViewModel);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BranchViewModel[]> Handle(SearchBranchesQuery request, CancellationToken cancellationToken)
        {
            var pagination = request.Pagination;
            var specify = new BranchSpecify(request.Filters);
            var (skip, rows) = ((pagination.Page - 1) * pagination.Rows, pagination.Rows);

            var query = dAO.GetQueryableBranches()
                .Where(specify.GetExpressions())
                .Skip(skip).Take(rows)
                .Select(e => new
                {
                    Branch = e,
                    Doctors = e.Doctors.Count
                }).ToArray();

            BranchViewModel[] branchViewModels =
                query.Select(e => e.Branch.Map<BranchViewModel>(viewModel => viewModel.Doctors = e.Doctors))
                .ToArray();

            return bussines.Success(branchViewModels);
        }
    }
}
