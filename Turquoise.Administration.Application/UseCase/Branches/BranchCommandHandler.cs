using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Branches
{
    using Turquoise.Administration.Domain.Aggregation.Branch;
    using Turquoise.Administration.Application.UseCase.Branches.CQ;
    public partial class BranchCQHandler :
        IRequestHandler<InsertBranch>,
        IRequestHandler<UpdateBranch>,
        IRequestHandler<DeleteBranch>
    {
        private readonly IBranchDAO dAO;
        private readonly ServiceProxy<IBranchDAO> service;
        public BranchCQHandler()
        {
            var proxy = new ServiceProxy<IBranchDAO>();
            (service, dAO) = (proxy, proxy.DataAccessObject);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(InsertBranch request, CancellationToken cancellationToken)
        {
            dAO.Insert(request.BranchViewModel);
            await service.SaveAsync();
            return service.Success();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateBranch request, CancellationToken cancellationToken)
        {
            dAO.Update(request.BranchViewModel);
            await service.SaveAsync();
            return service.Success();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteBranch request, CancellationToken cancellationToken)
        {
            dAO.Delete(request.BranchId);
            await service.SaveAsync();
            return service.Success();
        }
    }
}
