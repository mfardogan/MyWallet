using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups
{
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.CQ;

    public partial class ChoiceGroupCQHandler:
        IRequestHandler<InsertChoiceGroupCommand>,
        IRequestHandler<UpdateChoiceGroupCommand>,
        IRequestHandler<DeleteChoiceGroupCommand>
    {
        private readonly IChoiceGroupDAO dAO;
        private readonly ServiceProxy<IChoiceGroupDAO> service;
        public ChoiceGroupCQHandler()
        {
            var proxy = new ServiceProxy<IChoiceGroupDAO>();
            (service, dAO) = (proxy, proxy.DataAccessObject);
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
            await service.SaveAsync();
            return service.Success();
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
            await service.SaveAsync();
            return service.Success();
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
            await service.SaveAsync();
            return service.Success();
        }
    }
}
