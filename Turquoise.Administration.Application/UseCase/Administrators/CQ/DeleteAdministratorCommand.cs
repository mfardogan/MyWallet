using MediatR;
using System;

namespace Turquoise.Administration.Application.UseCase.Administrators.CQ
{
    public class DeleteAdministratorCommand : IRequest
    {
        public Guid AdministratorId { get; set; }
    }
}
