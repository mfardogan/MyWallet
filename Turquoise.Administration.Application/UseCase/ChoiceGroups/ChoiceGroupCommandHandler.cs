using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups
{
    using Turquoise.Administration.Domain.Aggregate.ChoiceGroup;
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.CQ;

    public partial class ChoiceGroupCQHandler:
        IRequestHandler<InsertChoiceGroupCommand>,
        IRequestHandler<UpdateChoiceGroupCommand>,
        IRequestHandler<DeleteChoiceGroupCommand>
    {
        private readonly IChoiceGroupDAO dAO;
        private readonly ServiceProxy<IChoiceGroupDAO> bussines;
        public ChoiceGroupCQHandler()
        {
            var proxy = new ServiceProxy<IChoiceGroupDAO>();
            (bussines, dAO) = (proxy, proxy.DataAccessObject);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(InsertChoiceGroupCommand request, CancellationToken cancellationToken)
        {
            dAO.Insert(request.ChoiceGroupViewModel);
            await bussines.SaveAsync();
            return bussines.Success();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateChoiceGroupCommand request, CancellationToken cancellationToken)
        {
            dAO.Update(request.ChoiceGroupViewModel);
            await bussines.SaveAsync();
            return bussines.Success();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteChoiceGroupCommand request, CancellationToken cancellationToken)
        {
            dAO.Delete(request.ChoiceGroupId);
            await bussines.SaveAsync();
            return bussines.Success();
        }
    }
}
