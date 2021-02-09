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
        private readonly BussinesProxy<IAdministratorDAO> service;

        public AdministratorQueryHandler()
        {
            service = new BussinesProxy<IAdministratorDAO>();
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel> Handle(GetAdministratorByIdQuery request, CancellationToken cancellationToken)
        {
            Administrator administrator = service.DataAccessObject.Get(request.Id);
            return service.Success(administrator.Map<AdministratorViewModel>());
        }

        /// <summary>
        /// Get page
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel[]> Handle(GetAdministratorsQuery request, CancellationToken cancellationToken)
        {
            AdministratorViewModel[] administrators =
               service.DataAccessObject.Get(_ => true, request.Pagination)
               .Map<AdministratorViewModel>()
               .ToArray();

            return service.Success(administrators);
        }
    }
}
