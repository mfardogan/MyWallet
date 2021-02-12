using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Administrators
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;
    using Turquoise.Administration.Application.UseCase.Administrators.CQ;

    public partial class AdministratorCQHandler :
        IRequestHandler<GetAdministratorById, AdministratorViewModel>,
        IRequestHandler<SearchAdministrators, AdministratorViewModel[]>
    {    
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel> Handle(GetAdministratorById request, CancellationToken cancellationToken)
        {
            Administrator administrator = dAO.Get(request.Id);
            return service.Success(administrator.Map<AdministratorViewModel>());
        }

        /// <summary>
        /// Get page
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel[]> Handle(SearchAdministrators request, CancellationToken cancellationToken)
        {
            Specification<Administrator, AdministratorViewModel> specify =
                new AdministratorSpecify(request.Filters);

            AdministratorViewModel[] administrators =
               dAO.Get(specify.GetExpressions(), request.Pagination)
               .Map<AdministratorViewModel>()
               .ToArray();

            return service.Success(administrators);
        }
    }
}
