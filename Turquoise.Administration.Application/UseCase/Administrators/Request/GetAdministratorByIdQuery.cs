using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Administrators.Request
{
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;
    public class GetAdministratorByIdQuery : IRequest<AdministratorViewModel>
    {
        public GetAdministratorByIdQuery()
        {
        }
        public GetAdministratorByIdQuery(Guid ıd)
        {
            Id = ıd;
        }
        public Guid Id { get; set; }
    }
}
