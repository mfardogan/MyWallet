using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Branches
{
    using Turquoise.Administration.Domain.Aggregate.Branch;
    using Turquoise.Administration.Application.UseCase.Branches.CQ;

    public partial class BranchCQHandler :
        IRequestHandler<InsertBranchCommand>,
        IRequestHandler<UpdateBranchCommand>,
        IRequestHandler<DeleteBranchCommand>
    {
        private readonly IBranchDAO dAO;
        private readonly ServiceProxy<IBranchDAO> bussines;
        public BranchCQHandler()
        {
            var proxy = new ServiceProxy<IBranchDAO>();
            (bussines, dAO) = (proxy, proxy.DataAccessObject);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(InsertBranchCommand request, CancellationToken cancellationToken)
        {
            dAO.Insert(request.BranchViewModel);
            await bussines.SaveAsync();
            return bussines.Success();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            dAO.Update(request.BranchViewModel);
            await bussines.SaveAsync();
            return bussines.Success();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            dAO.Delete(request.BranchId);
            await bussines.SaveAsync();
            return bussines.Success();
        }
    }
}
