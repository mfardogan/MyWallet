using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Administrators.CQ
{
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;
    public class GetAdministratorByIdQuery : IRequest<AdministratorViewModel>
    {
        public GetAdministratorByIdQuery()
        {
        }
        public GetAdministratorByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
