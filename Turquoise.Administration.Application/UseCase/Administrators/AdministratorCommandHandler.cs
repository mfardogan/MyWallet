using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Administrators
{
    using Turquoise.Administration.Domain;
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Application.UseCase.Administrators.CQ;
    public partial class AdministratorCQHandler :
        IRequestHandler<InsertAdministrator>,
        IRequestHandler<UpdateAdministrator>,
        IRequestHandler<DeleteAdministrator>
    {
        private readonly IAdministratorDAO dAO;
        private readonly ServiceProxy<IAdministratorDAO> service;
        public AdministratorCQHandler()
        {
            var proxy = new ServiceProxy<IAdministratorDAO>();
            (service, dAO) = (proxy, proxy.DataAccessObject);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(InsertAdministrator request, CancellationToken cancellationToken)
        {
            var (salt, hash) = GetSaltHashTuple(request.AdministratorViewModel.Password);
            Administrator administrator = request.AdministratorViewModel;
            administrator.AddPassword(salt, hash);

            dAO.Insert(administrator);
            await service.SaveAsync();
            return service.Success();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteAdministrator request, CancellationToken cancellationToken)
        {
            dAO.Delete(request.AdministratorId);
            await service.SaveAsync();
            return service.Success();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateAdministrator request, CancellationToken cancellationToken)
        {
            dAO.Update(request.ViewModel);
            await service.SaveAsync();
            return service.Success();
        }

        /// <summary>
        /// Generate password
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private (byte[] salt, byte[] hash) GetSaltHashTuple(string input)
        {
            var shaker = Dependency.Get<ISaltFactory>().Generate();
            var hasher = Dependency.Get<IPasswordHasher>().Compute(input, shaker);
            return (shaker, hasher);
        }
    }
}
