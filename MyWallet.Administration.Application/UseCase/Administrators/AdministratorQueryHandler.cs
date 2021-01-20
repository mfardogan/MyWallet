using MediatR;
using MyWallet.Administration.Application.UseCase.Administrators.CQ;
using MyWallet.Administration.Application.UseCase.Administrators.DTO;
using MyWallet.Administration.Domain.Aggregation.Administrator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyWallet.Administration.Application.UseCase.Administrators
{
    public class AdministratorQueryHandler : IRequestHandler<GetAdministratorByIdQuery, AdministratorViewModel>
    {
        private readonly ServiceHandler<IAdministratorService> serviceHandler =
            new ServiceHandler<IAdministratorService>();

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel> Handle(GetAdministratorByIdQuery request, CancellationToken cancellationToken)
        {
            Administrator administrator = serviceHandler.AggregationService.Get(request.Id);
            return serviceHandler.Success(administrator.Map<AdministratorViewModel>());
        }
    }
}
