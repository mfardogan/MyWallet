using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Administrators.CQ
{
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;
    public class GetAdministratorById : IRequest<AdministratorViewModel>
    {
        public GetAdministratorById()
        {
        }
        public GetAdministratorById(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
