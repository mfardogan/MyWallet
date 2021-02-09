using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Administrators
{
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;
    using Turquoise.Administration.Application.UseCase.Administrators.Request;

    public class AdministratorQueryHandler :
        IRequestHandler<GetAdministratorByIdQuery, AdministratorViewModel>,
        IRequestHandler<GetAdministratorsQuery, AdministratorViewModel[]>
    {
        private readonly IAdministratorDAO dAO;
        private readonly ServiceStub<IAdministratorDAO> serviceStub =
            new ServiceStub<IAdministratorDAO>();

        public AdministratorQueryHandler()
        {
            dAO = serviceStub.DataAccessObject;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel> Handle(GetAdministratorByIdQuery request, CancellationToken cancellationToken)
        {
            Administrator administrator = dAO.Get(request.Id);
            return serviceStub.Success(administrator.Map<AdministratorViewModel>());
        }

        /// <summary>
        /// Get page
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel[]> Handle(GetAdministratorsQuery request, CancellationToken cancellationToken)
        {
            var entities = dAO.Get(_ => true, request.Pagination);

            AdministratorViewModel[] administrators =
               entities.Map<AdministratorViewModel>()
                .ToArray();

            return serviceStub.Success(administrators);
        }
    }
}
